using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapLine : MonoBehaviour
{

    public GameObject Trap;
    bool isInside = false;
    GameObject[] gos;
    Animation anim;
    private void Start()
    {
        gos = GameObject.FindGameObjectsWithTag("bladeTag");
    }
    private void OnTriggerEnter(Collider other)
    {
        isInside = true;
        StartCoroutine(LineTrap());
    }

    void OnTriggerExit(Collider other)
    {
        isInside = false;

    }

    public IEnumerator LineTrap()
    {
        while (isInside)
        {
            int randomTime = Random.Range(10, 15);
            yield return new WaitForSeconds(randomTime);
            foreach (GameObject Obj in gos)
            {
                Obj.GetComponent<Animation>().enabled = false;
            }
            Trap.GetComponent<Animation>().Play("Anim_GreatAxe_Idle");
            yield return new WaitForSeconds(randomTime);
            foreach (GameObject Obj in gos)
            {
                Obj.GetComponent<Animation>().enabled = true;
            }
            Trap.GetComponent<Animation>().Play("Anim_GreatAxeTrap_Play");
            yield return new WaitForSeconds(1.0f);
        }
        while (!isInside)
        {
            foreach (GameObject Obj in gos)
            {
                Obj.GetComponent<Animation>().enabled = true;
            }
            Trap.GetComponent<Animation>().Play("Anim_GreatAxeTrap_Play");
            yield return new WaitForSeconds(1.0f);

        }

    }
}
