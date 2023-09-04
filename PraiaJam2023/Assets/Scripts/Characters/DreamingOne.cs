using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamingOne : MonoBehaviour
{
    private GameManager _gameManagerScript;

    private void Awake()
    {
        _gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nightmare"))
        {
            _gameManagerScript.GameOver();
        }

        if (collision.CompareTag("Dream"))
        {
            _gameManagerScript.UpdateDreamCounter();
        }
    }
}
