using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object") || other.CompareTag("EnemyObject"))
           Destroy(other.gameObject);
    }
}
