using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button CreateBtn;

    public Button JoinBtn;

	// Use this for initialization
	void Start () {
	    this.CreateBtn.GetComponentInChildren<Text>().text = "Create";
	    this.JoinBtn.GetComponentInChildren<Text>().text = "Join";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
