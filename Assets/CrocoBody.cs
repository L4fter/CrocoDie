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
		var newPart = Instantiate(this.bodyObject);
		newPart.transform.parent = this.transform;
		newPart.transform.localPosition = lastBodyPart.transform.localPosition;
		this.BodyParts.Add(newPart);

		LeanTween.cancel(newPart);
		LeanTween.moveLocal(newPart, newPart.transform.localPosition + this.OnePartOffset, 0.2f);
		LeanTween.cancel(this.TailObject);
		LeanTween.moveLocal(this.TailObject, newPart.transform.localPosition + this.OnePartOffset*2, 0.2f);
	}

	public void RemovePart()
	{
		if (this.BodyParts.Count < 2)
		{
			return;
		}

		var lastBodyPart = this.BodyParts[this.BodyParts.Count - 1];
		LeanTween.cancel(this.TailObject);
		LeanTween.moveLocal(this.TailObject, lastBodyPart.transform.localPosition, 0.1f);
		this.BodyParts.RemoveAt(this.BodyParts.Count - 1);
		Destroy(lastBodyPart, 0.15f);
	}
}
