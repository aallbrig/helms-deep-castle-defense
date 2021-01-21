using System.Collections;
using UnityEngine;

public class UIManager : Singleton<UIManager>, IStartMenuEnter, IStartMenuLeave, IPausedEnter, IPausedLeave
{
    public Camera dummyCamera;
    public GameObject mainMenu;
    public GameObject pauseMenu;

    // Display appropriate UI based on what game state is currently active
    private IEnumerator SubscribeOnceGameEventBrokerExists()
    {
        while (GameEventBroker.Instance == null)
        {
            yield return null;
        }
        GameEventBroker.Instance.SubscribeToStartMenuEnter(this);
        GameEventBroker.Instance.SubscribeToStartMenuLeave(this);
        GameEventBroker.Instance.SubscribeToPausedEnter(this);
        GameEventBroker.Instance.SubscribeToPausedLeave(this);

        StopCoroutine(SubscribeOnceGameEventBrokerExists());
    }
    protected override void Awake()
    {
        base.Awake();

        StartCoroutine(SubscribeOnceGameEventBrokerExists());
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        GameEventBroker.Instance.UnsubscribeToStartMenuEnter(this);
        GameEventBroker.Instance.UnsubscribeToStartMenuLeave(this);
        GameEventBroker.Instance.UnsubscribeToPausedEnter(this);
        GameEventBroker.Instance.UnsubscribeToPausedLeave(this);
    }

    public void NotifyStartMenuEnter()
    {
        dummyCamera.gameObject.SetActive(true);
        mainMenu.SetActive(true);
    }

    public void NotifyStartMenuLeave()
    {
        dummyCamera.gameObject.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void NotifyPausedEnter()
    {
        pauseMenu.SetActive(true);
    }

    public void NotifyPausedLeave()
    {
        pauseMenu.SetActive(false);
    }
}
