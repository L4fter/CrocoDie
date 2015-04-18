using System.Collections;

using UnityEngine;

public class Man : MonoBehaviour
{
	public Croco MyCroco;

	public float RowDeltaSpeed;

	public float Health;

	private bool isKicking;

	public Collider2D WeaponCollider;

	// Use this for initialization
	void Start () {
	
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

		this.Row();
	}

	public void MidKick()
	{
		if (isKicking)
		{
			return;
		}
	}

	public void HighKick()
	{
		if (isKicking)
		{
			return;
		}

		this.StartCoroutine(this.HighKickCoroutine());
	}

	private IEnumerator HighKickCoroutine()
	{
		isKicking = true;
		yield return new WaitForSeconds(0.1f);

		this.WeaponCollider.enabled = true;

		yield return new WaitForSeconds(0.2f);

		this.WeaponCollider.enabled = false;

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
}
