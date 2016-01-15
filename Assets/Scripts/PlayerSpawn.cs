using UnityEngine;
using System.Collections;

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
