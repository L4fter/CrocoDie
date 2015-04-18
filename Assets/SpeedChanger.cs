using UnityEngine;

public class SpeedChanger : MonoBehaviour
{

	public float Delta;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		var croco = collider2D.gameObject.GetComponent<Croco>();

		if (croco != null)
		{
			croco.ApplySpeedChange(this.Delta);
		}

		this.SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);
	}
}