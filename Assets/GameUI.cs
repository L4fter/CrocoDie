using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	public Slider WeightSlider;

	private static GameUI instance;

	// Use this for initialization
	private void Start()
	{
		instance = this;
	}

	// Update is called once per frame
	private void Update()
	{
	}

	public static float CrocoWeight
	{
		set
		{
			instance.WeightSlider.value = value;
		}
	}
}