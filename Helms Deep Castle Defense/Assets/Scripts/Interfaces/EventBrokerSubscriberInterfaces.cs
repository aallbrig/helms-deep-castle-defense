public interface IStartMenuEnter
{
    void NotifyStartMenuEnter();
}

public interface IStartMenuLeave
{
    void NotifyStartMenuLeave();
}

public interface IPausedEnter
{
    void NotifyPausedEnter();
}

public interface IPausedLeave
{
    void NotifyPausedLeave();
}

public interface IStartGameButtonClicked
{
    void NotifyStartGameButtonClicked();
}

public interface ITestingGroundsButtonClicked
{
    void NotifyTestingGroundsButtonClicked();
}

public interface IResumeButtonClicked
{
    void NotifyResumeButtonClicked();
}

public interface IRestartButtonClicked
{
    void NotifyRestartButtonClicked();
}

public interface IQuitButtonClicked
{
    void NotifyQuitButtonClicked();
}

