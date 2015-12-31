using UnityEngine;
using System.Collections;


/// <summary>
/// Enemy spawner.
/// 
/// Instantiates enemy prefabs at a time interval when the player
/// is in range.
/// </summary>
public class EnemySpawner : MonoBehaviour 
{
	//How often to spawn
	public float spawnPeriod = 5.0f;

	//How close the player has to be to start spawning.
	public float activationRadius = 20.0f;	

	//How many to spawn each time.
	public int waveSize = 10;
	
	//The prefab to instantiate.
	public GameObject enemyPrefab;


	private float _spawnPeriodCounter = 0.0f;
	
	void Update () 
	{

		if (_spawnPeriodCounter < spawnPeriod) 
		{
			_spawnPeriodCounter += Time.deltaTime;
		} 
		else 
		{
			//Counter has finished so reset.
			_spawnPeriodCounter = 0;

			Vector3 playerDisplacement = this.transform.position - PlayerProperties.Position;


			//Check if player is in range.
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
		//If no prefab set then use the default one.
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
		//Draw the spawn radius in edit mode.
		var color = Color.red;
		color.a = 0.4f;
		Gizmos.color = color;
		Gizmos.DrawWireSphere (transform.position, activationRadius);
	}
}
