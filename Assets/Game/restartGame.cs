﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class restartGame : MonoBehaviour {

    public GameObject restartButton;
    public GameObject GameOverText;
    public GameObject HudCanvas;

    void Start()
    {
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        GameOverText.GetComponent<Animation>().Stop("GameOverAnim");
        HudCanvas.SetActive(false);
    }

}
