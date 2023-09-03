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

        if (activeBridge.name == firstBridge.name)
        {
            GameObject[] rightPath = paths[0].targetsToWalk;

            if (targetIndex < rightPath.Length)
            {
                Vector2 targetPosition = rightPath[targetIndex].transform.position;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, nightmareSpeed * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) targetIndex += 1;
            }

        } 
    }
}

[System.Serializable]
public struct PathsToWalk
{
    public GameObject[] targetsToWalk;
}
