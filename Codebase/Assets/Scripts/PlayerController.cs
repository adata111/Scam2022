using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myRD;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        myRD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRD.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        Debug.Log(myRD.velocity);
    }
}
