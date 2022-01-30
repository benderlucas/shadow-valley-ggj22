using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject PauseScreen;
    public GameObject GameOverScreen;

    void Start(){
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        GetComponent<SceneChange>().enabled = true;
    }

    void Update(){
        if (Input.GetKeyDown ("escape")) {
            if (!isPaused){
                PauseGame();
            } else {
                unPauseGame();
            }
        }
    }

    public void PauseGame(){
        isPaused = true;
        GetComponent<SceneChange>().enabled = false;
        PauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void unPauseGame(){
        isPaused = false;
        GetComponent<SceneChange>().enabled = true;
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver(){
        if (this.GetComponent<SceneChange>().sceneAliveActive){
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        } else {
            return;
        }
    }

    public void ResetGame(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
