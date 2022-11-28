using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Player movement
    public SpriteRenderer gameObj;
    public Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 vecGravity;

    public float runSpeed = 100f;
    public int stairs = 0;
    
    float horizontalMove = 0f;

    public Animator animator;

    // Facing left and right based on the direction of motion
    public bool isFacingLeft = false;
    public bool spawnFacingLeft = false;
    private Vector2 facingLeft;

   void Start()
    {
        gameObj = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);

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
        // Debug.Log("horizonta" + Input.GetAxisRaw("Horizontal"));
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Debug.Log("Pressed space bar");
        //     stairs = 1;
        // }

    }

    void FixedUpdate()
    {
        //Move our character
        movePlayer();

        // if(stairs == 1)
        // {
        //     float pos_x = gameObj.transform.position.x;
        //     float pos_y = gameObj.transform.position.y;
            
        //     if(pos_x > 105f && pos_x < 120f)
        //     {
        //         Vector3 newPos = new Vector3(115.5f, 15.5f, -10f);
        //         Vector3 currentPosition = gameObj.transform.position;
        //         Vector3 movePosition = Vector3.Lerp(currentPosition, newPos, 0.8f);
        //         // gameObj.transform.position = movePosition;

        //         gameObj.transform.localPosition = movePosition;
        //     }

        //     stairs = 0;   
        // }
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
        
        gameObj.transform.localPosition = new Vector3(pos_x + horizontalMove * Time.fixedDeltaTime, pos_y, 0);
    }
}
