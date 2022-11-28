using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collectItem : MonoBehaviour {
     
    private int score;
    private moveTile t;
    public GameObject tile;
   //   public Text scoreText;
    public GameObject txtobj;
 
     // Use this for initialization
     void Start () 
     {
        t = tile.GetComponent<moveTile>();
     }
     
     // Update is called once per frame
     void Update () {
         
     }

     

    //  void OnMouseDown ()
    //  {

    //   Debug.Log("************clicked money**********");
      
    //   // if(t.isClicked == true)
    //   {
    //     Destroy (gameObject);
    //     // scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
    //     Debug.Log("Destroyed game object");
    //     if(GameObject.Find("Canvas/score"))
    //     {
    //       txtobj = GameObject.Find("Canvas/score");
    //       Debug.Log("Found the text object");
    //     }
        
    //     TextMeshProUGUI scoreText = txtobj.GetComponent<TextMeshProUGUI>();
    //     Debug.Log("Text: " + scoreText.text);
    //     string s = scoreText.text;
    //     int strlen = s.Length;
    //     string substr = s.Substring(6, strlen - 6);
    //     score = int.Parse(substr);
    //     score = score + 100;
    //     scoreText.text = score.ToString ();
    //     Debug.Log("updated score: " + scoreText.text);
    //     txtobj.GetComponent<TextMeshProUGUI>().text = "Item: " + score.ToString ();
    //  }
    //   }
 }
