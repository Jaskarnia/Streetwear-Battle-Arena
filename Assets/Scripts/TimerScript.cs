﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {
    public Text timerText;
    private float startingTime = 30;
    private float countdownTime = 5;
    public string gameOver = "GAME OVER";
	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
    
	}
	
	// Update is called once per frame
	void Update () {
        if (Player1Health.hitpoint == 0 || Player2Health.hitpoint == 0)
            {
                timerText.text = gameOver; //test
				Restart();
			
            }
        else if (countdownTime > 1)
            {
            countdownTime -= Time.deltaTime;
            timerText.text = countdownTime.ToString("f0");
            }
        else if (startingTime > 0)
            {
            startingTime -= Time.deltaTime;
            timerText.text = startingTime.ToString("f2");
            }
        else
            {
            timerText.text = gameOver;
            }

	 }

	void Restart(){
		if (Input.GetKeyDown(KeyCode.R))
		{
			startingTime = 30;
			Player1Health.hitpoint = 100;
			Player2Health.hitpoint = 100;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
