using UnityEngine;
using System.Collections;

public class WaterBrizgi : MonoBehaviour {
	public ParticleSystem particles;

	public Croco Croco;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.SetSpeedTo(this.Croco.Speed);
	}

	public void SetSpeedTo(float speed)
	{
		if (speed < 0.5)
		{
			this.particles.emissionRate = 0;
		}
		else
		{
			this.particles.emissionRate = 10;
		}

//		this.particles.emissionRate = speed * 2;
		this.particles.startSpeed = speed/2;
	}
}
