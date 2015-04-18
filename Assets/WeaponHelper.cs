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
				this.transform.position + (Vector3)component.offset,
				component.bounds.size);
			Gizmos.color = color;
		}
	}
}