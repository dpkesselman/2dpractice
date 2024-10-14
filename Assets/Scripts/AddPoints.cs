using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    public int pointsToAdd;
    [SerializeField] private ParticleSystem particles;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            particles.Play();
            PointSytem.Instance.AddingPoints(pointsToAdd);            
        }
    }
}
