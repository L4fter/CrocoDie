using UnityEngine;
using System.Collections;

public class ScriptSwitch : MonoBehaviour
{

	public MonoBehaviour[] ToEnable;
	public MonoBehaviour[] ToDisable;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Switch()
	{
		foreach (var script in ToDisable)
		{
			script.enabled = false;
		}

		foreach (var script in ToEnable)
		{
			script.enabled = true;
		}

		var temp = ToDisable;
		ToDisable = ToEnable;
		ToEnable = temp;
	}
}
