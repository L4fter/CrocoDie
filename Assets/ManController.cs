using UnityEngine;

public class ManController : MonoBehaviour
{
	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
		this.CheckInput();
	}

	private void CheckInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.SendMessage("LowKick");
		} else if (Input.GetKeyDown(KeyCode.Return))
		{
		    this.SendMessage("HighKick");
		}
	}
}