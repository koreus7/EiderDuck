using UnityEngine;
using System.Collections;


/// <summary>
/// Player spawn.
/// 
/// Instantiates the player and then makes the camera follow the player.
/// </summary>
public class PlayerSpawn : MonoBehaviour 
{
	public GameObject cameraContainer;

	void Start ()
	{
		GameObject player = (GameObject)Instantiate (Resources.Load ("Player"),this.transform.position,this.transform.rotation);
		player.name = "Player";

		cameraContainer.BroadcastMessage ("SetTarget", player.transform);

	}

}
