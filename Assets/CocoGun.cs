using UnityEngine;
using System.Collections;

public class CocoGun : MonoBehaviour
{
	public Vector3 AimDirection;
	public float RandomX = 0.3f;

	public float ProjectileSpeed = 4;

	public GameObject CoconutPrefab;

	private Coconut projectile;

    private GameController game;

    public NetworkView networkView;


	// Use this for initialization
	void Start ()
	{
	    game = GameController.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (game.PlayerControlsMan && Random.Range(0, 100) > 98)
		{
			this.Shoot((this.AimDirection + new Vector3(Random.Range(-this.RandomX, this.RandomX), 0)).normalized * this.ProjectileSpeed);
		}
	}

    [RPC]
	public void Shoot(Vector3 dir)
	{
        Debug.Log("Shoot!");
		var coconut = Instantiate(this.CoconutPrefab, this.transform.position, Quaternion.identity) as GameObject;
		projectile = coconut.GetComponent<Coconut>();
		projectile.Launch(dir);
		Destroy(projectile.gameObject, 4);
	    if (game.PlayerControlsMan)
	    {
            networkView.RPC("Shoot", RPCMode.Others, dir);	        
	    }
	}
}