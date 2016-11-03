﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	
	public GameObject textBox;
	public Text theText;


	public TextAsset textFile;
	public string[] textLines;
	public int currentLine;
	public int endAtLine;
	public PlayerController player;

	public bool isActive;
	

	

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController>();
	
		if(textFile != null)
		{
			textLines = (textFile.text.Split('\n'));
		}
		if(endAtLine == 0)
		{
			endAtLine = textLines.Length - 1;
		}

		if(isActive)
		{
			EnableTextBox();

		}
		else
		{
			DisableTextBox();
		}

	}

	
	// Update is called once per frame
	void Update () {
	

		if(!isActive)
		{
			return;
		}


		theText.text =  textLines[currentLine];

		if(Input.GetButtonDown("Next"))
		{
			currentLine += 1;
		}

		if(currentLine > endAtLine)
		{
			DisableTextBox();
		}


	}

	public void EnableTextBox()
	{
		textBox.SetActive(true);
		isActive = true;
		

		



		
	}

	public void DisableTextBox()
	{
			textBox.SetActive(false);
			isActive = false;
			
			
			
	}

	public void ReloadScript(TextAsset theText)
	{
		if(theText != null)
		{
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));

		}
	}
}
