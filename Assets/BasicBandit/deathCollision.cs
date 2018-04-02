using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCollision : MonoBehaviour {

    public GameObject Character;
    public GameObject GameOverText;
    public GameObject deathSound;
    public GameObject ambientSound;

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "deathObjects")
        {
            StartCoroutine(Death());
            
        }
    }
    private IEnumerator Death()
    {
        Debug.Log("Object collided with deathObjects");
        Character.GetComponent<Animator>().enabled = false;
        deathSound.GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(1);
        ambientSound.GetComponent<AudioSource>().Stop();
        GameOverText.GetComponent<Animation>().Play("GameOverAnim");
    }
}
