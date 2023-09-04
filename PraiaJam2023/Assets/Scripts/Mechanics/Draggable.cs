using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 mousePositionOffset;
    private GameManager _gameManagerScript;
    private Animator _animator;

    private void Awake()
    {
        _gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _animator = GameObject.Find("Sandman").GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        // Capture the mouse offset;
        mousePositionOffset = transform.position - GetMouseWorldPosition();
        _gameManagerScript.isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (!_gameManagerScript.isABridgeActive)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
            _animator.SetBool("isDragging", true);
        }
    }

    private void OnMouseUp()
    {
        _gameManagerScript.isDragging = false;
        _animator.SetBool("isDragging", false);
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Capture mouse position and return WorldPoint;
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
