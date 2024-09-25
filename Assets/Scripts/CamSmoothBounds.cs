using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSmoothBounds : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smooth; 
    [SerializeField] private Vector3 offset; 

    // Variables que utilizaremos para fijar límites
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float topLimit;
    
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
        transform.position = smoothedPosition;      

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
    }
}

