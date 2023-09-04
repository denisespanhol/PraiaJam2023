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

    [SerializeField] private float _bridgesUsed = 0;
    [SerializeField] private int _maxAllowed = 3;

    [SerializeField] private int _dreamsCollected = 0;
    [SerializeField] private int _maxDreams = 2;

    [SerializeField] private float secondsToCloseTheBridge = 8f;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject victoryUI;

    private bool _isGameOver = false;


    private void Awake()
    {
        _isGameOver = false;
    }

    private void Update()
    {
        CheckIfAnyBridgeIsActive();
        CloseAllBridgesAfterATime();
        ShowPauseMenu();
        Victory();

        if (_bridgesUsed > _maxAllowed)
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
        _bridgesUsed += 0.5f;
        bridgeCounterText.text = "Pontes Usadas: " + _bridgesUsed + "/" + _maxAllowed;
    }

    public void UpdateDreamCounter()
    {
        _dreamsCollected += 1;
        dreamCounterText.text = "Sonhos Guiados: " + _dreamsCollected + "/" + _maxDreams;
    }

    public void GameOver()
    {
        _isGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Victory()
    {
        if (_dreamsCollected == _maxDreams && !_isGameOver) victoryUI.SetActive(true);
    }
}
