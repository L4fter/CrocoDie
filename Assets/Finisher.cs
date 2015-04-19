using UnityEngine;

public class Finisher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision2D)
	{
		if (collision2D.gameObject.tag == "PlayerCroco")
		{
			Debug.Log("FINISH");
			GameController.Instance.FuckingWin(0);
		}
	}
}
