using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


	public string mainMenu;
	public bool isPaused;
	public GameObject pauseMenuCanvas;  // Lo necesitamos para activarlo y desactivarlo.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(isPaused)
		{
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
		}

		else 
		{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if(Input.GetButtonDown("Cancel"))
		{
			isPaused = !isPaused;
		}
	}



	public void MainMenu()
	{
		Application.LoadLevel(mainMenu);
	}
}
