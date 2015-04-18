using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrocoBody : MonoBehaviour
{
	public GameObject HeadObject;

	public GameObject TailObject;

	public List<GameObject> BodyParts;

	public Vector3 OnePartOffset;

	public Sprite Head;

	public Sprite BodyPart;

	public Sprite Tail;

	private GameObject bodyObject;

	private Vector3 tailPosition;

	// Use this for initialization
	void Start ()
	{
		bodyObject = this.BodyParts[0];
		tailPosition = TailObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPart()
	{
		var lastBodyPart = this.BodyParts[this.BodyParts.Count - 1];
		var newPart = Instantiate(this.bodyObject) as GameObject;
		newPart.transform.parent = this.transform;
		newPart.transform.localPosition = lastBodyPart.transform.localPosition;
		BodyParts.Add(newPart);

		LeanTween.moveLocal(newPart, newPart.transform.localPosition + this.OnePartOffset, 0.2f);
		LeanTween.moveLocal(this.TailObject, this.tailPosition + this.OnePartOffset, 0.2f);
		this.tailPosition += this.OnePartOffset;
	}

	public void RemovePart()
	{
		if (this.BodyParts.Count == 1)
		{
			return;
		}


	}
}
