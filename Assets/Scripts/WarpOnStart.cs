using UnityEngine;
using System.Collections;

/// <summary>
/// Warp on awake.
/// 
/// Moves the gameobject to the last set warp location
/// on awake.
/// </summary>
public class WarpOnStart : MonoBehaviour 
{
	
	void Start () 
	{
		var warpZones = FindObjectsOfType<SceneSwitcher> ();
		string lastWarpName = PlayerPrefs.GetString ("WarpName", "");

		foreach (SceneSwitcher warpZone in warpZones)
		{

			if(warpZone.gameObject.name == lastWarpName)
			{
				warpZone.gameObject.GetComponent<SceneSwitcher>().DisableForTime(0.5f);
				transform.position = warpZone.gameObject.transform.position;
			}
		}

	
	}

}
