using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_table : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer gameObj;
    public bool isClicked;

    void Start()
    {
        gameObj = GetComponent<SpriteRenderer>();
        isClicked = false;
    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        float pos_x = gameObj.transform.position.x;
        float pos_y = gameObj.transform.position.y;
        
        if(isClicked == true)
        {
            gameObj.transform.localPosition = new Vector3(pos_x-15,pos_y,0);
            isClicked = false;
        }
        else
        {
            gameObj.transform.localPosition = new Vector3(pos_x+15,pos_y,0);
            isClicked = true;
        }

        Debug.Log("Moved!!!!");
    }

}
