using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public GameObject gameObj;
    [SerializeField] private float x_min;
    [SerializeField] private float x_max;
    [SerializeField] private int incrInd;
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
        
        if(pos_x > x_min && pos_x < x_max)
        {
            if(Input.GetKey(KeyCode.Space) && Time.timeScale!=0)
            {
                // Debug.Log("Clicked on the door");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + incrInd);
            }
        }
         
    }

}
