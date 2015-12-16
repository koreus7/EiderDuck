using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float spawnPeriod = 5.0f;

	private float _spawnPeriodCounter = 0.0f;

	public float activationRadius = 20.0f;	

	public int waveSize = 10;

	public GameObject enemyPrefab;
	

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

			Vector3 playerDisplacement = this.transform.position - PlayerProperties.Position;

			if(playerDisplacement.magnitude < activationRadius)
			{
				SpawnWave();
			}
		}

	
	}

	void SpawnWave()
	{
		for( int i = 0; i < waveSize; i++)
		{
			SpawnOne();
		}
	}

	void SpawnOne ()
	{
		if (enemyPrefab == null)
		{
			GameObject instance = (GameObject)Instantiate (Resources.Load ("Enemy"));
			instance.transform.position = this.transform.position;
			instance.transform.parent = this.transform;
		} 
		else
		{
			Instantiate (enemyPrefab, transform.position, transform.rotation);
		}

	}

	void OnDrawGizmos()
	{
		var color = Color.red;
		color.a = 0.4f;
		Gizmos.color = color;
		Gizmos.DrawWireSphere (transform.position, activationRadius);
	}
}
