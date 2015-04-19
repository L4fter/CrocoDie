using UnityEngine;

public class Croco : MonoBehaviour
{
    public bool IsMineCroco = true;

	public Map currentMap;

	public float DampeningTime;

	public float MaxSpeed = 10;

	public float OwnSpeed;
	public float Speed;
	public float WakingSpeed;

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
	public float WeightLossPerSecond;
	private int roundedWeight;
	
    public Vector3 Goal; //used when player control man

	public CrocoBody Body;

	private float currentDampVelocity;

	private GameController game;

	private bool IsSleepeng;

	// Use this for initialization
	private void Start()
	{
		currentMap = FindObjectOfType<Map>();
	    game = GameController.Instance;
	    if (!game.PlayerControlsCroco)
	    {
	        Destroy(this.GetComponent<CrocoController>());
	    }
		this.roundedWeight = Mathf.CeilToInt(this.Weight);
		this.crocoAnimator = this.GetComponentInChildren<CrocoAnimator>();
	}

	// Update is called once per frame
	private void Update()
	{
	    if (!game.PlayerControlsCroco)
	    {
	        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Goal, Time.deltaTime * 25);
	    }
	    else
	    {
            this.ForwardUpdate();
            this.VerticalUpdate();
	    }

		if (IsSleepeng)
		{
			this.OwnSpeed = 0;
		}
		this.LoseSomeWeight();
	}

	private void LoseSomeWeight()
	{
		if (IsSleepeng)
		{
			return;
		}

		Weight -= WeightLossPerSecond * Time.deltaTime;
		if (this.Weight < roundedWeight)
		{
			this.Body.RemovePart();
			roundedWeight = Mathf.CeilToInt(this.Weight);
			Debug.Log(string.Format("Rounded weight = {0}", roundedWeight));

			if (Weight <= 0)
			{
				this.Sleep();
			}
		}
	}

	private void Sleep()
	{
		this.IsSleepeng = true;
		this.OwnSpeed = 0;
		this.crocoAnimator.Sleep();
	}
	private void WakeUp()
	{
		this.IsSleepeng = false;
		this.OwnSpeed = this.Speed;
		this.crocoAnimator.WakeUp();
	}


	private float targetVerticalPos;

	private CrocoAnimator crocoAnimator;

	private void VerticalUpdate()
	{
		
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

		if (this.Speed > this.WakingSpeed
			&& IsSleepeng)
		{
			this.WakeUp();
		}
	}

	public void ApplyOwnSpeedChange(float delta)
	{
		this.OwnSpeed += delta;
	}

	public void ApplyWeightChange(float delta)
	{
		this.Weight = Mathf.Clamp(this.Weight + delta, this.MinWeight, this.MaxWeight);
		this.roundedWeight = Mathf.CeilToInt(Weight);

		if (delta > 0)
		{
			this.Body.AddPart();
		}
		else
		{
			this.Body.RemovePart();
		}

		this.crocoAnimator.CloseCrocoMouth();
	}
}