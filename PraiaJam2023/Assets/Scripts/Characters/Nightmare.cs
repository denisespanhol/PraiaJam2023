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

    private int targetIndex = 0;

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

            if (targetIndex < rightPath.Length)
            {
                Vector2 targetPosition = rightPath[targetIndex].transform.position;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) targetIndex += 1;
            }

        }

        // Makes the nightmare walk to the second bridge when it's active
        if (activeBridge.name == secondBridge.name)
        {
            rightPath = paths[1].targetsToWalk;

            if (targetIndex < rightPath.Length)
            {
                Vector2 targetPosition = rightPath[targetIndex].transform.position;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) targetIndex += 1;
            }

        }

        // Makes the nightmare walk to the second bridge when it's active
        if (activeBridge.name == thirdBridge.name && _islandStaying.name != "Dream Land 1")
        {
            rightPath = paths[2].targetsToWalk;

            if (targetIndex < rightPath.Length)
            {
                Vector2 targetPosition = rightPath[targetIndex].transform.position;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) targetIndex += 1;
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
