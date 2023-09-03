using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    public PathsToWalk[] paths;

    [SerializeField] GameObject firstBridge;
    [SerializeField] GameObject secondBridge;
    [SerializeField] GameObject thirdBridge;
    [SerializeField] private float nightmareSpeed = 2;

    private GameManager _gameManagerScript;
    private GameObject _islandStaying;
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
        NightmareWalk();
    }

    private void NightmareWalk()
    {
        if (_gameManagerScript.activeBridge == null) return;

        GameObject activeBridge = _gameManagerScript.activeBridge;
        GameObject[] rightPath;

        // Makes the nightmare walk to the first bridge when it's active
        if (activeBridge.name == firstBridge.name && _islandStaying.name != "Dream Land 2")
        {
            rightPath = paths[0].targetsToWalk;

            if (_bridgeIndex1 < rightPath.Length)
            {
                Vector2 targetPosition = rightPath[_bridgeIndex1].transform.position;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex1 += 1;
            }

        }

        // Makes the nightmare walk to the second bridge when it's active
        if (activeBridge.name == secondBridge.name)
        {
            rightPath = paths[1].targetsToWalk;

            if (_bridgeIndex2 < rightPath.Length)
            {
                Vector2 targetPosition = rightPath[_bridgeIndex2].transform.position;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex2 += 1;
            }

        }

        // Makes the nightmare walk to the third bridge when it's active
        if (activeBridge.name == thirdBridge.name && _islandStaying.name != "Dream Land 1")
        {
            rightPath = paths[2].targetsToWalk;

            if (_bridgeIndex3 < rightPath.Length)
            {
                Vector2 targetPosition = rightPath[_bridgeIndex3].transform.position;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) _bridgeIndex3 += 1;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Island")) _islandStaying = collision.gameObject;
    }
}

[System.Serializable]
public struct PathsToWalk
{
    public GameObject[] targetsToWalk;
}
