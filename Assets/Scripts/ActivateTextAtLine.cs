using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour
{

	public TextAsset theText;

	public int startLine;
	public int endLine;



	// allows to destroy the dialogue detection area.
	// once the dialogue has been initiated.
	public bool destroyWhenActivated;

	//If this dialog should trigger an objective to be added.
	public bool assignObjective;

	//The objective to be added if assignObjective is true.
	public string asignObjectiveName;

	//If we complete an objective by having this dialog.
	public bool completeObjective;

	//The objective to be completed if comleteObjective is true.
	public string completeObjectiveName;


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

			var objectives = PlayerProperties.Player.GetComponent<Objectives> ();
			if(assignObjective)
			{
				objectives.AddObjective(asignObjectiveName);


				FloatingTextManager.MakeFloatingText (transform, "Objective Get!", Color.white);
			}

			if (completeObjective)
			{
				objectives.CompleteObjective (completeObjectiveName);

				FloatingTextManager.MakeFloatingText (transform, "Objective Complete!", Color.green);
			}

			if (destroyWhenActivated)
			{
				Destroy (gameObject);
			}
		}
	}
}
