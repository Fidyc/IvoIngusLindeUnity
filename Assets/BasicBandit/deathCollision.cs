using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCollision : MonoBehaviour {

    public GameObject Character;
    public GameObject GameOverText;

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "deathObjects")
        {
            Debug.Log("Object collided with deathObjects");
            Character.GetComponent<Animator>().enabled = false;
            GameOverText.GetComponent<Animation>().Play("GameOverAnim");

        }
    }
}
