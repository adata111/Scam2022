using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectDoc : MonoBehaviour
{
    public GameObject gameObj;
    public Camera MainCamera;
    public GameObject currObj;

    private int score;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        if(MainCamera == null)
            Debug.LogError("No MainCamera");
    }

    void Update () 
    {
        if(Input.GetMouseButtonDown(0))
        {
            var mouseSelection = CheckForObjectUnderMouse();
            if(mouseSelection == null)
                Debug.Log("nothing selected by mouse");
            else
            {
                // Debug.Log("front most object is " + mouseSelection.gameObject);
                currObj = mouseSelection.gameObject;
                
                if(currObj.name == gameObj.name)
                {
                    SceneManager.LoadScene("MidCutscene");
                    score = PlayerPrefs.GetInt("score");
                    FindObjectOfType<ScoreUpdate>().UpdateScore(200);
                }
                
            }
        }
    }

    private GameObject CheckForObjectUnderMouse()
    {
        Vector2 touchPostion = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] allCollidersAtTouchPosition = Physics2D.RaycastAll(touchPostion, Vector2.zero);

        SpriteRenderer closest = null; //Cache closest sprite reneder so we can assess sorting order
        foreach(RaycastHit2D hit in allCollidersAtTouchPosition)
        {
            if(closest == null) // if there is no closest assigned, this must be the closest
            {
                closest = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                continue;
            }

            var hitSprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();

            if(hitSprite == null)
                continue; //If the object has no sprite go on to the next hitobject

            if(hitSprite.sortingOrder > closest.sortingOrder)
                closest = hitSprite;
        }

        return closest != null ? closest.gameObject : null;
    }

}
