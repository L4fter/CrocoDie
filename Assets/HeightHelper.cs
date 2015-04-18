using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Messaging;

public class HeightHelper : MonoBehaviour
{

	public GameObject BirdBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		var position = this.transform.position;
		var from = new Vector3(position.x - 0.1f, position.y + 0.01f);
		var to = new Vector3(position.x + 0.1f, position.y + 0.01f);

		var color = Gizmos.color;
		Gizmos.color = new Color32(200, 0, 200, 255);
		Gizmos.DrawLine(from, to);
		Gizmos.DrawLine(position, this.BirdBody.transform.position);
		Gizmos.color = color;
	}
}
