using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private bool flashActive;
    private bool reloading;
    private float waitToLoad = 2f;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    [SerializeField]private Text keyAmount;
    
    [SerializeField] private TMP_Text lifeLeftHolder;
    private int life;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        life = PlayerPrefs.GetInt("LifeLeft");
        lifeLeftHolder.text = "Life: " + life;
    } 
       
    // Update is called once per frame
    void Update()
    {
        Debug.Log("reloading " + reloading);
        if(reloading)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(flashActive)
        {
            if(flashCounter > flashLength * 0.99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if(flashCounter > flashLength * 0.82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > flashLength * 0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if(flashCounter > flashLength * 0.49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > flashLength * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if(flashCounter > flashLength * 0.16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > flashLength * 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }

    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        // Debug.Log("Health = " + currentHealth);
        flashActive = true;
        flashCounter = flashLength;
        if(currentHealth <= 0)
        {
            reloading = true;
            gameObject.SetActive(false);
            life = PlayerPrefs.GetInt("LifeLeft");
            Debug.Log("Life = " + life);
            life -= 1;
            lifeLeftHolder.text = "Life: " + life;
            PlayerPrefs.SetInt("LifeLeft", life);
            int keysColl = keyAmount.text[6]-'0';
            FindObjectOfType<ScoreUpdate>().UpdateScore(-keysColl*100);
            if(life > 0)
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SceneManager.LoadScene("EndCutsceneLose");
            }
           
        }
    }
}
