using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("LifeLeft", 3);
        PlayerPrefs.SetFloat("timeLeft", 90f);
    }

    public void QuitGame(){
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
