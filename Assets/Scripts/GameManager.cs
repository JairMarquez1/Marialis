using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameOver = false;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                text.SetActive(false);
                RestartGame();
            }
         }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }

}
