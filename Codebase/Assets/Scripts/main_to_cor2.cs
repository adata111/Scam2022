using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_to_cor2 : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");   
    }

    // Update is called once per frame
    void Update()
    {
        // void OnTriggerEnter2D(Collider2D other)
        // {
        //     if(other.CompareTag("Player"))
        //     {
        //         Debug.Log("successful collision!!!!");
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        //     }
        // }

        float pos_x = player.transform.position.x;
        float pos_y = player.transform.position.y;

        if(pos_x > 112f && pos_y > 10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);   
        }
    }
}
