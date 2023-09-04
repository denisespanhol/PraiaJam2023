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
    public Coroutine closeTheBridgeCoroutine;

    [SerializeField] private float secondsToCloseTheBridge = 8f;

    private void Update()
    {
        CheckIfAnyBridgeIsActive();
        CloseAllBridgesAfterATime();
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
}
