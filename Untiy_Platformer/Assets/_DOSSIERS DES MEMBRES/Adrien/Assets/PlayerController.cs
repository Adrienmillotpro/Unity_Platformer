﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;

    public float JumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool ableToMakeADoubleJump = true;

    public Animator animator;
    public Transform model;

 
    
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        direction.x = hInput * speed;

        animator.SetFloat("Speed", Mathf.Abs(hInput));
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        
        animator.SetBool("isGrounded", isGrounded);


        if (isGrounded)
        {
            
            ableToMakeADoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = JumpForce;
                
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
            if (ableToMakeADoubleJump & Input.GetButtonDown("Jump"))
            {
                direction.y = JumpForce;
                ableToMakeADoubleJump = false;
            }
        }
       
        if(hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }
      

        controller.Move(direction * Time.deltaTime);
    }
}
