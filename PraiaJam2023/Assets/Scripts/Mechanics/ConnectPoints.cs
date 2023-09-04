using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPoints : MonoBehaviour
{
    [SerializeField] private float speedPointReturn = 20;

    private GameManager _gameManagerScript;
    private Nightmare _nightmareScript;
    private Vector3 _initialPointPosition;

    private void Awake()
    {
        _gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _nightmareScript = GetComponent<Nightmare>();
        _initialPointPosition = transform.position;
    }

    private void Update()
    {
        PointReturning();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tag) && !_gameManagerScript.isDragging)
        {
            foreach (GameObject bridge in _gameManagerScript.bridges)
            {
                if (bridge.name == tag)
                {
                    bridge.SetActive(true);
                    _gameManagerScript.activeBridge = bridge;
                    _gameManagerScript.UpdateBridgeCounter();
                }
            }
        }
    }

    private void PointReturning()
    {
        if (transform.position != _initialPointPosition && !_gameManagerScript.isDragging)
        {
            transform.position = Vector3.MoveTowards(transform.position, _initialPointPosition, speedPointReturn * Time.deltaTime);
        }
    }
}
