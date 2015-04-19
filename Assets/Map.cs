using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Map : MonoBehaviour
{
	public GameObject[] Lines;

	public float GetUpperLineY(float myY)
	{
		int level = 0;
		return GetUpperLineY(myY, ref level);
	}

	public float GetUpperLineY(float myY, ref int level)
	{
		var objects = this.Lines.Where(o => o.transform.position.y > myY + 0.01f).ToList();
		if (!objects.Any())
		{
			return myY;
		}

		var nextLine = objects.Min((o => o.transform.position.y));
		return Mathf.Max(nextLine, myY);
	}

	public float GetLowerLineY(float myY)
	{
		var objects = this.Lines.Where(o => o.transform.position.y < myY - 0.01f).ToList();
		if (!objects.Any())
		{
			return myY;
		}

		var nextLine = objects.Max((o => o.transform.position.y));
		return Mathf.Min(nextLine, myY);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
