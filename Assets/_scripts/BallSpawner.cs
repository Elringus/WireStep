using UnityEngine;
using UnityEngine.EventSystems;

public class BallSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public float AutoSpawnFrequency;
	public float MaxArrowDistance;
	public float HP = 8.3f;

	private Arrow activeArrow;
	private Transform hp;

	private void Awake () 
	{
		if (AutoSpawnFrequency > 0)
			InvokeRepeating("AutoSpawn", 0, AutoSpawnFrequency);

		hp = transform.Find("hp");
	}

	private void Update ()
	{
		hp.localScale = new Vector3(Mathf.Lerp(hp.localScale.x, HP, Time.deltaTime), hp.localScale.y, hp.localScale.z);
	}

	private void AutoSpawn ()
	{
		Ball.Initialize(transform.position - Vector3.up * .2f, new Vector2(Random.Range(-.5f, .5f), Random.Range(-1f, -.1f)) * Random.Range(50f, 200f));
	}

	private void Spawn (Vector2 force)
	{
		Ball.Initialize(transform.position + Vector3.up * .2f, force);
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		activeArrow = Arrow.Initialize(transform.position + Vector3.up * .2f);
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (!activeArrow) return;

		activeArrow.Draw(Camera.main.ScreenToWorldPoint(eventData.position));
		if (Vector2.Distance(activeArrow.StartPoint, activeArrow.EndPoint) > MaxArrowDistance)
			OnEndDrag(eventData);
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		if (!activeArrow) return;

		Spawn((activeArrow.EndPoint - activeArrow.StartPoint) * 100);

		activeArrow.Destroy();
		activeArrow = null;
	}
}