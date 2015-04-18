using System;

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public NetworkView NetworkView;

    private bool controlMan;
	private bool controlCroco;

    public bool PlayerControlsMan
    {
        get
        {
            return controlMan;
        }
    }
    public bool PlayerControlsCroco
    {
        get
        {
            return controlCroco;
        }
    }

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
	    DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void LoadSingleGame()
    {
        controlMan = true;
        controlCroco = true;
        Application.LoadLevel("TestLevel");
    }

    [RPC]
    public void LoadServerGame()
    {
        controlMan = false;
        controlCroco = true;
        Debug.Log("Loading server game... " + controlMan);
        NetworkView.RPC("LoadClientGame", RPCMode.Others, !controlMan);
        StartLevel("TestLevel");
    }

    [RPC]
    public void LoadClientGame(bool controlMan)
    {
        this.controlMan = controlMan;
        Debug.Log("Loading client game... " + controlMan);
        Debug.Log("Loading client game... " + PlayerControlsMan);
        StartLevel("TestLevel");
    }

    public void Host()
    {
        var useNat = !Network.HavePublicAddress();
        var er = Network.InitializeServer(32, 25000, useNat);
        Debug.Log("Hosting error: " + er);
    }

    private void StartLevel(string levelName)
    {
        Application.LoadLevel(levelName);
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
        while (error && count < 6)
        {
            Debug.Log("Connect...");
            yield return new WaitForSeconds(1);
            NetworkView.RPC("LoadServerGame", RPCMode.Others);
            error = false;
        }
        
    }
}
