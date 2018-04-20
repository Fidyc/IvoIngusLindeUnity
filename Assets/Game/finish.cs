using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class finish : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}