using UnityEngine;

public class DrawManager : MonoBehaviour
{
	public Vector2? ClickStart;
	public Vector2? ClickEnd;

	private void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
			ClickStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonUp(0)) 
		{
			ClickEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			DrawLine(); 
		}
	}

	private void DrawLine ()
	{
		if (!ClickStart.HasValue || !ClickEnd.HasValue) return;

		Line.Initialize(new Vector2[2] { ClickStart.Value, ClickEnd.Value });

		ClickStart = null;
		ClickEnd = null;
	}
}