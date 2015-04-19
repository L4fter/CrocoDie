using UnityEngine;
using System.Collections;

public class YWonder : MonoBehaviour
{
	public float Amplitude;

	public float Period;

	private float StartYPos;

	public float Phase;

	// Use this for initialization
	void Start ()
	{
		StartYPos = transform.localPosition.y;
		Phase = Random.Range(0, 2 * Mathf.PI);
	}
	
	// Update is called once per frame
	void Update ()
	{
		var y = StartYPos + Amplitude * Mathf.Sin(Time.time * 2 * Mathf.PI / Period + Phase);
		this.transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
	}
}
