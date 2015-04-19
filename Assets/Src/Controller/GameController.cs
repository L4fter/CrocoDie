using System;

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public NetworkView NetworkView;

    private bool controlMan;
	private bool controlCroco;

    private string currentLevel;

    public bool OnlineGame { get; private set;}

	public bool GameOver;

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
        StartLevel("TestLevel");
    }

    [RPC]
    public void LoadServerGame()
    {
        OnlineGame = true;
        controlMan = false;
        controlCroco = true;
        Debug.Log("Loading server game... " + controlMan);
        NetworkView.RPC("LoadClientGame", RPCMode.Others, !controlMan);
        StartLevel("Tutorial");
    }

    [RPC]
    public void LoadClientGame(bool controlMan)
    {
        OnlineGame = true;
        this.controlMan = controlMan;
        Debug.Log("Loading client game... " + controlMan);
        Debug.Log("Loading client game... " + PlayerControlsMan);
        StartLevel("Tutorial");
    }

    public void Host()
    {
        var useNat = !Network.HavePublicAddress();
        var er = Network.InitializeServer(32, 25000, useNat);
        Debug.Log("Hosting error: " + er);
    }

    private void StartLevel(string levelName)
    {
        currentLevel = levelName;
        Application.LoadLevel(levelName);
    }

    public void Connect()
    {
        StartCoroutine(this.ConnectRoutine());
    }

    public void Reset()
    {
        StartLevel("Menu");
        if (OnlineGame)
        {
            NetworkView.RPC("ResetRequest", RPCMode.Others);
        }
    }

    public void Reload()
    {
        if (PlayerControlsCroco)
        {
            NetworkView.RPC("ReloadClient", RPCMode.Others);
            StartLevel(currentLevel);
        }
    }

    [RPC]
    public void ReloadClient()
    {
        StartLevel(currentLevel);
    }

    [RPC]
    public void ResetRequest()
    {
        StartLevel("Menu");
    }

    private IEnumerator ConnectRoutine()
    {
        var er = Network.Connect("192.168.42.75", 25000);
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

	public void Loose(int time)
	{
		if (GameOver)
		{
			return;
		}

		GameOver = true;
		GameUI.Lose(time);
	}

	public void FuckingWin(int time)
	{
		if (this.GameOver)
		{
			return;
		}

		this.GameOver = true;
		GameUI.Win(time);
	}
}
