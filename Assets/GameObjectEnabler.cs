using UnityEngine;
using System.Collections;

public class GameObjectEnabler : MonoBehaviour
{
	public GameObject ToEnable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable()
	{
		ToEnable.SetActive(true);
	}
}
