using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrocoBody : MonoBehaviour
{
	public GameObject HeadObject;

	public GameObject TailObject;

	public List<GameObject> BodyObjects;

	public Vector3 OnePartOffset;

	public Sprite Head;

	public Sprite BodyPart;

	public Sprite Tail;

	private GameObject bodyObject;

	// Use this for initialization
	void Start ()
	{
		bodyObject = BodyObjects[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPart()
	{
		var lastBodyObject = BodyObjects[BodyObjects.Count - 1];
//		Instantiate(bodyObject, BodyObjects)
	}

	public void RemovePart()
	{
		if (this.BodyObjects.Count == 1)
		{
			return;
		}


	}
}
