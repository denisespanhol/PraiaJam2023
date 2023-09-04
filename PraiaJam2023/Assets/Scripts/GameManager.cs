using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] bridges;
    public GameObject[] connectionPoints;
    public GameObject[] destination;
    public GameObject activeBridge;
    public GameObject activeDestination;
    public bool isDragging = false;
    public bool isABridgeActive = false;

    [SerializeField] private float secondsToCloseTheBridge = 8f;

    private void Update()
    {
        checkIfAnyBridgeIsActive();
        closeAllBridgesAfterATime();
    }
    private void checkIfAnyBridgeIsActive()
    {
        foreach(GameObject bridge in bridges)
        {
            if (bridge.activeInHierarchy) isABridgeActive = true;
        }
    }

    private void closeAllBridgesAfterATime()
    {
        if (isABridgeActive) StartCoroutine(CloseTheBridge());
    }

    IEnumerator CloseTheBridge()
    {
        yield return new WaitForSeconds(secondsToCloseTheBridge);

        foreach (GameObject bridge in bridges)
        {
            if (bridge.activeInHierarchy) bridge.SetActive(false);
            isABridgeActive = false;
        }
    }
}
