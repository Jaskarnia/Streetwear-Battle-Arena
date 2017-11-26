using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    public Text timerText;
    private float startingTime = 30;
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
}
