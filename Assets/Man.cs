﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Man : MonoBehaviour
{
	public Croco MyCroco;

	public float RowDeltaSpeed;

	public float Health;

	private bool isKicking;

    public Action CurrentAction { get; private set;}

	public Collider2D[] WeaponColliders;

    private GameController game;

	public GameObject BloodPrefab;

	public GameObject Head;

	public enum Action { LowKick = 1, MidKick = 2, HighKick = 3, Idle = 4}

	public PlayerKicker HihgKickKicker; 
	public Collider2D HihgKickCollider; 
	public Collider2D WeaponCollider; 

    
	// Use this for initialization
	void Start () {
        game = GameController.Instance;
        CurrentAction = Action.Idle;
        if (!game.PlayerControlsMan)
        {
            Destroy(this.GetComponent<ManController>());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LowKick()
	{
		if (isKicking)
		{
			return;
		}

        this.CurrentAction = Action.LowKick;
		this.Row();
	}

	public void MidKick()
	{
        Debug.Log("Mid kick!");
		if (isKicking)
		{
			return;
		}

		this.CurrentAction = Action.MidKick;
		this.StartCoroutine(this.MidKickCoroutine());
	}

	private IEnumerator MidKickCoroutine()
	{
		isKicking = true;
		yield return new WaitForSeconds(0.25f);

		foreach (var weaponCollider in WeaponColliders)
		{
			weaponCollider.enabled = true;
		}

		yield return new WaitForSeconds(0.27f);

		foreach (var weaponCollider in WeaponColliders)
		{
			weaponCollider.enabled = false;
		}
		
		isKicking = false;
	}

	public void HighKick()
	{
        Debug.Log("High kick!");
		if (isKicking)
		{
			return;
		}
        this.CurrentAction = Action.HighKick;
		this.StartCoroutine(this.HighKickCoroutine());
	}

    public void Idle()
    {
        this.CurrentAction = Action.Idle;
    }

	private IEnumerator HighKickCoroutine()
	{
		isKicking = true;
		yield return new WaitForSeconds(0.25f);

		this.HihgKickKicker.enabled = true;
		this.HihgKickCollider.enabled = true;
		this.WeaponCollider.enabled = true;

		yield return new WaitForSeconds(0.02f);
		
		this.HihgKickKicker.enabled = false;
		this.HihgKickCollider.enabled = false;
		this.WeaponCollider.enabled = true;

		isKicking = false;
	}

	public void Row()
	{
		isKicking = true;
		LeanTween.delayedCall(gameObject, 0.3f, ResetKickState);
		this.MyCroco.ApplySpeedChange(this.RowDeltaSpeed);
	}

	private void ResetKickState()
	{
		isKicking = false;
	}

	public void KickToHead()
	{
		Debug.Log("Kicked to head");
		var o = (GameObject)Instantiate(this.BloodPrefab, Head.transform.position, Quaternion.identity);
	    MyCroco.OwnSpeed = 0;
		if (MyCroco.IsMineCroco)
		{
			GameController.Instance.Loose(3);
		}
		Destroy(o, 2);
		LeanTween.delayedCall(this.gameObject, 0.1f, () => this.gameObject.SetActive(false));
	}

	public void FallOver(float speed)
	{
		LeanTween.moveLocalX(this.gameObject, this.transform.localPosition.x + 20, 10f/speed);
		LeanTween.rotateZ(this.gameObject, 180, 10f / speed); 
		
		if (MyCroco.IsMineCroco)
		{
			GameController.Instance.Loose(2);
		}
	}
}
