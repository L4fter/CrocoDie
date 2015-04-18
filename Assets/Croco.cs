using UnityEngine;

public class Croco : MonoBehaviour
{
    public bool IsMineCroco = true;

	public Map currentMap;

	public float DampeningTime;

	public float MaxSpeed = 10;

	public float OwnSpeed;
	public float Speed;

	public float MinVertSpeed;
	public float MaxVertSpeed;

	public float VertSpeed
	{
		get
		{
			float t = (Weight - MinWeight) / (MaxWeight - MinWeight);
			var vertSpeed = Mathf.Lerp(this.MinVertSpeed, this.MaxVertSpeed, 1 - t);
			return vertSpeed;
		}
	}

	public float MinWeight;
	public float MaxWeight;
	public float Weight;

	public float Sleepiness = 0;

	public float MaxSleepiness = 10;

    public Vector3 Goal; //used when player control man

	private float currentDampVelocity;

    private GameController game;

	// Use this for initialization
	private void Start()
	{
		currentMap = FindObjectOfType<Map>();
	    game = GameController.Instance;
	    if (game.PlayerControlsMan)
	    {
	        Destroy(this.GetComponent<CrocoController>());
	    }
	}

	// Update is called once per frame
	private void Update()
	{
	    if (game.PlayerControlsMan)
	    {
	        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Goal, Time.deltaTime * 25);
	    }
	    else
	    {
            this.ForwardUpdate();
            this.VerticalUpdate();
	    }
	}

	private float targetVerticalPos;
	private void VerticalUpdate()
	{
		
//		this.transform.position += new Vector3(0, this.VertSpeed * Time.deltaTime * (int)this.CrocoState);

//		var position = this.transform.position;
//		if (this.CrocoState == CrocoState.MovingUp)
//		{
//			if (position.y >= this.targetVerticalPos)
//			{
//				this.transform.position = new Vector3(position.x, this.targetVerticalPos);
//				this.CrocoState = CrocoState.OnTheLine;
//			}
//		}
//		else
//		{
//			if (position.y <= this.targetVerticalPos)
//			{
//				this.transform.position = new Vector3(position.x, this.targetVerticalPos);
//				this.CrocoState = CrocoState.OnTheLine;
//			}
//		}
	}

	private void ForwardUpdate()
	{
		this.Speed = Mathf.SmoothDamp(this.Speed, this.OwnSpeed, ref this.currentDampVelocity, this.DampeningTime);
		this.transform.position += new Vector3(this.Speed * Time.deltaTime, 0);
	}

	public void Move(Direction direction)
	{
		LeanTween.cancel(this.gameObject);
		if (direction == Direction.Down)
		{
			targetVerticalPos = currentMap.GetLowerLineY(transform.position.y);
		}
		else
		{
			targetVerticalPos = currentMap.GetUpperLineY(transform.position.y);
		}

		var dist = Mathf.Abs(this.targetVerticalPos - this.transform.position.y);
		LeanTween.moveY(this.gameObject, targetVerticalPos, dist / this.VertSpeed).setEase(LeanTweenType.easeInOutSine);
	}

	public void ApplySpeedChange(float delta)
	{
		this.Speed += delta;
	}

	public void ApplyOwnSpeedChange(float delta)
	{
		this.OwnSpeed += delta;
	}

	public void ApplyWeightChange(float delta)
	{
		this.Weight = Mathf.Clamp(this.Weight + delta, this.MinWeight, this.MaxWeight);
		if (this.IsMineCroco)
		{
			GameUI.CrocoWeight = this.Weight;
		}
	}
}