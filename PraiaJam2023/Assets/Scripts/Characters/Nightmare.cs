using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    public GameObject[] paths;
    public GameObject islandStaying;

    [SerializeField] private float nightmareSpeed = 2;

    private GameManager _gameManagerScript;
    private int _bridgeIndex = 0;

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
        GameObject activeDestination = _gameManagerScript.activeDestination;

        Vector3 targetPosition = new Vector3(paths[_bridgeIndex].transform.position.x, paths[_bridgeIndex].transform.position.y, transform.position.z);

        if (_bridgeIndex < paths.Length && activeDestination.name == "Dreaming One" && firstBridge.activeInHierarchy)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex += 1;
        }

        if (_bridgeIndex < paths.Length && activeDestination.name == "IslandCenter2" && secondBridge.activeInHierarchy)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex += 1;
        }

        if (_bridgeIndex < paths.Length && activeDestination.name == "Dreaming One" && thirdBridge.activeInHierarchy)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex += 1;
        }

        if (_bridgeIndex < paths.Length && activeDestination.name == "IslandCenter1" && secondBridge.activeInHierarchy)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex += 1;
        }
    }

    private void NightmareDestination()
    {
        GameObject firstBridge = _gameManagerScript.bridges[0];
        GameObject secondBridge = _gameManagerScript.bridges[1];
        GameObject thirdBridge = _gameManagerScript.bridges[2];

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
        GameObject activeDestination = _gameManagerScript.activeDestination;

        if (activeDestination == null) return;

        if (firstBridge.activeInHierarchy)
        { 
            paths[0] = _gameManagerScript.connectionPoints[1];
            paths[1] = _gameManagerScript.connectionPoints[0];
            paths[2] = _gameManagerScript.destination[0];
        } 

        if (secondBridge.activeInHierarchy && activeDestination.name == "IslandCenter2")
        {
            paths[0] = _gameManagerScript.connectionPoints[2];
            paths[1] = _gameManagerScript.connectionPoints[3];
            paths[2] = _gameManagerScript.destination[2];
        }

        if (thirdBridge.activeInHierarchy)
        {
            paths[0] = _gameManagerScript.connectionPoints[4];
            paths[1] = _gameManagerScript.connectionPoints[5];
            paths[2] = _gameManagerScript.destination[0];
        }

        if (secondBridge.activeInHierarchy && activeDestination.name == "IslandCenter1")
        {
            paths[0] = _gameManagerScript.connectionPoints[3];
            paths[1] = _gameManagerScript.connectionPoints[2];
            paths[2] = _gameManagerScript.destination[1];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Island"))
        {
            foreach(GameObject bridge in _gameManagerScript.bridges)
            {
                if (bridge.activeInHierarchy) bridge.SetActive(false);
            }

            _gameManagerScript.isABridgeActive = false;
            _bridgeIndex = 0;
            islandStaying = collision.gameObject;
        }
    }
}