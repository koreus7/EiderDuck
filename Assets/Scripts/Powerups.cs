using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Powerups : MonoBehaviour {

	public class powerup {
		public string name;
		public string description;
		public Sprite img;
		public bool available;
		
		/// <summary>
		/// Initializes a food
		/// </summary>
		/// <param name="n">Name of the food</param>
		/// <param name="a">Amount of food </param>
		/// <param name="h">Healing amount</param>
		/// <param name="e">Energy amount</param>
		/// <param name="i">The Image</param>
		public powerup(string n, string d, Sprite i, bool a) {
			name = n;
			description = d;
			img = i;
			available = a;
		}
	}
	
	public List<powerup> currentPowerups = new List<powerup>();

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
	
	void Awake () {
		currentPowerups.Add (new powerup ("aaa", "Move 10% faster", run1Img, true));
		currentPowerups.Add (new powerup ("bbb", "Move 20% faster", run2Img, true));
		currentPowerups.Add (new powerup ("ccc", "Move 30% faster", run3Img, false));
		currentPowerups.Add (new powerup ("ddd", "+10% Health", health1Img, true));
		currentPowerups.Add (new powerup ("eee", "+20% Health", health2Img, true));
		currentPowerups.Add (new powerup ("fff", "+30% Health", health3Img, false));
		currentPowerups.Add (new powerup ("ggg", "+25% Protection from Enemies", prot1Img, true));
		currentPowerups.Add (new powerup ("hhh", "+50% Protection from Enemies", prot2Img, true));
		currentPowerups.Add (new powerup ("iii", "Immortality", prot3Img, false));
		currentPowerups.Add (new powerup ("jjj", "Double Point Collection", points1Img, true));
		currentPowerups.Add (new powerup ("kkk", "Triple Point Collection", points2Img, true));
		currentPowerups.Add (new powerup ("lll", "Quadruple Point Collection", points3Img, false));
	}
	/*
	public void obtainWeapon(string name, int amount) {
		foreach (weapon w in currentWeapons) {
			if(w.name == name) {
				w.available = true;
			}
		}
	}
	
	public void Equip(string name) {
		foreach (weapon w in currentWeapons) {
			if(w.name == name) {
				if(w.available) {
					//dothingshere
					//eating food stuff goes in here, for changing the player health etc
				}
			}
		}
	}*/
}
