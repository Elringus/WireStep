using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	public float AutoSpawnFrequency;

	private void Awake () 
	{
		if (AutoSpawnFrequency > 0)
			InvokeRepeating("AutoSpawn", 0, AutoSpawnFrequency);
	}

	private void AutoSpawn ()
	{
		Ball.Initialize(transform.position, -Vector2.up * Random.Range(50, 100));
	}
}