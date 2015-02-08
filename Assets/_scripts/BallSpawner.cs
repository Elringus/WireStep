using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	public float SpawnFrequency;

	private void Awake () 
	{
		InvokeRepeating("Spawn", 0, SpawnFrequency);
	}

	private void Spawn ()
	{
		Ball.Initialize(transform.position, -Vector2.up * Random.Range(50, 100));
	}
}