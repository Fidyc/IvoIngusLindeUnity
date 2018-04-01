using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour {

    public GameObject TrapDoor;

    private void OnTriggerEnter(Collider other)
    {
        TrapDoor.GetComponent<Animation>().Play("TrapAnim");
    }
}
