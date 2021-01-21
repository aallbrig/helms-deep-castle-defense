using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Game manager is the context for game finite state machine
    public readonly GameBaseState StartMenu = new GameStartMenuState();
    public readonly GameBaseState TestingGrounds = new GameTestingGroundsState();
    public readonly GameBaseState Running = new GameRunningState();
    public readonly GameBaseState Paused = new GamePausedState();

    // TODO: Game manager can transition to Game Complete state
    public readonly GameBaseState Complete = new GameCompleteState();

    public string CurrentGameScene { get { return _currentGameScene; } }
    public GameBaseState PreviousGameState { get { return _previousGameState; } }

    private GameBaseState _previousGameState;
    private GameBaseState _currentGameState;
    private string _currentGameScene;

    public void TransitionToGameState(GameBaseState state)
    {
        _currentGameState?.Leave(this);
        _previousGameState = _currentGameState;
        _currentGameState = state;
        _currentGameState.Enter(this);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        _currentGameScene = sceneName;
    }

    public void UnloadScene(string sceneName)
    {
        _currentGameScene = null;
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void QuitGame() => Application.Quit();

    private void Update() => _currentGameState.Update(this);

    private void Start() => TransitionToGameState(StartMenu);

    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(gameObject);
    }
}
