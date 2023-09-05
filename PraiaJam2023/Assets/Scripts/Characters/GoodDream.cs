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
        GameObject activeBridge = _gameManagerScript.activeBridge;

        if (activeBridge == null) return;

        Vector3 targetPosition = new Vector3(targetsToWalk[targetIndex].transform.position.x, targetsToWalk[targetIndex].transform.position.y, transform.position.z);
        
        if (theBridgeForTheMainLand.name == activeBridge.name && targetIndex < targetsToWalk.Length)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, goodDreamSpeed * Time.deltaTime);

            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) targetIndex += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Island") || collision.CompareTag("DreamingOne"))
        {
            foreach (GameObject bridge in _gameManagerScript.bridges)
            {
                if (bridge.activeInHierarchy) bridge.SetActive(false);
            }

            _gameManagerScript.isABridgeActive = false;
        }
    }
}
