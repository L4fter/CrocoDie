using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{

	public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(this.Speed, 0) * Time.deltaTime;
	}
}
