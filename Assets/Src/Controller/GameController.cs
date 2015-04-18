using System;

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public NetworkView NetworkView;

    private bool controlMan;

	// Use this for initialization
	void Start () {
	    DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void LoadSingleGame()
    {
        controlMan = false;
        Application.LoadLevel("TestLevel");
    }

    [RPC]
    public void LoadServerGame()
    {
        Debug.Log("Loading server game...");
        controlMan = false;
        NetworkView.RPC("LoadClientGame", RPCMode.All, !controlMan);
        Application.LoadLevel("TestLevel");
    }

    [RPC]
    public void LoadClientGame(bool controlMan)
    {
        Debug.Log("Loading client game...");
        this.controlMan = controlMan;
        Application.LoadLevel("TestLevel");
    }

    public void Host()
    {
        var useNat = !Network.HavePublicAddress();
        var er = Network.InitializeServer(32, 25000, useNat);
        Debug.Log("Hosting error: " + er);
    }

    public void Connect()
    {
        StartCoroutine(this.ConnectRoutine());
    }

    private IEnumerator ConnectRoutine()
    {
        var er = Network.Connect("127.0.0.1", 25000);
        if (er != NetworkConnectionError.NoError)
        {
            yield break;  
        }
        var error = true;
        var count = 0;
        while (error && count < 5)
        {
            yield return new WaitForSeconds(3);
            NetworkView.RPC("LoadServerGame", RPCMode.All);
            Debug.Log("error is false");
            error = false;
        }
        
    }
}
