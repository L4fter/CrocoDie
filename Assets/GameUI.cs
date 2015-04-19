using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	public Slider WeightSlider;

    public Button RepeatButton;

    public Button BackButton;

    public Image Img;

	private static GameUI instance;

	// Use this for initialization
	private void Start()
	{
		instance = this;
	}

	// Update is called once per frame
	private void Update()
	{
	    if (Input.GetKeyDown(KeyCode.D))
	    {
	        Lose(0);
	    }
	}

	public static float CrocoWeight
	{
		set
		{
			instance.WeightSlider.value = value;
		}
	}

    public static void Lose(int delay)
    {
        var obj = instance.Img.gameObject;
        var pos = obj.transform.position;
        instance.Img.gameObject.transform.position = new Vector3(pos.x, pos.y + 300, pos.z);
        instance.Img.gameObject.SetActive(true);
        LeanTween.move(obj, pos, 1.5f).setEase(LeanTweenType.easeOutElastic).setDelay(delay);

        if (GameController.Instance.PlayerControlsCroco)
        {
            instance.ShowButton(200, instance.RepeatButton, delay);
        }
        instance.ShowButton(-200, instance.BackButton, delay);
    }

    private void ShowButton(int offsetX, Button btn, int delay)
    {
        var obj = btn.gameObject;
        var pos = obj.transform.position;
        btn.gameObject.transform.position = new Vector3(pos.x + offsetX, pos.y, pos.z);
        btn.gameObject.SetActive(true);
        LeanTween.move(obj, pos, 1f).setEase(LeanTweenType.easeOutCirc).setDelay(1f + delay);
    }

    public void BackToMenu()
    {
        Destroy(GameController.Instance.gameObject);
        GameController.Instance.Reset();
    }

    public void Reload()
    {
        Destroy(GameController.Instance.gameObject);
        GameController.Instance.Reload();
    }
    
    
}