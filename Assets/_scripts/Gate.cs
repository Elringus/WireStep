using UnityEngine;

public class Gate : MonoBehaviour
{
	private BallSpawner spawner;

	private void Awake ()
	{
		spawner = transform.parent.parent.GetComponent<BallSpawner>();
	}

	private void OnCollisionEnter2D (Collision2D colli)
	{
		if (colli.gameObject.tag == "Ball")
		{
			colli.gameObject.GetComponent<Ball>().Destroy();
			spawner.HP *= .9f;
		}
	}
}