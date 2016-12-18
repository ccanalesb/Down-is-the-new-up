using UnityEngine;
using System.Collections;

public class TouchControlls : MonoBehaviour {

	
	private PlayerController thePlayer;
	private LevelLoader levelExit;
	private PauseMenu thePauseMenu;
	private TextBoxManager theBox;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<PlayerController>();
		levelExit = FindObjectOfType<LevelLoader>();
		thePauseMenu = FindObjectOfType<PauseMenu>();
		theBox = FindObjectOfType<TextBoxManager>();
	
	}
	
	// Update is called once per frame
	public void LeftArrow() {
	thePlayer.Move(-1);
	}

	public void RightArrow () {
	thePlayer.Move(1);
	}

	public void UnpressedArrow () {
	thePlayer.Move(0);
	}

	public void Fire () {
	thePlayer.FireGun();
	}

	public void Jump () {
	thePlayer.JumpFunction();
	if(levelExit.PlayerInZone)
	levelExit.LoadLevel();
	}

	public void Pause() {
	thePauseMenu.PauseUnpause();
	}

	public void Next(){
	theBox.NextDialog();
	}
}
