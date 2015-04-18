﻿using UnityEngine;

public class Coconut : MonoBehaviour
{
	public bool IsReflected;
	public Vector3 Speed;

	public void Launch(Vector3 speed)
	{
		this.Speed = speed;
	}

	public void Update()
	{
		this.transform.position += this.Speed * Time.deltaTime;
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Shield")
		{
			this.ReflectFromCollider(collider);
			IsReflected = true;
		}

		if (IsReflected)
		{
			return;
		}

		if (collider.gameObject.tag == "Head")
		{
			collider.gameObject.SendMessageUpwards("KickToHead", SendMessageOptions.RequireReceiver);
		}
	}


	private void ReflectFromCollider(Collider2D collider)
	{
		var dirToObject = collider.transform.position - this.transform.position;
		dirToObject.Normalize();

		this.Speed = Vector3.Reflect(this.Speed, -dirToObject) + new Vector3(2, 0);
	}
}