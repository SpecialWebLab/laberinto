using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class Player : MonoBehaviour
    {
        //Creo una variable que le da la velocidad inicial al objeto
        public float speed = 1.0f;
        public float rotationSpeed = 64.0f; // Esta variable es para rotar
        
        //Variable para saltar
        public float jump = 5.0f;

        private Rigidbody rb;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rb = GetComponent<Rigidbody>();
        }
        // Update is called once per frame
        void Update()
        {
            //Movimiento
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            //Movimiento en la direccion del jugador
            Vector3 direction = transform.forward * vertical + transform.right * horizontal;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            
            // transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

            //Rotion hacia la direccion del movimiento
            if(direction != Vector3.zero)
            {
               Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 *Time.deltaTime); 
            }

            //Rotacion
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationX, 0);

            //Salto
            if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            }
        }
        private bool IsGrounded(){
            return Physics.Raycast(transform.position, Vector3.down, 1.1f);
        }
        private void OnCollisionEnter(Collision collision){
            if(collision.gameObject.CompareTag("Enemy")){
                Debug.Log("Perdiste. Reiniciando el juego...");
                GameAdmin.Instance.RestartGame(0.5f);
            }
        }
    }


