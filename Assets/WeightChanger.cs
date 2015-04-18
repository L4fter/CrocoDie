using UnityEngine;

public class WeightChanger : MonoBehaviour
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
		if (!this.enabled)
		{
			return;
		}

		var croco = collider2D.gameObject.GetComponent<Croco>();

		if (croco != null)
		{
			croco.ApplyWeightChange(this.Delta);
			this.SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);
		}

	}
}