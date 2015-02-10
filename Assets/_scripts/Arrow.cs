using UnityEngine;

public class Arrow : MonoBehaviour
{
	[HideInInspector]
	public Vector2 StartPoint;
	[HideInInspector]
	public Vector2 EndPoint;

	private Transform head;
	private Transform body;

	private void Awake ()
	{
		head = transform.Find("head");
		body = transform.Find("body");
	}

	public void Draw (Vector2 endPoint)
	{
		EndPoint = endPoint;

		head.position = EndPoint;
		head.rotation = Quaternion.Euler(new Vector3(0, 0, GetAngle(StartPoint, EndPoint)));
		body.position = GetMidPoint(StartPoint, EndPoint);
		body.rotation = Quaternion.Euler(new Vector3(0, 0, GetAngle(StartPoint, EndPoint)));
		body.localScale = new Vector2(body.localScale.x, Vector2.Distance(StartPoint, EndPoint) * 14);
	}

	public static Arrow Initialize (Vector2 startPoint)
	{
		var newArrow = (Instantiate(Resources.Load<GameObject>("arrow")) as GameObject).GetComponent<Arrow>();
		newArrow.transform.position = startPoint;
		newArrow.StartPoint = startPoint;

		return newArrow;
	}

	public void Destroy ()
	{
		Destroy(gameObject);
	}

	private float GetAngle (Vector2 startPoint, Vector2 endPoint)
	{
		var deltaX = endPoint.x - startPoint.x;
		var deltaY = endPoint.y - startPoint.y;
		return Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg - 90;
	}

	private Vector2 GetMidPoint (Vector2 startPoint, Vector2 endPoint)
	{
		return new Vector2((startPoint.x + endPoint.x) / 2, (startPoint.y + endPoint.y) / 2);
	}
}