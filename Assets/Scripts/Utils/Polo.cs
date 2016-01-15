using UnityEngine;
using System.Collections;

/// <summary>
/// Play Marko Polo with unity objects!
/// 
/// Just used for testing SendMessage and BroadcastMessage to see who recieves it.
/// </summary>
public class Polo : MonoBehaviour 
{

	void Marko()
	{
		Debug.Log (gameObject.name + " Polo!");
	}
}
