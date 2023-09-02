using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 mousePositionOffset;

    private GameManager _gameManagerScript;

    private void Awake()
    {
        _gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        // Capture the mouse offset;
        mousePositionOffset = transform.position - GetMouseWorldPosition();
        _gameManagerScript.isDragging = true;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        _gameManagerScript.isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Capture mouse position and return WorldPoint;
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
