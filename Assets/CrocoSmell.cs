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
	    var tag = collider2D.gameObject.tag;
		if (tag == "Food")
		{
			var crocoAnimator = this.transform.parent.GetComponentInChildren<CrocoAnimator>();
			crocoAnimator.OpenCrocoMouth();
        }
        else if (tag == "Bomb")
        {
            var crocoAnimator = this.transform.parent.GetComponentInChildren<CrocoAnimator>();
            crocoAnimator.OpenCrocoMouth();
            crocoAnimator.Die();
            this.transform.parent.GetComponentInParent<Croco>().OwnSpeed = 0;
            GameUI.Lose(3);
        }
	}
}