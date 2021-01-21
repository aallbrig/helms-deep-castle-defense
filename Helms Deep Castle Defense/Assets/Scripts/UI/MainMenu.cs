using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static event Action StartGameButtonClicked;
    public static event Action TestingGroundsButtonClicked;
    public void OnStartGameButtonClicked() => StartGameButtonClicked?.Invoke();
    public void OnTestingGroundsButtonClicked() => TestingGroundsButtonClicked?.Invoke();
}