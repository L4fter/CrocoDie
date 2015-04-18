using UnityEngine;

public class OwnSpeedChanger : MonoBehaviour
{
	public float Delta;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		var croco = collider2D.gameObject.GetComponent<Croco>();

		if (croco != null)
		{
			croco.ApplyOwnSpeedChange(this.Delta);
		}

		this.SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);
	}
}