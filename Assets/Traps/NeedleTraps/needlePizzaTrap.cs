using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needlePizzaTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] gos;
        GameObject[] gosn;
        GameObject childObj;
        gos = GameObject.FindGameObjectsWithTag("pizzaTag");
        int randomObject = Random.Range(0, gos.Length);
        gosn = GameObject.FindGameObjectsWithTag("needleTag");
        //debug
        foreach (GameObject obj in gosn)
        {
            print(obj.name);
        }
        for (int i = 0; gos.Length>=i; i++)
        {
            if (i == randomObject)
            {
                gos[i].SetActive(false);
                print(gosn[i].name + "Deleted obj");
                gosn[i].SetActive(false);
                //gosn[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
