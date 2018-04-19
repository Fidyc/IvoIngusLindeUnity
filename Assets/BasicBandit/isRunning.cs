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
    public GameObject poop;
    public GameObject Character;
    private bool beingHandled = false;

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
                /*closest = FindClosestLever();
                if (closest != null)
                {
                    food += 1;
                    Debug.Log("Food " + food);
                    Destroy(closest);
                }*/
                return;
            }
        }  else {
			Animator.SetInteger ("isRunning", 0);
            return;
        }

       
        
    }
    /*
    public GameObject FindClosestLever()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("pizzaTag");
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
    /*public IEnumerator Poop()
    {
        GameObject PoopDuplicate;
        Vector3 pos = Character.transform.position;
        pos = pos + new Vector3(0, 0, -0.5f);
        Quaternion rot = Character.transform.rotation;
        Sleep(500);
        PoopDuplicate = Instantiate(poop, pos, rot);
        PoopDuplicate.SetActive(true);
    }*/
    private IEnumerator Sleep()
    {
        beingHandled = true;
        // process pre-yield
        GameObject PoopDuplicate;
        Vector3 pos = Character.transform.position;
        pos = pos + new Vector3(0, 0, -0.6f);
        Quaternion rot = Character.transform.rotation;
        yield return new WaitForSeconds(1.0f);
        PoopDuplicate = Instantiate(poop, pos, rot);
        PoopDuplicate.SetActive(true);
        // process post-yield
        beingHandled = false;
    }
}
