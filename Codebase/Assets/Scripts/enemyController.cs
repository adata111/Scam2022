using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private Transform target;
    public Transform homePos;
    private bool hitWall;
    [SerializeField] private float speed;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<final_move>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        // else
        // {
        //     GoHome();
        // }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
    }
    // public void GoHome()
    // {
    //     if(hitWall)
    //     {
            
    //     }
    //     else
    //     {
    //         transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.fixedDeltaTime);
    //     }
        
    // }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.collider.tag == "Walls")
    //     {
    //         hitWall = true;
    //     }
    // }
}
