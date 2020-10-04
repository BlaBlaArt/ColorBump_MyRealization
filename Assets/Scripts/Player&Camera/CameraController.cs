using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static float Speed;
    public static bool Available;

    Rigidbody rb;

    private void Awake()
    {
        Speed = 5;
        Available = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Available)
        {
            rb.velocity = new Vector3(0, 0, Speed);
               // rb.velocity = (Vector3.forward * Speed * Time.deltaTime);
        }

    }
}
