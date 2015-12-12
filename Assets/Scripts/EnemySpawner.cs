using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float spawnPeriod = 5.0f;

	private float _spawnPeriodCounter = 0.0f;

	public int waveSize = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_spawnPeriodCounter < spawnPeriod) 
		{
			_spawnPeriodCounter += Time.deltaTime;
		} 
		else 
		{
			_spawnPeriodCounter = 0;

			for( int i = 0; i < waveSize; i++)
			{
				Spawn();
			}
		}

	
	}

	void Spawn ()
	{
		GameObject instance = (GameObject)Instantiate(Resources.Load("Enemy"));
		instance.transform.position = transform.position;
	}
}
