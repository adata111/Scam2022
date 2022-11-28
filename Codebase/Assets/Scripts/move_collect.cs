using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class move_collect : MonoBehaviour
{
    public GameObject gameObj;
    public bool isClicked;
    public bool tile_isClicked;
    public Camera MainCamera;
    public GameObject currObj;
    public GameObject tile;
    public GameObject collectible;
    // public GameObject xx;
    // public GameControl gc;
    private moveTile t1;
    private collectItem c1;
    private int score;
    private bool flag;
    [SerializeField] private int objCollPoints;
    [SerializeField] public float tileMoveUnit;
    [SerializeField] public float objectMoveUnit;

    // Start is called before the first frame update
    void Start()
    {
        // gameObj = GetComponent<SpriteRenderer>();
        t1 = tile.GetComponent<moveTile>();
        c1 = collectible.GetComponent<collectItem>();
        // gc = xx.GetComponent<GameControl>();
        // isClicked = false;
        // tile_isClicked = false;
        flag = true;
        if(MainCamera == null)
            Debug.LogError("No MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
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
                Debug.Log("front most object is " + mouseSelection.gameObject);
                currObj = mouseSelection.gameObject;
                // Debug.Log("curr obj = " + currObj.name);
                // Debug.Log("Furniture = " + gameObj.name);
                // Debug.Log("tile = " + tile.name);
                // Debug.Log("Money = " + collectible.name);
                // Its the furniture
                if(currObj.name == gameObj.name)
                {
                    // move_obj(ref gameObj, ref isClicked, 15f);
                    float pos_x = gameObj.transform.position.x;
                    float pos_y = gameObj.transform.position.y;
                    
                    if(isClicked == true)
                    {
                        gameObj.transform.localPosition = new Vector3(pos_x - objectMoveUnit, pos_y, 0);
                        isClicked = false;
                    }
                    else
                    {
                        gameObj.transform.localPosition = new Vector3(pos_x + objectMoveUnit, pos_y, 0);
                        isClicked = true;
                    }

                    Debug.Log("is clicked for Table - " + isClicked);
                    Debug.Log("Moved Table!!!!");
                }

                // Its the tile
                else if(currObj.name == tile.name)
                {
                    // move_tile(ref tile, ref tile_isClicked, 7f);
                    float pos_x = tile.transform.position.x;
                    float pos_y = tile.transform.position.y;

                    Debug.Log("is clicked for tile - " + tile_isClicked);
                    
                    if(tile_isClicked == true)
                    {
                        tile.transform.localPosition = new Vector3(pos_x + tileMoveUnit, pos_y, 0);
                        tile_isClicked = false;
                    }
                    else
                    {
                        tile.transform.localPosition = new Vector3(pos_x - tileMoveUnit, pos_y, 0);
                        tile_isClicked = true;
                    }

                    Debug.Log("Moved Tile!!!!");
                }
                
                else if(flag == true)
                {
                    if(currObj.name == collectible.name)
                    {
                        destroy_increment(ref collectible);
                    }
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

    void move_obj(ref GameObject obj, ref bool isClicked, float move_pos)
    {
        float pos_x = obj.transform.position.x;
        float pos_y = obj.transform.position.y;
        
        if(isClicked == true)
        {
            obj.transform.localPosition = new Vector3(pos_x - move_pos, pos_y, 0);
            isClicked = false;
        }
        else
        {
            obj.transform.localPosition = new Vector3(pos_x + move_pos, pos_y, 0);
            isClicked = true;
        }

        Debug.Log("is clicked for Table - " + isClicked);
        Debug.Log("Moved Table!!!!");
    }

    void move_tile(ref GameObject tile, ref bool isTileClicked, float move_pos)
    {
        float pos_x = tile.transform.position.x;
        float pos_y = tile.transform.position.y;

        Debug.Log("is clicked for tile - " + isTileClicked);
        
        if(isTileClicked == true)
        {
            tile.transform.localPosition = new Vector3(pos_x + move_pos, pos_y, 0);
            isClicked = false;
        }
        else
        {
            tile.transform.localPosition = new Vector3(pos_x - move_pos, pos_y, 0);
            isTileClicked = true;
        }

        Debug.Log("Moved Tile!!!!");
    }

    void destroy_increment(ref GameObject collectible)
    {
        Destroy (collectible);
        // scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        // Debug.Log("Destroyed game object");
        // if(GameObject.Find("Canvas/score"))
        // {
        //     txtobj = GameObject.Find("Canvas/score");
        //     Debug.Log("Found the text object");
        // }
        
        // TextMeshProUGUI scoreText = txtobj.GetComponent<TextMeshProUGUI>();
        // Debug.Log("Text: " + scoreText.text);
        // string s = scoreText.text;
        // int strlen = s.Length;
        // string substr = s.Substring(6, strlen - 6);
        score = PlayerPrefs.GetInt("score");
        FindObjectOfType<ScoreUpdate>().UpdateScore(objCollPoints);
        // scoreTextCanvas.GetComponent<ScoreUpdate>.UpdateScore(objCollPoints);
        // ScoreUpdate.UpdateScore(objCollPoints);
        // gc.score += 100;
        // score = score + 100;
        // score = PlayerPrefs.SetInt("score", score);
        // scoreText.text = score.ToString ();
        // Debug.Log("updated score: " + score);
        // txtobj.GetComponent<TextMeshProUGUI>().text = "Item: " + score.ToString ();

        flag = false;
    }

}
