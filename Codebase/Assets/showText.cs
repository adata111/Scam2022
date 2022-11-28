using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showText : MonoBehaviour
{
    public GameObject xx;
    public GameControl gc;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        gc = xx.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = gc.score;
        Debug.Log("Score is " + score);
        Debug.Log("Gameobject is" + gameObject.name);
        gameObject.GetComponent<TextMeshProUGUI>().text = "Item: " + score.ToString();
    }

}

