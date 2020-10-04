using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScriptTest : MonoBehaviour
{
    public float Speed;
    private Rigidbody rb;

    private Vector2 lastMousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaPos = Vector2.zero;


        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;

            if (lastMousePos == Vector2.zero)
            {
                lastMousePos = currentMousePos;
            }

            deltaPos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;

            Vector3 forse = new Vector3(deltaPos.x, 0, deltaPos.y) * Speed;
            rb.AddForce(forse);
        }
        else
        {
            lastMousePos = Vector2.zero;
        }

    }
}
