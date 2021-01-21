using System.Collections;
using UnityEngine;

public class GameRunningState : GameBaseState
{
    private string sceneName = "Main";
    private IEnumerator winGameCoroutine;

    public override void Enter(GameManager gm)
    {
        if (gm.CurrentGameScene != sceneName)
        {
            if (gm.CurrentGameScene != null) gm.UnloadScene(gm.CurrentGameScene);
            gm.LoadScene(sceneName);
        }
    }

    public override void Update(GameManager gm)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gm.TransitionToGameState(gm.Paused);
        }
    }

    public override void Leave(GameManager gm) {}
}