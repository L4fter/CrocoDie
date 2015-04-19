using UnityEngine;
using System.Collections;

public class Rage : MonoBehaviour
{
	public GameObject Enemy;
	
	public Vector3 Target;

	public bool IsRaging;

	public float RageDistance;

	// Use this for initialization
	void Start ()
	{
		var men = FindObjectsOfType<Man>();
		Enemy = men[Random.Range(0, men.Length)].gameObject;
	}

	// Update is called once per frame
	void Update () {

		if (IsRaging)
		{
			return;
		}

		if (Enemy == null || !Enemy)
		{
			return;
		}

		if (Enemy.transform.position.x > this.transform.position.x)
		{
			return;
		}

		if ((Enemy.transform.position - this.transform.position).magnitude < RageDistance)
		{
			//Offset to head
			EnableRaging(new Vector3(Random.Range(0.5f, 1f), Random.Range(0.7f, 1f)));
		}
	}

	private void EnableRaging(Vector3 offset)
	{
		IsRaging = true;
		var idealPosition = Enemy.transform.position;
		Target = idealPosition + offset;
		var dir = Target - this.transform.position;
		Target += dir * 3;

		LeanTween.move(this.gameObject, Target, 6f).setDelay(0.0f).setEase(LeanTweenType.linear).setOrientToPath(true);
	}

	public void OnDisable()
	{
		LeanTween.cancel(this.gameObject);
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("Collides");
		if (collider.gameObject.tag == "Head")
		{
			Debug.Log("Collides head");
			collider.gameObject.SendMessageUpwards("KickToHead", SendMessageOptions.RequireReceiver);
		}
	}
}
