using UnityEngine;

public class WeaponHelper : MonoBehaviour
{
	public Collider2D component;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
	}

	public void OnDrawGizmos()
	{
		if (this.component.enabled)
		{
			var color = Gizmos.color;
			Gizmos.color = new Color(1, 0, 0, 1);
			Gizmos.DrawCube(
				this.transform.position + new Vector3(-0.1255093f, -0.02214766f),
				new Vector3(0.2469447f, 0.4536676f, 1));
			Gizmos.color = color;
		}
	}
}