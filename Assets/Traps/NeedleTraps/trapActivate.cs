using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapActivate : MonoBehaviour {

    public GameObject Trap;

    private void OnTriggerEnter(Collider other)
    {
        Trap.GetComponent<Animation>().Play("Anim_TrapNeedle_Play");
    }
}
