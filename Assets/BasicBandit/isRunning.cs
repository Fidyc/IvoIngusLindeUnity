﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isRunning : MonoBehaviour {

	private Animator Animator;
	private CharacterController controller;

	public float speed = 0.2f;
	public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;

	void Start () {
		controller = GetComponent <CharacterController>();
		Animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update (){
		if (Input.GetKey ("up") || Input.GetKey("w") || Input.GetKey("down") || Input.GetKey("s"))
        {
            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                if (Input.GetKey ("left shift"))
                {
                    Animator.SetInteger ("isRunning", 2);    
                } else {
                    Animator.SetInteger("isRunning", 1);
                }
            }
            if (Input.GetKey("down") || Input.GetKey("s"))
            {
                Animator.SetInteger("isRunning", 3);
            }
        }  else {
			Animator.SetInteger ("isRunning", 0);
		}

        if (controller.isGrounded){
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
		}

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}
}
