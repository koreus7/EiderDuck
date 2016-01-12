using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	// allows to destroy the dialogue detection area
	// once the dialogue has been initiated
	public bool destroyWhenActivated;

	public TextBoxManager theTextBox;


	void Start () 
	{
		theTextBox = FindObjectOfType<TextBoxManager> ();
	}

	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// finds the player's collider
		if (other.name == "Player")
		{
			theTextBox.ReloadScript (theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destroyWhenActivated)
			{
				Destroy (gameObject);
			}
		}
	}
}
