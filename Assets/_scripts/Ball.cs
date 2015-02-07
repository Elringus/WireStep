using UnityEngine;

public class Ball : MonoBehaviour
{
	private const float LINE_WIDTH = .05f;

	private DrawManager drawManager;

	private void Awake ()
	{
		drawManager = FindObjectOfType<DrawManager>();
	}

	private void Update ()
	{
		if (drawManager.LineEnd.HasValue && drawManager.LineStart.HasValue)
			print(LineContainsPoint(new Vector2[2] { drawManager.LineStart.Value, drawManager.LineEnd.Value }, Camera.main.ScreenToWorldPoint(Input.mousePosition)));
	}

	private bool LineContainsPoint (Vector2[] line, Vector2 point)
	{
		if (Vector3.Cross(line[1] - line[0], point - line[0]).sqrMagnitude > LINE_WIDTH) return false;

		float dot = Vector2.Dot(line[1] - line[0], point - line[0]);
		if (dot < 0) return false;

		if (dot > Mathf.Pow(Vector2.Distance(line[0], line[1]), 2)) return false;

		return true;
	}
}