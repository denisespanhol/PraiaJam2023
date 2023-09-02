using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDream : MonoBehaviour
{
    [SerializeField] private GameObject theBridgeForTheMainLand;
    [SerializeField] private GameObject[] targetsToWalk;
    [SerializeField] private float goodDreamSpeed = 2;

    private int targetIndex = 0;

    private GameManager _gameManagerScript;

    private void Awake()
    {
        _gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        GoodDreamWalk();
    }

    private void GoodDreamWalk()
    {
        if (_gameManagerScript.activeBridge == null) return;

        if (theBridgeForTheMainLand.name == _gameManagerScript.activeBridge.name && targetIndex < targetsToWalk.Length)
        {
            Vector3 targetPosition = targetsToWalk[targetIndex].transform.position;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, goodDreamSpeed * Time.deltaTime);

            if (transform.position == targetPosition) targetIndex += 1;
        }
    }
}
