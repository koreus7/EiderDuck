using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {
		
	public GameObject[] weapons;
	
	string _selectedWeaponName = "Sword";
	
	int _selectedWeaponIndex = 0;

	void Awake()
	{
		//See if we saved our selected weapon
		if (PlayerPrefs.HasKey ("SelectedWeapon"))
		{
			_selectedWeaponName = PlayerPrefs.GetString("SelectedWeapon");
		}

		//Now the name is set we need to enable the weapon with that name.
		RefreshActiveWeapons ();
	}

	void RefreshActiveWeapons()
	{
		for (int i = 0; i < weapons.Length; i++)
		{
			bool isSelectedWeapon = weapons[i].name == _selectedWeaponName;

			weapons[i].SetActive(isSelectedWeapon);

			if(isSelectedWeapon)
			{
				_selectedWeaponIndex = i;
			}
		}
	}


	void Update () 
	{
		if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
		{
			SelectNextWeapon();
		}
		if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
		{
			SelectPreviousWeapon();
		}   
	}

	void SelectNextWeapon()
	{
		SelectWeaponIndex (_selectedWeaponIndex + 1);
	}

	void SelectPreviousWeapon()
	{
		SelectWeaponIndex (_selectedWeaponIndex - 1);
	}

	void SelectWeaponIndex(int i)
	{
		if( i < 0)
		{
			//Wrap from bottom to top.
			SelectWeaponIndex(weapons.Length - 1);
		}
		else if (i > weapons.Length - 1)
		{
			//Wrap from top to bottom.
			SelectWeaponIndex(0);
		} 
		else
		{
			//Valid index so just set it.
			_selectedWeaponIndex = i;
			_selectedWeaponName  =  weapons[i].name;
			Debug.Log("Selected " + _selectedWeaponName);
			RefreshActiveWeapons ();	
		}
	}


	public void SceneSwitch()
	{
		PlayerPrefs.SetString("SelectedWeapon", _selectedWeaponName);
	}
}
