using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPoints : MonoBehaviour
{
    [SerializeField] private float speedPointReturn = 20;

    private Draggable _draggableScript;
    private Vector3 _initialPointPosition;

    private void Awake()
    {
        _draggableScript = GetComponent<Draggable>();
        _initialPointPosition = transform.position;
    }

    private void Update()
    {
        PointReturning();
    }

    private void PointReturning()
    {
        if (transform.position != _initialPointPosition && !_draggableScript.isDragging)
        {
            transform.position = Vector3.MoveTowards(transform.position, _initialPointPosition, speedPointReturn * Time.deltaTime);
        }
    }
}
