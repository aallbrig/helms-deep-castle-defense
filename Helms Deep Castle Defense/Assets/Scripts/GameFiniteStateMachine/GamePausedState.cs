using System;
using UnityEngine;

public class GamePausedState : GameBaseState, IResumeButtonClicked, IRestartButtonClicked, IQuitButtonClicked
{
    public static event Action PausedEnter;
    public static event Action PausedLeave;
    private GameManager _gameManager;

    public override void Enter(GameManager gm)
    {
        PausedEnter?.Invoke();
        Time.timeScale = 0;
        _gameManager = gm;
        
        GameEventBroker.Instance.SubscribeToResumeButtonClicked(this);
        GameEventBroker.Instance.SubscribeToRestartButtonClicked(this);
        GameEventBroker.Instance.SubscribeToQuitButtonClicked(this);
    }

    public override void Update(GameManager gm)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gm.TransitionToGameState(gm.PreviousGameState);
        }
    }

    public override void Leave(GameManager gm)
    {
        PausedLeave?.Invoke();
        Time.timeScale = 1;

        GameEventBroker.Instance.UnsubscribeToResumeButtonClicked(this);
        GameEventBroker.Instance.UnsubscribeToRestartButtonClicked(this);
        GameEventBroker.Instance.UnsubscribeToQuitButtonClicked(this);
    }

    public void NotifyResumeButtonClicked()
    {
        _gameManager.TransitionToGameState(_gameManager.PreviousGameState);
    }

    public void NotifyRestartButtonClicked()
    {
        _gameManager.UnloadScene(_gameManager.CurrentGameScene);
        _gameManager.TransitionToGameState(_gameManager.StartMenu);
    }

    public void NotifyQuitButtonClicked()
    {
        _gameManager.QuitGame();
    }
}