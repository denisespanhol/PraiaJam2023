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

    private void Update()
    {
        MakeJustOneBridgeActive();
    }

    private void MakeJustOneBridgeActive()
    {
        foreach (GameObject bridge in bridges)
        {
            if (bridge.activeInHierarchy && bridge.name != activeBridge.name) bridge.SetActive(false); 
        }
    }
}
