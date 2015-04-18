using UnityEngine;
using System.Collections;

public class CircleGizmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawSphere(this.transform.position, 0.3f);
	}
}
