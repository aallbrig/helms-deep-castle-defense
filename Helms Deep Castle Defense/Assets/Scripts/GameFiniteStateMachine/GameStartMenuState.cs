using System;

public class GameStartMenuState : GameBaseState, IStartGameButtonClicked, ITestingGroundsButtonClicked
{
    public static event Action StartMenuEnter;
    public static event Action StartMenuLeave;

    private GameManager _gameManager;

    public override void Enter(GameManager gm)
    {
        StartMenuEnter?.Invoke();
        GameEventBroker.Instance.SubscribeToStartGameButtonClicked(this);
        GameEventBroker.Instance.SubscribeToTestingGroundsButtonClicked(this);
        _gameManager = gm;
    }

    public override void Update(GameManager gm) {}

    public override void Leave(GameManager gm)
    {
        StartMenuLeave?.Invoke();
        GameEventBroker.Instance.UnsubscribeToStartGameButtonClicked(this);
        GameEventBroker.Instance.UnsubscribeToTestingGroundsButtonClicked(this);
    }

    public void NotifyStartGameButtonClicked()
    {
        _gameManager.TransitionToGameState(_gameManager.Running);
    }

    public void NotifyTestingGroundsButtonClicked()
    {
        _gameManager.TransitionToGameState(_gameManager.TestingGrounds);
    }
}