using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutterTrap : MonoBehaviour {


    public float speed = 0.1f;
    private bool beingHandled = false;
    GameObject[] gos;
    Animation anim;

    // Use this for initialization
    void Start() {
        gos = GameObject.FindGameObjectsWithTag("cutterTag");
        StartCoroutine(CutterSpeed());
    }

    // Update is called once per frame
    void Update() {
        
        //print(speed);
    }

    public IEnumerator CutterSpeed()
    {
        GameObject cutChild;
        while (true)
        {
            speed = Mathf.Lerp(speed, 10f, 0.1f);
            foreach (GameObject obj in gos)
            {
                anim = obj.GetComponent<Animation>();
                anim["Anim_TrapCutter_Play"].speed = speed;
            }
            if (speed > 9.95f)
            {
                Debug.Log(speed);
                speed = 0;
                foreach (GameObject obj in gos)
                {
                    anim = obj.GetComponent<Animation>();
                    anim["Anim_TrapCutter_Play"].speed = speed;
                    cutChild = obj.transform.GetChild(0).gameObject;
                    //Debug.Log(cutChild.name);
                    cutChild.GetComponent<MeshCollider>().isTrigger = false;
                }
                yield return new WaitForSeconds(10.0f);
                foreach (GameObject obj in gos)
                {
                    cutChild = obj.transform.GetChild(0).gameObject;
                    //Debug.Log(cutChild.name);
                    cutChild.GetComponent<MeshCollider>().isTrigger = true;
                }
            }
            
            yield return new WaitForSeconds(1.0f);
        }
        
    }
}
