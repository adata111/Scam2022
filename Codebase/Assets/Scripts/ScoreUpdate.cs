using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreTextHolder;

    private void Start()
        {
            // scoreTextHolder = gameObject.GetComponent<TMP_Text>();
            // PlayerPrefs.SetInt("score", 0);
            score = PlayerPrefs.GetInt("score");
            scoreTextHolder.text = "Score: "+score;
            Debug.Log("start score");
            Debug.Log(score);
        }


    public void UpdateScore(int val)
    {
        score = PlayerPrefs.GetInt("score");
        score += val;
        PlayerPrefs.SetInt("score", score);
        scoreTextHolder.text = "Score: "+score;
    }
}
