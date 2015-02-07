using UnityEngine;

public class DrawManager : MonoBehaviour
{
	public Vector2? LineStart;
	public Vector2? LineEnd;

	private LineRenderer line;

	private void Awake () 
	{
		line = FindObjectOfType<LineRenderer>();
	}

	private void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
			LineStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonUp(0)) 
		{
			LineEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			DrawLine(); 
		}
	}

	private void DrawLine ()
	{
		if (!LineStart.HasValue || !LineEnd.HasValue) return;

		line.SetPosition(0, LineStart.Value);
		line.SetPosition(1, LineEnd.Value);

		//LineStart = null;
		//LineEnd = null;
	}
}