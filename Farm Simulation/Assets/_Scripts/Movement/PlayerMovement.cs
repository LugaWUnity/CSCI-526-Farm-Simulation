﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public Joystick joystick;

    //private float minX = -7.9f;
    //private float minY = -4f;

   //private float maxX = 7.9f;
    //private float maxY = 4f;

    // private float joystickDeadZone = 0.2f;
    
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        // float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveHorizontal = 0f;
        // if the joystick falls under a joystickdeadzone, there are no reactions
        /*
        if(Math.Abs(joystick.Horizontal) >= joystickDeadZone){
            // if positive horizontal movements are within scope, allow the movements
            if(rb2d.position.x < maxX && joystick.Horizontal > 0){
                moveHorizontal = joystick.Horizontal;
                // if negative horizontal movements are within scope, allow the movements
            }else if(rb2d.position.x > minX && joystick.Horizontal < 0){
                moveHorizontal = joystick.Horizontal;
            }
        }
        */

        moveHorizontal = joystick.Horizontal;


        //Store the current vertical input in the float moveVertical.
        // float moveVertical = Input.GetAxis ("Vertical");
        float moveVertical = 0f;
        /*
         * // if the joystick falls under a joystickdeadzone, there are no reactions
        if(Math.Abs(joystick.Vertical) >= joystickDeadZone){
            // if positive vertical movements are within scope, allow the movements
            if(rb2d.position.y < maxY && joystick.Vertical > 0){
                moveVertical = joystick.Vertical;
                // if negative vertical movements are within scope, allow the movements
            }else if(rb2d.position.y > minY && joystick.Vertical < 0){
                moveVertical = joystick.Vertical;
            }
        }
        */

        moveVertical = joystick.Vertical;


        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.velocity =  (movement * speed);
    }

}
