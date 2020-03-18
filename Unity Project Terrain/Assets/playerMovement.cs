 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float acceleration = 1.5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2;


    public Transform goundCheck;
    public float groundDist = 0.5f;
    public LayerMask groundMask;

    Vector3 vel;
    bool onGround;

    // Update is called once per frame
    void Update()
    {
        //check whether the player is on the ground or not
        onGround = Physics.CheckSphere(goundCheck.position, groundDist, groundMask);

        //movement variables
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //movement on the ground
        if (onGround)
        {
            //suck player character to ground
            if (vel.y < 0)
            {
                vel.y = vel.y / 2f;
            }

            //jump only when player character is on the ground olding space bar
            if (Input.GetButton("Jump"))
            {
                vel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            vel += transform.right * x * acceleration + transform.forward * z * acceleration;

            vel.x = Mathf.Clamp(vel.x, -speed, speed);
            vel.z = Mathf.Clamp(vel.z, -speed, speed);

            vel.x = vel.x / acceleration;
            vel.z = vel.z / acceleration;


        }


        Vector3 move = transform.right * x + transform.forward * z;
        vel.y += gravity * Time.deltaTime;


        //controller.Move(move * speed * Time.deltaTime);
        controller.Move(vel * Time.deltaTime);


    }
}
