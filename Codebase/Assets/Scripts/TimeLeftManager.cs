using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeLeftManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeLeftHolder;
    public GameObject timeUpUI;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetFloat("timeLeft", 10);
        // timeLeftHolder = GetComponent<TMP_Text>();
        timeLeft = PlayerPrefs.GetFloat("timeLeft");
        Debug.Log(timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        // string timeLeftString = timeLeftHolder.text;
        // float timeLeft = 0.0f;
        // // timeLeftString = "Time Left: %%%%"
        // for (int i = 10; i < timeLeftString.Length; i++){
        //     if (Char.IsDigit(timeLeftString[i])){
        //        timeLeft *= 10;
        //        timeLeft += timeLeftString[i]-'0';
        //     }
        // }
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0){
            timeLeft = 0;
            timeLeftHolder.text = "Time Left: " + Mathf.Round(timeLeft);
            StartCoroutine(showTimeUpText());
            
        }
        timeLeftHolder.text = "Time Left: " + Mathf.Round(timeLeft);
        PlayerPrefs.SetFloat("timeLeft", timeLeft);
    }

    IEnumerator showTimeUpText(){
        timeUpUI.SetActive(true);
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        // yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndCutsceneLose");
        // FindObjectOfType<GameManager>().EndGame();
    }
}
