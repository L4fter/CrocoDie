using UnityEngine;

public class CrocoController : MonoBehaviour
{
	public Croco Croco;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.CheckInput();
	}

	private void CheckInput()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.Croco.Move(Direction.Down);
			return;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.Croco.Move(Direction.Up);
		}
	}

}