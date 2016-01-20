using UnityEngine;
using System.Collections;

/// <summary>
/// Add objective on start.
/// 
/// </summary>
public class AddObjectiveOnStart : MonoBehaviour 
{

	public string name;


	void Start ()
	{
		Objectives.Inst.AddObjective (name);
	}
}
