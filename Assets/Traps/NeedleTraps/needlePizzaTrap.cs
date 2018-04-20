using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needlePizzaTrap : MonoBehaviour {
    public GameObject needle1;
    public GameObject needle2;
    public GameObject needle3;
    public GameObject pizza1;
    public GameObject pizza2;
    public GameObject pizza3;
    // Use this for initialization
    void Start () {
        int randomObject = Random.Range(0, 2);
        //debug
        /*foreach (GameObject obj in gosn)
        {
            print(obj.name);
        }*/
        for (int i = 0; 2>=i; i++)
        {
            if (i == randomObject)
            {
                if (i == 1)
                {
                    needle2.SetActive(false);
                    pizza2.SetActive(false);
                    Debug.Log(needle2.name);
                    Debug.Log(i);
                }
                if (i == 2)
                {
                    needle3.SetActive(false);
                    pizza3.SetActive(false);
                    Debug.Log(needle2.name);
                }
                if (i == 0)
                {
                    needle1.SetActive(false);
                    pizza1.SetActive(false);
                    Debug.Log(needle2.name);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
