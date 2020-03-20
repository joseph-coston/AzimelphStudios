 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //general public variables for movement
    public CharacterController controller;
    public Camera pov;
    public float speed = 10f;
    public float acceleration = 1.5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2;
    public float jumpDelay = 1;

    //for determining if the player is on the ground or not
    public Transform goundCheck;
    public float groundDist = 0.2f;
    public LayerMask groundMask;

    // the character's velocity vector
    Vector3 vel;
    //flag set when player is standing on the ground (not in midair)
    bool onGround;
    
    float lastJump = 0;

    // Update is called once per frame
    void Update()
    {
        //check whether the player is on the ground or not
        onGround = Physics.CheckSphere(goundCheck.position, groundDist, groundMask);

        //movement variables
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //hold shift to sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2f;
        }

        //movement on the ground
        if (onGround)
        {
            //suck player character to ground
            if (vel.y < 0)
            {
                vel.y = -3;
            }

            //jump only when player character is on the ground olding space bar
            if (lastJump >= jumpDelay)
            {
                if (Input.GetButton("Jump"))
                {
                    vel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    lastJump = 0;
                }
            } else
            {
                lastJump += Time.deltaTime;

            }

            //add controller input values to velocity vector
            vel += transform.right * x * acceleration + transform.forward * z * acceleration;

            //prevent the player from accelerating past their top speed
            vel.x = Mathf.Clamp(vel.x, -speed, speed);
            vel.z = Mathf.Clamp(vel.z, -speed, speed);

            //reduce the velocity vector by the acceleration factor to bring player to a stop without button input
            vel.x = vel.x / acceleration;
            vel.z = vel.z / acceleration;

        }
        else
        {
            //apply a gravity vector to the character
            vel.y += gravity * Time.deltaTime;
        }

        //apply velocity vector to character to move them a certain distance according to the current framerate
        controller.Move(vel * Time.deltaTime);

        //depricated movement scheme
        //Vector3 move = transform.right * x + transform.forward * z;
        //controller.Move(move * speed * Time.deltaTime); 


    }
}
