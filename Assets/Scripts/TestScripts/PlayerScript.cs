using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    public float ForwardSpeed;
    public float HorizontalSpeed;

    public bool isLeftWallCollision = false;
    public bool isRightWallCollision = false;

    public GameObject Ground;

    public float DownCameraDistance = 1;
    public float UpCameraDistance = 15;
    private Camera mainCamera;

    private Vector2 MouseStartPosition = new Vector2();

    private Vector3 lastPosition;

    private float myWallCollisiionTransform;

    private Vector3 startWorldPos;
    private Vector3 myStartPos;

    private void Start()
    {
    //    Ground = GameObject.FindGameObjectWithTag("Ground");

        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         //   MoveHorizontalStart();
         //   transform.position = lastPosition;
        }

        if (Input.GetMouseButton(0))
        {
          //  MoveForward();

            MoveHorizontal();
        }

        if (Input.GetMouseButtonUp(0))
        {
         //   lastPosition = transform.position;
        }

        
    }

    private void LateUpdate()
    {
        MoveHorizontalCheck();
    }

    private void MoveHorizontal()
    {
        Vector2 detaPos = Vector2.zero; ;

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;

            if (MouseStartPosition == Vector2.zero)
                MouseStartPosition = currentMousePos;

            detaPos = currentMousePos - MouseStartPosition;
            MouseStartPosition = currentMousePos;

            Vector3 Force = new Vector3(detaPos.x, 0, detaPos.y) * HorizontalSpeed;

            rb.AddForce(Force);
        }
        else
        {
            MouseStartPosition = Vector2.zero;
        }
    }

  /*  private void MoveHorizontalStart()
    {
        myStartPos = transform.position;
        var _groundPlace = new Plane(Vector3.up, Vector3.zero);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);


        if (_groundPlace.Raycast(ray, out float position))
        {
            Vector3 worldposition = ray.GetPoint(position);

            startWorldPos = worldposition;
        }
    }

    private void MoveHorizontal()
    {
        var _groundPlace = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (_groundPlace.Raycast(ray, out float position))
        {
            Vector3 worldPosition = ray.GetPoint(position);
            Vector3 WorldPos = worldPosition;
            Vector3 posToTransform = (WorldPos - startWorldPos);

            // transform.position = new Vector3(myStartPos.x + posToTransform.x, 0.5f, transform.position.z);

            transform.position = myStartPos + posToTransform;

    //        Vector3 Speed = new Vector3(0, 0, posToTransform.z) * HorizontalSpeed;

    //        rb.AddForce(Speed);
            //  myStartPos + posToTransform;


        }
    }
    */

        /*
            private void MoveHorizontalStart()
            {
                MouseStartPosition = Input.mousePosition;
            }

            private void MoveHorizontal()
            {
                Vector2 MouseCurrentPosition = Input.mousePosition;

                rb.AddForce((transform.position - new Vector3(mouse)) * HorizontalSpeed);
            }
            */


        /* private void MoveHorizontalStart()
         {
             myStartPos = transform.position;
             var _groundPlace = new Plane(Vector3.up, Vector3.zero);

             Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);


             if (_groundPlace.Raycast(ray, out float position))
             {
                 Vector3 worldposition = ray.GetPoint(position);

                 startWorldPos = worldposition;
             }
         }


         private void MoveHorizontal()
         {

             var _groundPlace = new Plane(Vector3.up, Vector3.zero);
             Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

             if (_groundPlace.Raycast(ray, out float position))
             {
                 Vector3 worldPosition = ray.GetPoint(position);
                 Vector3 WorldPos = worldPosition;
                 Vector3 posToTransform = (WorldPos - myStartPos);

                 Debug.Log("" + posToTransform);

                 Vector3 Speed = new Vector3(posToTransform.x, 0, posToTransform.z) * HorizontalSpeed;
               //  Vector3 SpeedY = new Vector3(0, 0, posToTransform.z) * HorizontalSpeed;

                 rb.AddForce(Speed);

             //    if (posToTransform.x > 0)
             //    {
             //        if(transform.position.x < posToTransform.x)
             //        {
             //            rb.AddForce(Speed);
             //        }
             //        else
             //        {
             //            rb.AddForce(SpeedY);
             //        }
             //    }

             //    if (posToTransform.x < 0)
             //    {
             //        if(transform.position.x > posToTransform.x)
             //        {
             //            rb.AddForce(Speed);
             //        }
             //        else
             //        {
             //            rb.AddForce(SpeedY);
             //        }
             //    }

             }

         }*/


        private void MoveHorizontalCheck()
    {
        Vector3 myPos = transform.position;

        if(transform.position.z < mainCamera.transform.position.z + DownCameraDistance)
        {
            myPos.z = mainCamera.transform.position.z + DownCameraDistance;
        }

        if (transform.position.z > mainCamera.transform.position.z + UpCameraDistance)
        {
            myPos.z = mainCamera.transform.position.z + UpCameraDistance;
        }

        if(transform.position.x < -3)
        {
            myPos.x = -3;
        }

        if (transform.position.x > 3)
        {
            myPos.x = 3;
        }

        transform.position = myPos;
    }

    // первый вариант
  /*  private void MoveHorizontalStart()
    {
        //  MouseStartPosition = Input.mousePosition;

        myStartPos = transform.position;
        var _groundPlace = new Plane(Vector3.up, Vector3.zero);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);


        if (_groundPlace.Raycast(ray, out float position))
        {
            Vector3 worldposition = ray.GetPoint(position);

           startWorldPos = worldposition;
        }
    }
    private void MoveHorizontal()
    {

        var _groundPlace = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (_groundPlace.Raycast(ray, out float position))
        {
            Vector3 worldPosition = ray.GetPoint(position);
            Vector3 move = worldPosition;
            Vector3 posToTransform = (move - startWorldPos) ;

            transform.position = myStartPos + posToTransform;

            if(transform.position.x > 3)
            {
                posToTransform.x = 3;
                posToTransform.y = 0.5f;
                posToTransform.z = myStartPos.z + posToTransform.z;
                transform.position = posToTransform;
            }

            if (transform.position.x < -3)
            {
                posToTransform.x = -3;
                posToTransform.y = 0.5f;
                posToTransform.z = myStartPos.z + posToTransform.z;
                transform.position = posToTransform;
            }

            //if (isLeftWallCollision && myWallCollisiionTransform < (transform.position.x + posToTransform.x)*2
            //    || isRightWallCollision && myWallCollisiionTransform > (transform.position.x + posToTransform.x)*2)
            //{
            //    //     transform.position = new Vector3((transform.position.x + posToTransform) * HorizontalSpeed, 0.5f, transform.position.z);
            //    // transform.position = new Vector3(transform.position.x + (posToTransform ), 0.5f, transform.position.z);
            //    transform.position = myStartPos + posToTransform;
            //}
            //else if (!isLeftWallCollision && !isRightWallCollision)
            //{
            //    //      transform.position = new Vector3((transform.position.x + posToTransform) * HorizontalSpeed, 0.5f, transform.position.z);
            //    //  transform.position = new Vector3(transform.position.x + (posToTransform ), 0.5f, transform.position.z);
            //    transform.position = myStartPos + posToTransform;

            //}

            //Debug.Log("" + (transform.position.x + posToTransform) * HorizontalSpeed);

            //  Debug.Log("" + (transform.position.x + (posToTransform * HorizontalSpeed)));

            //   Debug.Log("" + posToTransform * 0.5f);
            //Debug.Log("start World Pos X" + startWorldPosX);
            //Debug.Log(" World Pos X" + x);


        }

    }*/

    private void MoveForward()
    {
        rb.velocity = (Vector3.forward * ForwardSpeed * Time.deltaTime);
     //   Debug.Log("Move Forward");
    }

}
