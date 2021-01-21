using System.Collections.Generic;

public class GameEventBroker : Singleton<GameEventBroker>
{
    private readonly List<IStartMenuEnter> _startMenuEnterSubscribers = new List<IStartMenuEnter>();
    public void SubscribeToStartMenuEnter(IStartMenuEnter sub) => _startMenuEnterSubscribers.Add(sub);
    public void UnsubscribeToStartMenuEnter(IStartMenuEnter sub) => _startMenuEnterSubscribers.Remove(sub);
    private void NotifyStartMenuEnter() => _startMenuEnterSubscribers.ForEach(sub => sub.NotifyStartMenuEnter());


    private readonly List<IStartMenuLeave> _startMenuLeaveSubscribers = new List<IStartMenuLeave>();
    public void SubscribeToStartMenuLeave(IStartMenuLeave sub) => _startMenuLeaveSubscribers.Add(sub);
    public void UnsubscribeToStartMenuLeave(IStartMenuLeave sub) => _startMenuLeaveSubscribers.Remove(sub);
    private void NotifyStartMenuLeave() => _startMenuLeaveSubscribers.ForEach(sub => sub.NotifyStartMenuLeave());


    private readonly List<IPausedEnter> _pausedEnterSubscribers = new List<IPausedEnter>();
    public void SubscribeToPausedEnter(IPausedEnter sub) => _pausedEnterSubscribers.Add(sub);
    public void UnsubscribeToPausedEnter(IPausedEnter sub) => _pausedEnterSubscribers.Remove(sub);
    private void NotifyPausedEnter() => _pausedEnterSubscribers.ForEach(sub => sub.NotifyPausedEnter());


    private readonly List<IPausedLeave> _pausedLeaveSubscribers = new List<IPausedLeave>();
    public void SubscribeToPausedLeave(IPausedLeave sub) => _pausedLeaveSubscribers.Add(sub);
    public void UnsubscribeToPausedLeave(IPausedLeave sub) => _pausedLeaveSubscribers.Remove(sub);
    private void NotifyPausedLeave() => _pausedLeaveSubscribers.ForEach(sub => sub.NotifyPausedLeave());


    private readonly List<IStartGameButtonClicked> _startGameButtonClickedSubscribers = new List<IStartGameButtonClicked>();
    public void SubscribeToStartGameButtonClicked(IStartGameButtonClicked sub) => _startGameButtonClickedSubscribers.Add(sub);
    public void UnsubscribeToStartGameButtonClicked(IStartGameButtonClicked sub) => _startGameButtonClickedSubscribers.Remove(sub);
    private void NotifyStartGameButtonClicked() => _startGameButtonClickedSubscribers.ForEach(sub => sub.NotifyStartGameButtonClicked());


    private readonly List<ITestingGroundsButtonClicked> _testingGroundsButtonClickedSubscribers = new List<ITestingGroundsButtonClicked>();
    public void SubscribeToTestingGroundsButtonClicked(ITestingGroundsButtonClicked sub) => _testingGroundsButtonClickedSubscribers.Add(sub);
    public void UnsubscribeToTestingGroundsButtonClicked(ITestingGroundsButtonClicked sub) => _testingGroundsButtonClickedSubscribers.Remove(sub);
    private void NotifyTestingGroundsButtonClicked() => _testingGroundsButtonClickedSubscribers.ForEach(sub => sub.NotifyTestingGroundsButtonClicked());


    private readonly List<IResumeButtonClicked> _resumeButtonClickedSubscribers = new List<IResumeButtonClicked>();
    public void SubscribeToResumeButtonClicked(IResumeButtonClicked sub) => _resumeButtonClickedSubscribers.Add(sub);
    public void UnsubscribeToResumeButtonClicked(IResumeButtonClicked sub) => _resumeButtonClickedSubscribers.Remove(sub);
    private void NotifyResumeButtonClicked() => _resumeButtonClickedSubscribers.ForEach(sub => sub.NotifyResumeButtonClicked());


    private readonly List<IRestartButtonClicked> _restartButtonClickedSubscribers = new List<IRestartButtonClicked>();
    public void SubscribeToRestartButtonClicked(IRestartButtonClicked sub) => _restartButtonClickedSubscribers.Add(sub);
    public void UnsubscribeToRestartButtonClicked(IRestartButtonClicked sub) => _restartButtonClickedSubscribers.Remove(sub);
    private void NotifyRestartButtonClicked() => _restartButtonClickedSubscribers.ForEach(sub => sub.NotifyRestartButtonClicked());


    private readonly List<IQuitButtonClicked> _quitButtonClickedSubscribers = new List<IQuitButtonClicked>();
    public void SubscribeToQuitButtonClicked(IQuitButtonClicked sub) => _quitButtonClickedSubscribers.Add(sub);
    public void UnsubscribeToQuitButtonClicked(IQuitButtonClicked sub) => _quitButtonClickedSubscribers.Remove(sub);
    private void NotifyQuitButtonClicked() => _quitButtonClickedSubscribers.ForEach(sub => sub.NotifyQuitButtonClicked());


    protected override void Awake()
    {
        base.Awake();

        GameStartMenuState.StartMenuEnter += NotifyStartMenuEnter;
        GameStartMenuState.StartMenuLeave += NotifyStartMenuLeave;
        GamePausedState.PausedEnter += NotifyPausedEnter;
        GamePausedState.PausedLeave += NotifyPausedLeave;
        MainMenu.StartGameButtonClicked += NotifyStartGameButtonClicked;
        MainMenu.TestingGroundsButtonClicked += NotifyTestingGroundsButtonClicked;
        PauseMenu.ResumeButtonClicked += NotifyResumeButtonClicked;
        PauseMenu.RestartButtonClicked += NotifyRestartButtonClicked;
        PauseMenu.QuitButtonClicked += NotifyQuitButtonClicked;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        GameStartMenuState.StartMenuEnter -= NotifyStartMenuEnter;
        GameStartMenuState.StartMenuLeave -= NotifyStartMenuLeave;
        GamePausedState.PausedEnter -= NotifyPausedEnter;
        GamePausedState.PausedLeave -= NotifyPausedLeave;
        MainMenu.StartGameButtonClicked -= NotifyStartGameButtonClicked;
        MainMenu.TestingGroundsButtonClicked -= NotifyTestingGroundsButtonClicked;
        PauseMenu.ResumeButtonClicked -= NotifyResumeButtonClicked;
        PauseMenu.RestartButtonClicked -= NotifyRestartButtonClicked;
        PauseMenu.QuitButtonClicked -= NotifyQuitButtonClicked;
    }
}