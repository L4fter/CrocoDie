using UnityEngine;
using System.Collections;

public class CameraFollowX : MonoBehaviour
{

	public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = new Vector3(Target.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
}
