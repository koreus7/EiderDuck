using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour {
	
	public GameObject menuPanel;
	public GameObject backpackPanel;
	public GameObject settingsPanel;
	public Slider volumeSlider;
	bool menuOpen = false;
	bool backpackOpen = false;
	bool settingsOpen = false;

	//Food
	public Food food;
	public Text nameText;
	public Text energyText;
	public Text healthText;
	public Text amountText;
	public Image foodImage;
	
	int currentFoodIndex = 0;

	// Use this for initialization
	void Start () {
		updateFoodUI ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetButtonDown ("Menu")) {
			if (menuOpen == false) {
				openMenuPanel ();
			} else {
				closeMenuPanel();
			}
		}
	}

	public void openMenuPanel() {
		menuPanel.SetActive (true);
		menuOpen = true;
		Time.timeScale = 0.00001f;

	}
	public void closeMenuPanel() {
		menuPanel.SetActive (false);
		menuOpen = false;
		closeBackpack ();
		closeSettings ();
		Time.timeScale = 1;

	}
	public void openBackpack(){
		backpackPanel.SetActive (true);
		backpackOpen = true;
		closeSettings ();
	}
	public void closeBackpack(){
		backpackPanel.SetActive (false);
		backpackOpen = false;

	}
	public void openSettings() {
		settingsPanel.SetActive (true);
		settingsOpen = true;
		closeBackpack ();
	}
	public void closeSettings(){
		settingsPanel.SetActive (false);
		settingsOpen = false;
	}
	public void volumeChanged(){
		foreach (AudioSource audios in GameObject.FindObjectsOfType<AudioSource>()) {
			audios.volume = volumeSlider.value;
		}
	}
	public void exitGame () {
		Application.Quit ();
	}
	public void nextFood() {
		currentFoodIndex += 1;
		if (currentFoodIndex > food.currentFoods.Count -1) {
			currentFoodIndex = food.currentFoods.Count-1;
		}
		updateFoodUI ();
	}
	public void prevFood() {
		currentFoodIndex -= 1;
		if (currentFoodIndex < 0) {
			currentFoodIndex = 0;
		}
		updateFoodUI ();
	}
	
	void updateFoodUI() {
		nameText.text = food.currentFoods [currentFoodIndex].name;
		energyText.text = "Energy: " + food.currentFoods [currentFoodIndex].energy.ToString ();
		healthText.text = "Health: " + food.currentFoods [currentFoodIndex].healAmount.ToString ();
		amountText.text = "X" + food.currentFoods [currentFoodIndex].amount.ToString ();
		foodImage.sprite = food.currentFoods [currentFoodIndex].img;
	}

	public void eatFood() {
		food.Eat (food.currentFoods [currentFoodIndex].name);
		updateFoodUI ();
	}

}
	