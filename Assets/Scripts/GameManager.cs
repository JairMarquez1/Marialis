using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gamePausedScreen;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

         if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    public void Pause()
    {
        if (Time.timeScale == 1f){
            Time.timeScale = 0f;
            gamePausedScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            gamePausedScreen.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Exit()
    {
       SceneManager.LoadScene("Menu");
    }
}
