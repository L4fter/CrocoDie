﻿using UnityEngine;
using System.Collections;

public class CrocoSmell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider2D)
	{
		if (collider2D.gameObject.tag == "Food")
		{
			
		}
	}
}
