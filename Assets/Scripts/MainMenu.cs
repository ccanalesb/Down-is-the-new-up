using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string HelpLevel;
	public string mainLevel;


	public void NewGame()
	{
       Application.LoadLevel(startLevel);
	}

	public void Help()
	{
      	Application.LoadLevel(HelpLevel);
	}

 	public void OkLevel()
	{
 	 	Application.LoadLevel(mainLevel);
 	}

	public void QuitGame()
	{
		Debug.Log("Quit Game OK");
		Application.Quit();
	}


}
