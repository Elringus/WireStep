using UnityEngine;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
	public static List<Ball> ActiveBalls = new List<Ball>();

	public static void Initialize (Vector2 position, Vector2 force)
	{
		var newBall = (GameObject.Instantiate(Resources.Load<GameObject>("ball")) as GameObject).GetComponent<Ball>();
		newBall.transform.position = position;
		newBall.rigidbody2D.AddForce(force);

		ActiveBalls.Add(newBall);
	}

	private void Destroy ()
	{
		ActiveBalls.Remove(this);
		Destroy(gameObject);
	}
}