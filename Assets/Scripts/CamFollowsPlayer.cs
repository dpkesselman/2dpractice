
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamFollowsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target; // Nos permite seleccionar en el inspector el objeto al que queremos que siga la cámara principal


    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z); // Nos permite acomodar la posición de la cámara según la posición del GameObject target)
    }
}

