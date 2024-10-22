using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform launchPoint;

    [SerializeField] private float shootTime; // enfriamiento entre proyectiles
    [SerializeField] private float shootCounter; // temporizador de enfriamiento

    void Start()
    {
        shootCounter = shootTime;   
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && shootCounter <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            // Instantiate = spawn. Toma tres valores:
            // 1. Qué vas a instanciar - 2. Dónde lo vas a isntanciar - 3. Qué rotación va a tener el objeto
            // Quaternion: una forma de representar la rotación en un espacio 3D. Si se acompaña de .identity significa que el objeto mantendrá su rotación original.
            shootCounter = shootTime;
        }        

        shootCounter -= Time.deltaTime; // Hace que el enfriamiento cuente hacia abajo
    }
}
