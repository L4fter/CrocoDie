using UnityEngine;
using System.Collections;

public class CocoGun : MonoBehaviour
{
	public Vector3 AimDirection;
	public float RandomX = 0.3f;

	public float ProjectileSpeed = 4;

	public GameObject CoconutPrefab;

	private Coconut projectile;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Random.Range(0, 100) > 98)
		{
			this.Shoot((this.AimDirection + new Vector3(Random.Range(-this.RandomX, this.RandomX), 0)).normalized * this.ProjectileSpeed);
		}
	}

	public void Shoot(Vector3 dir)
	{
		var coconut = Instantiate(this.CoconutPrefab, this.transform.position, Quaternion.identity) as GameObject;
		projectile = coconut.GetComponent<Coconut>();
		projectile.Launch(dir);
		Destroy(projectile.gameObject, 4);
	}
}