using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject nuevo;

	public void StartLevel(string scene){
		SceneManager.LoadScene(scene);
		Time.timeScale = 1f;
	}

	public void Quit()
	{
		Application.Quit();
	}
}
