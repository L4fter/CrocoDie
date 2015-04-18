using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button CreateBtn;

    public Button JoinBtn;

    public Button SingleBtn;

	// Use this for initialization
	void Start () {
	    this.CreateBtn.GetComponentInChildren<Text>().text = "Create";
	    this.JoinBtn.GetComponentInChildren<Text>().text = "Join";
	    this.SingleBtn.GetComponentInChildren<Text>().text = "Single play";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
