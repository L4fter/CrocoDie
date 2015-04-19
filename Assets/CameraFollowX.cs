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
	void LateUpdate ()
	{
		var target = new Vector3(this.Target.transform.position.x + this.offset, this.transform.position.y, this.transform.position.z);
		this.transform.position = Vector3.Lerp(this.transform.position, target, 0.3f);
	}
}
