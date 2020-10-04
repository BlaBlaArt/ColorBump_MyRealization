using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pandoragame
{


    public class PlayerControllerScript : MonoBehaviour
    {
        public float Speed;
        public float ForwardSpeed;
        public static bool Available;
        private Rigidbody rb;
        private Camera mainCamera;

        public Canvas Finish;
        public Canvas GameOverCanvas;

        public ParticleSystem Line;
        public ParticleSystem Big;
        public ParticleSystem Dead;

        private Renderer MainRenderer;

        //public int MyColor;

        private Vector2 lastMousePos;
        private Vector2 deltaPos;

        public float DownCameraDistance = 1;
        public float UpCameraDistance = 18;

        private void Awake()
        {
            Available = false;
            Time.timeScale = 1;
        }

        void Start()
        {
            MainRenderer = GetComponent<Renderer>();
            mainCamera = Camera.main;
            rb = GetComponent<Rigidbody>();
        //    CollorChenger(MyColor);
        }
        
        void Update()
        {

            if (Available)
            {
                StartParticles();

                MoveForward();

                deltaPos = Vector2.zero;

                if (Input.GetMouseButton(0))
                {

                    Movable();
                }
                else
                {
                    lastMousePos = Vector2.zero;
                }

            }

        }

        private void LateUpdate()
        {
            CheckMovable();
        }

        private void MoveForward()
        {
            rb.velocity = new Vector3(0, 0, ForwardSpeed);
        }

        private void Movable()
        {
            Vector2 currentMousePos = Input.mousePosition;

            if (lastMousePos == Vector2.zero)
            {
                lastMousePos = currentMousePos;
            }

            deltaPos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;

            Vector3 force = new Vector3(deltaPos.x, 0, deltaPos.y) * Speed;
            rb.AddForce(force);
        }

        private void CheckMovable()
        {
            Vector3 myPos = transform.position;

            if (myPos.x > 4.5f)
            {
                myPos.x = 4.5f;
                transform.position = myPos;
            }

            if (myPos.x < -4.5f)
            {
                myPos.x = -4.5f;
                transform.position = myPos;
            }

            if (myPos.z > mainCamera.transform.position.z + UpCameraDistance && Available)
            {
                myPos.z = mainCamera.transform.position.z + UpCameraDistance;
                transform.position = myPos;
            }

            if (myPos.z < mainCamera.transform.position.z + DownCameraDistance && Available)
            {
                myPos.z = mainCamera.transform.position.z + DownCameraDistance;
                transform.position = myPos;
            }
        }

        private void CollorChenger(int colorNumber)
        {
            switch (colorNumber)
            {
                case 0:
                    {
                        SetColor(Colors.white);
                        break;
                    }

                case 1:
                    {
                        SetColor(Colors.black);
                        break;
                    }
            }
        }

        private void SetColor(Colors color)
        {
            switch (color)
            {
                case Colors.white:
                    {
                        MainRenderer.material.color = Color.white;
                        break;
                    }

                case Colors.black:
                    {
                        MainRenderer.material.color = Color.black;
                        break;
                    }
            }

        }

        private void GameOver( GameObject Other)
        {
            if (Other.CompareTag("Finish"))
            {
                // Time.timeScale = 0.3f;
                Speed /= 2;
                CameraController.Speed /= 4;
                Debug.Log("Finish");
                Finish.enabled = true;
                Available = false;
              // Destroy(this);
            }
            else
            {


                ParticleSystem tmpDead = Instantiate<ParticleSystem>(Dead);
                tmpDead.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                tmpDead.Play();
                //Dead.Play();
                
             //   Speed /= 2;
                CameraController.Speed /= 4;
                GameOverCanvas.enabled = true;
                //  Time.timeScale = 0.3f;
                Destroy(this.gameObject);
            }

        }

        public void StartParticles()
        {

            Big.Play();
            Line.Play();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("EnemyObject"))
            {
                Time.timeScale = 0.5f;
                
                Debug.Log("enemy");
                GameOver(collision.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                GameOver(other.gameObject);
            }
        }
    }
}
