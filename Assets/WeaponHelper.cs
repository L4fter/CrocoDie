using UnityEngine;

public class WeaponHelper : MonoBehaviour
{
	public Collider2D component;

	public Color color;

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
			Gizmos.color = this.color;
			Gizmos.DrawCube(
				this.transform.position + (Vector3)component.offset,
				component.bounds.size);
			Gizmos.color = color;
		}
	}
}