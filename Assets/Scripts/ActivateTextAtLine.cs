using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	// allows to destroy the dialogue detection area
	// once the dialogue has been initiated
	public bool destroyWhenActivated;

	TextBoxManager textBoxManager;


	void Start () 
	{
		textBoxManager = TextBoxManager.Inst;
	}

	void Awake()
	{

	}

	void Update () 
	{
	
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

			if (destroyWhenActivated)
			{
				Destroy (gameObject);
			}
		}
	}
}
