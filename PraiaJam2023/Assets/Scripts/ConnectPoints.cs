using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPoints : MonoBehaviour
{
    [SerializeField] private float speedPointReturn = 20;
    private Vector3 initialPointPosition;

    private void Awake()
    {
        initialPointPosition = transform.position;
    }

    private void Update()
    {
        PointReturning();
    }

    private void PointReturning()
    {
        if (transform.position != initialPointPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPointPosition, speedPointReturn * Time.deltaTime);
        }
    }
}
