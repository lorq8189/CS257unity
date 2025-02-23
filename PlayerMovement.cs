using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
   public float speed;
   public float rotSpeed;
   private Rigidbody rbody;
   private Vector2 movementValue;
   private float lookValue;


   private void Awake()
   {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rbody = GetComponent<Rigidbody>();

   }

   public void OnMove(InputValue value)
   {
        movementValue = value.Get<Vector2>() * speed;

   }

   public void OnLook(InputValue value)
   {
        lookValue = value.Get<Vector2>().x * rotSpeed;

   }

    void Start()
    {
        
   
    }

    // Update is called once per frame

    void Update()
    {
        
        float dt = Time.deltaTime; 

        rbody.AddRelativeForce(dt*movementValue.x,0,dt*movementValue.y);

        rbody.AddRelativeTorque(0,dt*lookValue,0);
        

       
    }
}
