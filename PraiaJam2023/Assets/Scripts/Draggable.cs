using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 mousePositionOffset;

    private void OnMouseDown()
    {
        // Capture the mouse offset;
        mousePositionOffset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Capture mouse position and return WorldPoint;
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
