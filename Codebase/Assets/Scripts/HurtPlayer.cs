using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private float waitToHurt = 2f;
    private bool isTouching;
    private HealthManager healthMan;
    [SerializeField] private int damageToGive = 10;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(reloading)
        // {
        //     waitToLoad -= Time.fixedDeltaTime;
        //     if(waitToLoad <= 0)
        //     {
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //     }
        // }

        if(isTouching)
        {
            waitToHurt -= Time.fixedDeltaTime;
            if(waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            // other.gameObject.SetActive(false);
            // reloading = true;
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
             isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
             isTouching = false;
             waitToHurt = 2f;
        }
    }
}
