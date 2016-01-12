using UnityEngine;
using System.Collections;
using UnityEngine.UI; // allows to use Text type

public class TextBoxManager : MonoBehaviour {


	public TextAsset textFile; 
	// Holds text to display in a dialogue box
	public string[] textlines; 
	// Each line from the text file is taken 
	// into an array as a separate entity

	public GameObject textBox;
	public Text theText; 

	// keeps of where in the text file we are
	public int currentLine;

	// allows to check if we reach the end of the text file
	public int endAtLine;
	
	public bool isActive;

	// used to decide if we want the player's movement to halt when
	//the dialogue is initiated
	public bool stopPlayerMovement;

	CharacterMovement playerMovement;



	void Start ()

	{
		playerMovement = FindObjectOfType<CharacterMovement> ();

		// Check if the text file exists
		if (textFile != null)
		{
			textlines = (textFile.text.Split('\n'));
			// Grabs text from "Text.txt" and splits it
			// into separate pieces whenever a newline
			// is encountered
		}

		if (endAtLine == 0)
		{
			endAtLine = textlines.Length - 1;
			// Guarding against reading text out ouf bounds
			// of the .txt file

		}

		if (isActive)
		{
			EnableTextBox ();
		} 
		else
		{
			DisableTextBox();
		}
	
	}

	void Update () 
	{

		if (!isActive)
		{
			// prevents the function from running
			// if the text box isn't being shown
			return;
		}

		theText.text = textlines [currentLine];

		// if enter is pressed, move to the next part of the text
		if (Input.GetKeyDown (KeyCode.Return))
		{
			currentLine += 1;
			Debug.Log (currentLine);
		}

		// close the text box if all lines have been traversed
		if (currentLine > endAtLine)
		{
			DisableTextBox();
		}
	}

	public void EnableTextBox()
	{
		textBox.SetActive(true);
		isActive = true;

		if (stopPlayerMovement)
		{
			playerMovement.canMove = false;

		}
	}

	public void DisableTextBox()
	{
		textBox.SetActive(false);
		isActive = false;

		playerMovement.canMove = true;
	}

	public void ReloadScript(TextAsset theText)
	{

		// allows to use different text files within the game
		// for different dialogues

		if (theText != null)
		{
			// creates a fresh array holding new text
			textlines = new string[1];
			textlines = (theText.text.Split('\n'));
		}
	}

}
