using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {
    public Text timerText;
    private float startingTime = 99;
    private float countdownTime = 3;
    public string gameOver = "GAME OVER";
	private string p1win = "Player 1 Wins!";
	private string p2win = "Player 2 Wins!";
	private string tieGame = "Tie!";

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
    
	}
	
	// Update is called once per frame
	void Update () {
        if (Player1Health.hitpoint <= 0 || Player2Health.hitpoint <= 0){
			Time.timeScale = 0.0f;
			if (Player1Health.hitpoint <= 0 && Player2Health.hitpoint > 0) {
				timerText.text = p2win;
			} else if (Player2Health.hitpoint <= 0 && Player1Health.hitpoint > 0) {
				timerText.text = p1win;
			} else {
				timerText.text = tieGame;
			}
				
//            timerText.text = gameOver; //test
			Restart();
        }
        else if (countdownTime > 1){
			Time.timeScale = 1.0f;
            countdownTime -= Time.deltaTime;
            timerText.text = countdownTime.ToString("f0");
        }
        else if (startingTime > 0){
			Time.timeScale = 1.0f;
            startingTime -= Time.deltaTime;
            timerText.text = startingTime.ToString("f2");
        }
        else{
			Time.timeScale = 0.0f;
			if (Player1Health.hitpoint > Player2Health.hitpoint) {
				timerText.text = p1win;
			} else if (Player2Health.hitpoint > Player1Health.hitpoint) {
				timerText.text = p2win;
			} else {
				timerText.text = tieGame;
			}

			//timerText.text = gameOver; //test
			Restart();
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
