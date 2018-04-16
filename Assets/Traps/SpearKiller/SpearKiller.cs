using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearKiller : MonoBehaviour {

    public GameObject[] spears;

    private void OnTriggerEnter(Collider other)
    {
        spears= GameObject.FindGameObjectsWithTag("spearKiller");

        foreach (GameObject spear in spears)
        {
            GameObject gameObjectParent = spear.transform.parent.gameObject;
            gameObjectParent.GetComponent<ConstantForce>().enabled = true;
        }
    }
}
