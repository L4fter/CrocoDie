using UnityEngine;
using System.Collections;

public class MenuBackAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var pos = this.gameObject.transform.position;
	    this.gameObject.transform.position = new Vector3(pos.x - 0.4f, pos.y, pos.z);
	    if (pos.x < -600)
	    {
            this.gameObject.transform.position = new Vector3(pos.x + 2200, pos.y, pos.z);
	    }
	}
}
