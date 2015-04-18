using UnityEngine;
using System.Collections;

public class FallDown : MonoBehaviour
{
	public float Time;

	// Use this for initialization
	void Start ()
	{
		LeanTween.moveLocalY(this.gameObject, this.transform.localPosition.y + 0.6f, this.Time/4).setEase(LeanTweenType.easeOutQuad);
		LeanTween.moveLocalY(this.gameObject, 0, 3*this.Time/4).setEase(LeanTweenType.easeInQuad).setDelay(this.Time/4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
