using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Objectives : MonoBehaviour 
{
	public Dictionary<string, bool> objectiveMap  { get; private set;}




	public Objectives()
	{
		objectiveMap = new Dictionary<string, bool>();
	}


	public void AddObjective(string name)
	{
		if (!objectiveMap.ContainsKey (name))
		{
			objectiveMap.Add (name, false);
		}
	}


	public void CompleteObjective(string name)
	{
		if(objectiveMap.ContainsKey(name))
		{
			objectiveMap[name] = true;
		}
	}
}
