using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    public GameObject[] paths;
    public GameObject islandStaying;

    [SerializeField] private float nightmareSpeed = 2;

    private GameManager _gameManagerScript;
    private int _bridgeIndex1 = 0;
    private int _bridgeIndex2 = 0;
    private int _bridgeIndex3 = 0;
    private int _bridgeIndex4 = 0;

    private void Awake()
    {
        _gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        NightmareDestination();
        PathManager();
        NightmareWalk();
    }

    private void NightmareWalk()
    {
        if (_gameManagerScript.activeBridge == null || _gameManagerScript.activeDestination == null) return;

        GameObject firstBridge = _gameManagerScript.bridges[0];
        GameObject secondBridge = _gameManagerScript.bridges[1];
        GameObject thirdBridge = _gameManagerScript.bridges[2];
        GameObject activeBridge = _gameManagerScript.activeBridge;
        GameObject activeDestination = _gameManagerScript.activeDestination;

        if (_bridgeIndex1 < paths.Length && activeDestination.name == "Dreaming One" && firstBridge.activeInHierarchy)
        {
            Vector2 targetPosition = paths[_bridgeIndex1].transform.position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex1 += 1;
        }

        if (_bridgeIndex2 < paths.Length && activeDestination.name == "IslandCenter2" && secondBridge.activeInHierarchy)
        {
            Vector2 targetPosition = paths[_bridgeIndex2].transform.position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex2 += 1;
        }

        if (_bridgeIndex3 < paths.Length && activeDestination.name == "Dreaming One" && thirdBridge.activeInHierarchy)
        {
            Vector2 targetPosition = paths[_bridgeIndex3].transform.position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex3 += 1;
        }

        if (_bridgeIndex4 < paths.Length && activeDestination.name == "IslandCenter1" && secondBridge.activeInHierarchy)
        {
            Vector2 targetPosition = paths[_bridgeIndex4].transform.position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex4 += 1;
        }
    }

    private void NightmareDestination()
    {
        GameObject firstBridge = _gameManagerScript.bridges[0];
        GameObject secondBridge = _gameManagerScript.bridges[1];
        GameObject thirdBridge = _gameManagerScript.bridges[2];
        GameObject activeBridge = _gameManagerScript.activeBridge;

        if (islandStaying == null) return;

        if (islandStaying.name == "IslandCenter1" && firstBridge.activeInHierarchy)
        {
            _gameManagerScript.activeDestination = _gameManagerScript.destination[0];
        }

        if (islandStaying.name == "IslandCenter1" && secondBridge.activeInHierarchy)
        {
            _gameManagerScript.activeDestination = _gameManagerScript.destination[2];
        }

        if (islandStaying.name == "IslandCenter2" && thirdBridge.activeInHierarchy)
        {
            _gameManagerScript.activeDestination = _gameManagerScript.destination[0];
        }

        if (islandStaying.name == "IslandCenter2" && secondBridge.activeInHierarchy)
        {
            _gameManagerScript.activeDestination = _gameManagerScript.destination[1];
        }
    }

    private void PathManager()
    {
        GameObject firstBridge = _gameManagerScript.bridges[0];
        GameObject secondBridge = _gameManagerScript.bridges[1];
        GameObject thirdBridge = _gameManagerScript.bridges[2];
        GameObject activeBridge = _gameManagerScript.activeBridge;
        GameObject activeDestination = _gameManagerScript.activeDestination;

        if (activeBridge == null || activeDestination == null) return;

        if (activeBridge.name == firstBridge.name)
        { 
            paths[0] = _gameManagerScript.connectionPoints[1];
            paths[1] = _gameManagerScript.connectionPoints[0];
            paths[2] = _gameManagerScript.destination[0];
        } 

        if (activeBridge.name == secondBridge.name && activeDestination.name == "IslandCenter2")
        {
            paths[0] = _gameManagerScript.connectionPoints[2];
            paths[1] = _gameManagerScript.connectionPoints[3];
            paths[2] = _gameManagerScript.destination[2];
        }

        if (activeBridge.name == thirdBridge.name)
        {
            paths[0] = _gameManagerScript.connectionPoints[4];
            paths[1] = _gameManagerScript.connectionPoints[5];
            paths[2] = _gameManagerScript.destination[0];
        }

        if (activeBridge.name == secondBridge.name && activeDestination.name == "IslandCenter1")
        {
            paths[0] = _gameManagerScript.connectionPoints[3];
            paths[1] = _gameManagerScript.connectionPoints[2];
            paths[2] = _gameManagerScript.destination[1];
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Island")) islandStaying = collision.gameObject;
    }
}