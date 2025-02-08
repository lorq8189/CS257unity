using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed;
   public float rotSpeed;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
   
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime; 
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0,0,speed*dt);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(0,0,-speed*dt);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-speed*dt,0,0);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(speed*dt,0,0);

        transform.Rotate(Input.GetAxis("Mouse Y")* (-rotSpeed) *dt, Input.GetAxis("Mouse X")*rotSpeed*dt,0);
    }
}
