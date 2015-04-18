using UnityEngine;

public class CrocoSmell : MonoBehaviour
{
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
		if (collider2D.gameObject.tag == "Food")
		{
			var crocoAnimator = this.transform.parent.GetComponentInChildren<CrocoAnimator>();
			crocoAnimator.OpenCrocoMouth();
		}
	}
}