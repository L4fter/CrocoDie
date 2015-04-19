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

	public bool IsDead { get; set; }

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

		if (this.IsSleepeng)
		{
			this.OwnSpeed = 0;
		}

		this.LoseSomeWeight();
	}

	private void LoseSomeWeight()
	{
		if (IsSleepeng || IsDead)
		{
			return;
		}

		Weight -= WeightLossPerSecond * Time.deltaTime;
		if (this.Weight < roundedWeight)
		{
			Debug.Log(string.Format("Weight: {0}, rounded: {1}", Weight, roundedWeight));
			this.Body.RemovePart();
			roundedWeight = Mathf.FloorToInt(this.Weight);

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
		this.Weight = 1;
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
		if (IsDead)
		{
			return;
		}

		LeanTween.cancel(this.gameObject);
		var level = this.GetComponentInChildren<SpriteRenderer>().sortingOrder;
		var myY = this.transform.position.y;
		if (direction == Direction.Down)
		{
			targetVerticalPos = currentMap.GetLowerLineY(myY);
			if (targetVerticalPos != myY)
			{
				foreach (var child in this.GetComponentsInChildren<SpriteRenderer>())
				{
					child.sortingOrder += 5;
				}
			}
		}
		else
		{
			targetVerticalPos = currentMap.GetUpperLineY(myY);
			if (targetVerticalPos != myY)
			{
				foreach (var child in this.GetComponentsInChildren<SpriteRenderer>())
				{
					child.sortingOrder -= 5;
				}
			}
		}

		var dist = Mathf.Abs(this.targetVerticalPos - this.transform.position.y);
		LeanTween.moveY(this.gameObject, targetVerticalPos, dist / this.VertSpeed).setEase(LeanTweenType.easeInOutSine);
	}

	public void ApplySpeedChange(float delta)
	{
		if (IsDead && delta > 0)
		{
			return;
		}

		if (this.Speed > 4 && delta < 0)
		{
			delta = -Speed * 0.8f;
			this.GetComponentInChildren<Man>().FallOver(Speed * 0.8f);

			this.Die(2);
		}

		this.Speed += delta;

		if (this.Speed > this.WakingSpeed && IsSleepeng)
		{
			this.WakeUp();
		}
	}

	public void ApplyOwnSpeedChange(float delta)
	{
		if (IsDead)
		{
			return;
		}

		this.OwnSpeed += delta;
	}

	public void ApplyWeightChange(float delta)
	{
		if (IsDead)
		{
			return;
		}

		this.Weight = Mathf.Clamp(this.Weight + delta, this.MinWeight, this.MaxWeight);
		this.roundedWeight = Mathf.FloorToInt(Weight);

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

	public void Die(int i)
	{
		IsDead = true;
		OwnSpeed = 0;
		crocoAnimator.Die();
		GameController.Instance.Loose(i);
	}
}