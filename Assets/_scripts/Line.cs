using UnityEngine;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
	public const float LINE_WIDTH = .05f;

	public static List<Line> ActiveLines = new List<Line>();

	[HideInInspector]
	public Vector2[] Points;
	[HideInInspector]
	public float LiveTime;

	private void Start ()
	{
		Invoke("Destroy", LiveTime);
	}

	private void Update () 
	{
		foreach (var ball in Ball.ActiveBalls)
			if (ContainsPoint(ball.transform.position))
			{
				ball.rigidbody2D.AddForce(Vector2.up * 100);
				Destroy();
			}
	}

	public static void Initialize (Vector2[] points, float liveTime = .25f)
	{
		var newLine = (GameObject.Instantiate(Resources.Load<GameObject>("line")) as GameObject).GetComponent<Line>();

		newLine.Points = points;

		newLine.GetComponent<LineRenderer>().SetPosition(0, points[0]);
		newLine.GetComponent<LineRenderer>().SetPosition(1, points[1]);

		newLine.LiveTime = liveTime;

		ActiveLines.Add(newLine);
	}

	private void Destroy ()
	{
		ActiveLines.Remove(this);
		Destroy(gameObject);
	}

	private bool ContainsPoint (Vector2 point)
	{
		if (Vector3.Cross(Points[1] - Points[0], point - Points[0]).sqrMagnitude > LINE_WIDTH) return false;

		float dot = Vector2.Dot(Points[1] - Points[0], point - Points[0]);
		if (dot < 0) return false;

		if (dot > Mathf.Pow(Vector2.Distance(Points[0], Points[1]), 2)) return false;

		return true;
	}
}