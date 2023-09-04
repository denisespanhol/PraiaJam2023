using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] bridges;
    public GameObject[] connectionPoints;
    public GameObject[] destination;
    public GameObject activeBridge;
    public GameObject activeDestination;
    public bool isDragging = false;
    public bool isABridgeActive = false;
    public Coroutine closeTheBridgeCoroutine;
    public TextMeshProUGUI bridgeCounterText;
    public TextMeshProUGUI dreamCounterText;

    [SerializeField] private int _bridgesUsed = 0;
    [SerializeField] private int _maxAllowed = 3;

    [SerializeField] private int _dreamsCollected = 0;
    [SerializeField] private int _maxDreams = 2;

    [SerializeField] private float secondsToCloseTheBridge = 8f;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverUI;


    private void Update()
    {
        CheckIfAnyBridgeIsActive();
        CloseAllBridgesAfterATime();
        ShowPauseMenu();

        if (_maxAllowed == _maxAllowed + 1)
        {
            GameOver();
        }
    }

    private void CheckIfAnyBridgeIsActive()
    {
        foreach(GameObject bridge in bridges)
        {
            if (bridge.activeInHierarchy) isABridgeActive = true;
        }
    }

    private void CloseAllBridgesAfterATime()
    {
        if (isABridgeActive) closeTheBridgeCoroutine = StartCoroutine(CloseTheBridge());
        else if (!isABridgeActive && closeTheBridgeCoroutine != null)
        {
            StopAllCoroutines();
            // StopCoroutine(closeTheBridgeCoroutine);
            Debug.Log("Coroutine was stopped");
        }
    }

    IEnumerator CloseTheBridge()
    {
        yield return new WaitForSeconds(secondsToCloseTheBridge);

        Debug.Log("coroio");
        foreach (GameObject bridge in bridges)
        {
            if (bridge.activeInHierarchy) bridge.SetActive(false);
            isABridgeActive = false;
        }
    }

    private void ShowPauseMenu()
    {
        if (Time.timeScale == 0) pauseMenu.SetActive(true);

        else if (Time.timeScale == 1) pauseMenu.SetActive(false);
    }

    public void UpdateBridgeCounter()
    {
        _bridgesUsed += 1;
        bridgeCounterText.text = "Pontes Usadas: " + _bridgesUsed + "/" + _maxAllowed;
    }

    public void UpdateDreamCounter()
    {
        _dreamsCollected += 1;
        dreamCounterText.text = "Sonhos Guiados: " + _dreamsCollected + "/" + _maxDreams;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
