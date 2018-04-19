using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isRunning : MonoBehaviour {

	private Animator Animator;
	private CharacterController controller;
	public float speed = 0.2f;
    public int food = 5;
	public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
    public GameObject Character;
    public GameObject spearTrigger;

    void Start () {
		controller = GetComponent <CharacterController>();
		Animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update (){
        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
        if (Input.GetKey("space"))
        {
            Animator.SetInteger("isRunning", 0);
        }
        if (Input.anyKey)
        {
            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                if (Input.GetKey ("left shift"))
                {
                    Animator.SetInteger ("isRunning", 2);
                    return;
                } else {
                    Animator.SetInteger("isRunning", 1);
                    return;
                }
            }
            if (Input.GetKey("down") || Input.GetKey("s"))
            {
                Animator.SetInteger("isRunning", 3);
                return;
            }
            if (Input.GetKeyDown("e"))
            {
                Animator.SetInteger("isRunning", 4);
                GameObject closest;
                closest = FindClosestLever();
                if (closest != null)
                {
                    if (spearTrigger.GetComponent<MeshCollider>().enabled == true)
                    {
                        closest.GetComponent<Animation>().Play("down");
                        spearTrigger.GetComponent<MeshCollider>().enabled = false;
                    }
                }
                return;
            }
        }  else {
			Animator.SetInteger ("isRunning", 0);
            return;
        }

       
        
    }
    
    public GameObject FindClosestLever()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("spearLeverTag");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (distance < 5)
        {
            Debug.Log("distance " + distance);
            return closest;
        }
        else
        {
            return null;
        }
    }
}
