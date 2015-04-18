using UnityEngine;
using System.Collections;

public class Birdy : MonoBehaviour
{
	public bool IsAlive;

	public float DropDeadTime = 0.5f;

	public MoveForward Mover;

	public ScriptSwitch FlyToFallSwitch;

	public FallDown FallDown;

	public MonoBehaviour[] Feeders;

	// Use this for initialization
	void Start ()
	{
		FallDown.Time = DropDeadTime;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DropDead()
	{
		if (!IsAlive)
		{
			return;
		}

		Mover.Speed = Random.Range(5/DropDeadTime, 10/DropDeadTime);
		this.GetComponentInChildren<Animator>().enabled = false;
		FlyToFallSwitch.Switch();
		LeanTween.delayedCall(gameObject, DropDeadTime, TurnOffMover);
		this.transform.GetChild(0).tag = "Food";
		IsAlive = false;
	}

	private void TurnOffMover()
	{
		this.IsDown = true;
		this.Mover.enabled = false;
		foreach (var monoBehaviour in this.Feeders)
		{
			monoBehaviour.enabled = true;
		}
	}

	public bool IsDown { get; set; }
}
