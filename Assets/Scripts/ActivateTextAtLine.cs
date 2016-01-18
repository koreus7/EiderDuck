using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;



	// allows to destroy the dialogue detection area.
	// once the dialogue has been initiated.
	public bool destroyWhenActivated;

	//If this dialog should trigger an objective to be added.
	public bool assignObjective;

	//The objective to be added if assignObjective is true.
	public string objectiveName;


	TextBoxManager textBoxManager;


	void Start () 
	{
		textBoxManager = TextBoxManager.Inst;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		// finds the player's collider
		if (other.name == "Player")
		{
			textBoxManager.ReloadScript (theText);
			textBoxManager.currentLine = startLine;
			textBoxManager.endAtLine = endLine;
			textBoxManager.EnableTextBox ();

			if(assignObjective)
			{
				PlayerProperties.Player.GetComponent<Objectives>().AddObjective(objectiveName);
			}

			if (destroyWhenActivated)
			{
				Destroy (gameObject);
			}
		}
	}
}
