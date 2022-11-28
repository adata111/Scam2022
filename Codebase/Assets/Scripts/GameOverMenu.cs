using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    
    [SerializeField] private TMP_Text scoreHolder;

    private void Start(){
        Debug.Log("Final SCore\n");
        int score = PlayerPrefs.GetInt("score");
        scoreHolder.text = "Score: "+score;
    }

    public void ReplayGame(){
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
