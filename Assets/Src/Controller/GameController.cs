using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    private bool controlMan;

	// Use this for initialization
	void Start () {
	    DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadGame()
    {
        controlMan = false;
        Application.LoadLevel("TestLevel");
    }
}
