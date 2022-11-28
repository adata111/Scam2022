using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class final_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer gameObj;
    public float speed = 100f;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    // Facing left and right based on the direction of motion
    public bool isFacingLeft = false;
    public bool spawnFacingLeft = false;
    private Vector2 facingLeft;

    public int keys = 0;
    private int score;

    public Text keyAmount;
    public Text youWin;
    public GameObject door;

    // public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObj = GetComponent<SpriteRenderer>();

        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if(spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }
    }

    void Flip()
    {
        if(isFacingLeft)
        {
            transform.localScale = facingLeft;
        }
        if(!isFacingLeft)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        verticalMove = Input.GetAxisRaw("Vertical") * speed;
        // if(horizontalMove != 0)
        // {
        //     animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        // }
        // else if(verticalMove != 0)
        // {
        //     animator.SetFloat("Speed", Mathf.Abs(verticalMove));
        // }
        // else
        // {
        //     animator.SetFloat("Speed", Mathf.Abs(0));
        // }

        if(keys==3)
        {
            Destroy(door);
        }
    }

    void FixedUpdate()
    {
        movePlayer();
    }

    void movePlayer()
    {
        float pos_x = gameObj.transform.position.x;
        float pos_y = gameObj.transform.position.y;
        
        if(horizontalMove>0 && isFacingLeft)
        {
            isFacingLeft = false;
            Flip();
        }
        if(horizontalMove<0 && !isFacingLeft)
        {
            isFacingLeft = true;
            Flip();
        }
        
        gameObj.transform.localPosition = new Vector3(pos_x + horizontalMove * Time.fixedDeltaTime, pos_y + verticalMove * Time.fixedDeltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Keys")
        {
            keys++;
            keyAmount.text = "Keys: " + keys;
            score = PlayerPrefs.GetInt("score");
            FindObjectOfType<ScoreUpdate>().UpdateScore(100);
            Destroy(collision.gameObject);
        }
        
    }
}
