using UnityEngine;

public class SimpleDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Destroy()
	{
		this.gameObject.SetActive(false);
	}
}
