using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endWinScene : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pos_x = player.transform.position.x;
        float pos_y = player.transform.position.y;

        if(pos_x > 23f)
        {
            SceneManager.LoadScene("EndCutsceneWin");
        }
    }
}
