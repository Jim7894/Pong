using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scoreboard_Controller : MonoBehaviour {

    public static Scoreboard_Controller instance;

    public Text playerScoreText;
    public Text botScoreText;

    public int playerScore;
    public int botScore;


    // Use this for initialization
    void Start () {

        instance = this;

        playerScore = botScore = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GivePlayerAPoint() {

        playerScore += 1;
        playerScoreText.text = playerScore.ToString();

        if (playerScore > 9) {

            SceneManager.LoadScene("Scenes/PlayerVictory");


        }

    }
    public void GiveBotAPoint() {
      
        botScore += 1;
        botScoreText.text = botScore.ToString();

        if (botScore > 9) {

            SceneManager.LoadScene("Scenes/BotVictory");

        }

    }
}
