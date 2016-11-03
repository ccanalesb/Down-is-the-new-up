using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {

	
	public int startingLives;
	private int liveCounter;
	private Text theText;
	public GameObject gameOver;
	public PlayerController player;
	public string mainMenu;
	public float waitAfterGameOver;



	// Use this for initialization
	void Start () {

		theText = GetComponent<Text>();
		liveCounter = startingLives;
		player = FindObjectOfType<PlayerController>();
		
	
	}
	
	// Update is called once per frame
	void Update () {

		if(liveCounter < 0)
		{
			gameOver.SetActive(true);
			player.gameObject.SetActive(false);
		}

		theText.text = "x" + liveCounter;

		if(gameOver.activeSelf)
		{
			waitAfterGameOver -= Time.deltaTime;
		}

		if(waitAfterGameOver < 0)
		{
			Application.LoadLevel(mainMenu);
		}
	
	}

	public void GiveLive()
	{
		liveCounter++;
	}

	public void TakeLive()
	{
		liveCounter--;
	}
}
