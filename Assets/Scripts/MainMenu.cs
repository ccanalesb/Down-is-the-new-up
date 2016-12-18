using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string HelpLevel;
	public string mainLevel;
	public int playerLives;
	public int playerHealth;
	
	//Si creo un Level Select la mayoria de los PlayerPrefs deben empezar en el void Level Select tambien.

	public void NewGame()
	{
      
       PlayerPrefs.SetInt("PlayerCurrentLives",playerLives);
       PlayerPrefs.SetInt("CurrentPlayerScore",0);
       PlayerPrefs.SetInt("PlayerCurrentHealth",playerHealth);
       PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);
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
