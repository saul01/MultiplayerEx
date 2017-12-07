using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

//=================================================================
//
//=================================================================

public class PlayerNetworkManager : NetworkManager 
{
    public Text serverIpAddr;

    //-------------------------------------------------------------
	// Use this for initialization
    //-------------------------------------------------------------

	void Start () 
    {
		
	}


    //-------------------------------------------------------------	
	// Update is called once per frame
    //-------------------------------------------------------------

	void Update () 
    {
		
	}


    //-------------------------------------------------------------
    // HostGame() Start Robot Network Server.
    //-------------------------------------------------------------

    public void HostGame()
    {
        Print("starting Player");
        PlayerNetworkDiscovery.Instance.StartBroadcasting();
        SceneManager.LoadScene("Player");
        StartHost();
    }


    //-------------------------------------------------------------
    // Controller Board (Client)
    //-------------------------------------------------------------

    public void ReceiveGameBroadcast()
    {
        PlayerNetworkDiscovery.Instance.ReceiveBraodcast();        
    }


    //-------------------------------------------------------------
    // JoinGame() - User selects a server from a list (ConfigPanel)
    //              and we connect.
    //-------------------------------------------------------------

    public void JoinGame(Text serverIpAddr)
    {
        //ipAddressText = serverIpAddr;

        networkAddress = serverIpAddr.text;
        onlineScene = "RemoteController";
        StartClient();

        PlayerNetworkDiscovery.Instance.StopBroadcasting();
 
        Print("Connecting to: " + serverIpAddr.text.ToString());
        // Update UI
    }


    //-------------------------------------------------------------
    // OnReceiveBraodcast() -
    //-------------------------------------------------------------

    public void OnReceiveBraodcast(string fromIp, string data)
    {
        Print("Found server: " + fromIp + ", " + data);
        serverIpAddr.text = fromIp;
    }


    void Print(string msg)
    {
        Debug.Log("NetMgr :" + msg);
    }
}
