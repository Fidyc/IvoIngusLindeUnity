using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookForClosestPizza : MonoBehaviour
{
    public GameObject FindClosestPizza()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("pizzaTag");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (distance < 10)
        {
            Debug.Log("distance " + distance);
            return closest;
        }
        else
        {
            return null;
        }
    }
        
}
