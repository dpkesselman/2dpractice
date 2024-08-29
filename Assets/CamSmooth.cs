using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSmooth : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smooth;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
        transform.position = smoothedPosition;
    }
}
