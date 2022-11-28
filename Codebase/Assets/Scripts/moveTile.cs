using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTile : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer gameObj;
    public bool isClicked;
    public GameObject frontObject;
    private move_table f; 

    void Start()
    {
        gameObj = GetComponent<SpriteRenderer>();
        // frontObject = GameObject.Find("Furniture");
        f = frontObject.GetComponent<move_table>();
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void OnMouseDown()
    // {
    //     Debug.Log("%%%%%%%%%% CLICKED TILE %%%%%%%%%%%%%");
    //     float pos_x = gameObj.transform.position.x;
    //     float pos_y = gameObj.transform.position.y;
        
    //     // if(f.isClicked == true)
    //     {
    //          if(isClicked == true)
    //         {
    //             gameObj.transform.localPosition = new Vector3(pos_x+7,pos_y,0);
    //             isClicked = false;
    //         }
    //         else
    //         {
    //             gameObj.transform.localPosition = new Vector3(pos_x-7,pos_y,0);
    //             isClicked = true;
    //         }

    //         Debug.Log("Moved!!!!");
    //     }
       
    // }
}
