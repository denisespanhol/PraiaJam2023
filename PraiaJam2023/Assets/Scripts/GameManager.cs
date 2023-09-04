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

    private void Update()
    {
        checkIfAnyBridgeIsActive();
    }
    private void checkIfAnyBridgeIsActive()
    {
        foreach(GameObject bridge in bridges)
        {
            if (bridge.activeInHierarchy) isABridgeActive = true;
        }
    }
}
