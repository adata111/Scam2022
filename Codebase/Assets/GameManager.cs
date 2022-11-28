using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    bool isGameOver = false;
    // Where you want to end the game, write:
    // FindObjectOfType<GameManager>().EndGame();
    public void EndGame(){
        if(isGameOver){
            return;
        }
        Debug.Log("game over");
        isGameOver = true;
        // play dead detective cutscene
        SceneManager.LoadScene("GameOver");
    }

    void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
