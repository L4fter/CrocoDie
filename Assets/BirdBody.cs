using UnityEngine;
using System.Collections;

public class BirdBody : MonoBehaviour
{

	public Birdy Birdy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Weapon" &&
			collider.enabled)
		{
			Birdy.DropDead();
		}
	}
}
