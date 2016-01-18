﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Powerups.
/// Manages the powerups the player has enabled.
/// </summary>
public class Powerups : MonoBehaviour 
{

	public List<Powerup> allPowerups = new List<Powerup> ();
	public List<Powerup> enabledPowerups = new List<Powerup>();

	public Sprite run1Img;
	public Sprite run2Img;
	public Sprite run3Img;
	public Sprite health1Img;
	public Sprite health2Img;
	public Sprite health3Img;
	public Sprite prot1Img;
	public Sprite prot2Img;
	public Sprite prot3Img;
	public Sprite points1Img;
	public Sprite points2Img;
	public Sprite points3Img;
	
	void Awake () 
	{
		allPowerups.Add (new MovementPowerup ("mv1", "Move 10% faster", run1Img, false, 1.1f));
		allPowerups.Add (new MovementPowerup ("mv2", "Move 20% faster", run2Img, false, 1.2f));
		allPowerups.Add (new MovementPowerup ("mv3", "Move 30% faster", run3Img, false, 1.3f));
		allPowerups.Add (new Powerup ("hp1", "+10% Health", health1Img, false));
		allPowerups.Add (new Powerup ("hp2", "+20% Health", health2Img, false));
		allPowerups.Add (new Powerup ("hp3", "+30% Health", health3Img, false));
		allPowerups.Add (new Powerup ("pe2", "+25% Protection from Enemies", prot1Img, false));
		allPowerups.Add (new Powerup ("pe5", "+50% Protection from Enemies", prot2Img, false));
		allPowerups.Add (new Powerup ("imo", "Immortality", prot3Img, false));
		allPowerups.Add (new Powerup ("dbl", "Double Point Collection", points1Img, false));
		allPowerups.Add (new Powerup ("trp", "Triple Point Collection", points2Img, false));
		allPowerups.Add (new Powerup ("qua", "Quadruple Point Collection", points3Img, false));
	}

	public void EnablePowerup(string name)
	{
		var powerup = FindPowerup (name);
		powerup.available = true;
		powerup.Enabled (PlayerProperties.Player);
		enabledPowerups.Add (powerup);
	}

	public void DisablePowerup(string name)
	{
		var powerup = FindPowerup (name);
		powerup.available = false;
		powerup.Disabled (PlayerProperties.Player);
		enabledPowerups.Remove(powerup);
	}

	public Powerup FindPowerup(string name)
	{
		foreach (Powerup p in allPowerups)
		{
			if(p.name == name)
			{
				return p;
			}
		}

		Debug.LogError ("Powerup " + name + " does not exist");
		return allPowerups[0];
	}

	void Update()
	{
		foreach (Powerup p in enabledPowerups)
		{
			p.PlayerUpdate(PlayerProperties.Player);
		}
	}
}
