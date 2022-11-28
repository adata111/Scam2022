using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_to_room3 : MonoBehaviour
{
     public GameObject gameObj;
     // Use this for initialization
     void Start () {

    }
     
     // Update is called once per frame
     void Update () {

        if(GameObject.Find("player"))
        {
            gameObj = GameObject.Find("player");
        }

        float pos_x = gameObj.transform.position.x;
        float pos_y = gameObj.transform.position.y;
        
        if(pos_x > 270f && pos_x < 281f)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Clicked on the door");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
        }
         
    }
}
 