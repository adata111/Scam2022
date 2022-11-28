using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class cutsceneDialogue : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject tl;

    // Start is called before the first frame update
    void Start()
    {
        director = tl.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
