using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class substractPoints : MonoBehaviour
{
    public int pointsToSubstract;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PointSytem.Instance.SubstractingPoints(pointsToSubstract);
            other.gameObject.GetComponent<HP>().TakeDamage(20);
        }
    }
}
