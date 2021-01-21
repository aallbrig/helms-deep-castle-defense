using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static event Action ResumeButtonClicked;
    public static event Action RestartButtonClicked;
    public static event Action QuitButtonClicked;

    public void OnResumeButtonClicked() => ResumeButtonClicked?.Invoke();
    public void OnRestartButtonClicked() => RestartButtonClicked?.Invoke();
    public void OnQuitButtonClicked() => QuitButtonClicked?.Invoke();
}
