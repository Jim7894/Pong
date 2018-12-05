using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void StartGame(){
        Debug.Log("click");

        SceneManager.LoadScene("Scenes/Game");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
