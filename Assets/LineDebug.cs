using UnityEngine;

public class LineDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine(this.transform.position, this.transform.position + new Vector3(200, 0));
	}
}
