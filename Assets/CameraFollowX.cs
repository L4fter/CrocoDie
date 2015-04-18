using UnityEngine;
using System.Collections;

public class CameraFollowX : MonoBehaviour
{

	public GameObject Target;

    private float offset;

	// Use this for initialization
	void Start ()
	{
	    offset = transform.position.x - Target.transform.position.x;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = new Vector3(Target.transform.position.x + offset, this.transform.position.y, this.transform.position.z);
	}
}
