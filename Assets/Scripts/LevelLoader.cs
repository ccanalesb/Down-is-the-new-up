using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool PlayerInZone;
	public string LevelToLoad;


	// Use this for initialization
	void Start () {
	
     	PlayerInZone = false;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.UpArrow) && PlayerInZone)
		{
			Application.LoadLevel(LevelToLoad);
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			
			PlayerInZone = true;
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			PlayerInZone = false;
		}
	}


}



