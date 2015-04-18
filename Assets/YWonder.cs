using UnityEngine;
using System.Collections;

public class YWonder : MonoBehaviour
{
	public float Amplitude;

	public float Period;

	private float StartYPos;

	// Use this for initialization
	void Start ()
	{
		StartYPos = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var y = StartYPos + Amplitude * Mathf.Sin(Time.time * 2 * Mathf.PI / Period);
		this.transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
	}
}
