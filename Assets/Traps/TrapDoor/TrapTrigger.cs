using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour {

    public GameObject TrapDoor;
    public GameObject DeathSphere;
    public GameObject DeathSphereCol;

    private void OnTriggerEnter(Collider other)
    {
        TrapDoor.GetComponent<Animation>().Play("TrapAnim");
        DeathSphere.GetComponent<Rigidbody>().useGravity = true;
        DeathSphereCol.GetComponent<Rigidbody>().useGravity = true;
    }
}
