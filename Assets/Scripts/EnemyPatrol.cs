using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] private float speed;

    // Persecusión
    [SerializeField] private Transform playerTransform;
    private bool isChasing;
    [SerializeField] private float chaseDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;
    }


    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (isChasing)
        {
            if (rb.transform.position.x > playerTransform.position.x)
            {
                rb.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (rb.transform.position.x < playerTransform.position.x)
            {
                rb.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            if (currentPoint == pointA.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
                Flip();
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {   
                currentPoint = pointA.transform;
                Flip();
            }
        }

    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position); 
    }
}
