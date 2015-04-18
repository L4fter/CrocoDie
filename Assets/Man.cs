using UnityEngine;

public class Man : MonoBehaviour
{
	public Croco MyCroco;

	public float RowDeltaSpeed;

	public float Health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LowKick()
	{
		this.Row();
	}

	public void MidKick()
	{
		
	}

	public void HighKick()
	{
		
	}

	public void Row()
	{
		this.MyCroco.ApplySpeedChange(this.RowDeltaSpeed);
	}
}
