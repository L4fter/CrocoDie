using System.Collections;

using UnityEngine;

public class Man : MonoBehaviour
{
	public Croco MyCroco;

	public float RowDeltaSpeed;

	public float Health;

	private bool isKicking;

    public Action CurrentAction { get; private set;}

	public Collider2D WeaponCollider;

    private GameController game;

    public enum Action { LowKick = 1, MidKick = 2, HighKick = 3, Idle = 4}

    
	// Use this for initialization
	void Start () {
        game = GameController.Instance;
        CurrentAction = Action.Idle;
//        if (!game.PlayerControlsMan)
//        {
//            Destroy(this.GetComponent<ManController>());
//        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LowKick()
	{
        Debug.Log("Low kick!");
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
