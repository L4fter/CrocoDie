using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerKicker : MonoBehaviour
{

	private List<GameObject> shields = new List<GameObject>(); 
	private List<GameObject> heads = new List<GameObject>(); 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Shield")
		{
			shields.Add(collider.transform.parent.gameObject);
			return;
		}

		if (collider.transform.parent != this.transform.parent)
		{
			if (collider.gameObject.tag == "Head")
			{
				heads.Add(collider.transform.parent.gameObject);
			}
		}
	}

	public void OnEnable()
	{
		shields.Clear();
		heads.Clear();
	}

	public void OnDisable()
	{
		foreach (var head in heads)
		{
			if (!shields.Contains(head))
			{
				head.gameObject.SendMessage("KickToHead", SendMessageOptions.RequireReceiver);
			}
		}
	}
}
