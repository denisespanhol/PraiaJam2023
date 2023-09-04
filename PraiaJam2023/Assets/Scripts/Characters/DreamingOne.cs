using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamingOne : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nightmare"))
        {
            gameOverUI.SetActive(true);
        }
    }
}
