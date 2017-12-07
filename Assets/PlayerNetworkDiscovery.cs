/*
 * @name ConfigPanel.cs
 * @author Saul R 12.04.17
 * @brief Derived from Unity Network Discovery class, replaces the Game Matchmaker
 *        all data exchange and connection is done on LAN.
 */

using UnityEngine;

using UnityEngine.Networking;
using System;




public class PlayerNetworkDiscovery : NetworkDiscovery
{
    public static PlayerNetworkDiscovery Instance;
    protected static Boolean initialized = false;
    public Action<string, string> onServerDetected;



    //-----------------------------------------------------------------
    // OnServerDetected()
    //-----------------------------------------------------------------

    void OnServerDetected(string fromAddress, string data)
    {
        if (onServerDetected != null)
        {
            onServerDetected.Invoke(fromAddress, data);
        }
    }


    //-----------------------------------------------------------------
    // Awake()
    //-----------------------------------------------------------------

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    //-----------------------------------------------------------------
    // Start()
    //-----------------------------------------------------------------

    void Start()
    {
        InitializeNetworkDiscovery();
    }


    //-----------------------------------------------------------------
    //
    //-----------------------------------------------------------------
    public void ReStart()
    {
        initialized = false;            
    }

    //-----------------------------------------------------------------
    // InitializeNewtorkDiscovery()
    //-----------------------------------------------------------------

    public bool InitializeNetworkDiscovery()
    {
        bool retVal = true;
        if (!initialized)
        {
            Print("Initializing");
            retVal = Initialize();
            initialized = true;
        }
        return retVal;
    }


    //-----------------------------------------------------------------
    // StartBroadcasting()
    //-----------------------------------------------------------------

    public void StartBroadcasting()
    {
        InitializeNetworkDiscovery();
        StartAsServer();       
        Print("Server started");
    }


    //-----------------------------------------------------------------
    // ReceiveBroadcast()
    //-----------------------------------------------------------------

    public void ReceiveBraodcast()
    {
        InitializeNetworkDiscovery();
        StartAsClient();
        Print("Client started");
    }


    //-----------------------------------------------------------------
    // StopBroadcasting()
    //-----------------------------------------------------------------

    public void StopBroadcasting()
    {
        Print("broadcast stopped");
        StopBroadcast();
    }


    //-----------------------------------------------------------------
    // SetBroadcastData()
    //-----------------------------------------------------------------

    public void SetBroadcastData(string broadcastPayload)
    {
        broadcastData = broadcastPayload;
    }


    //-----------------------------------------------------------------
    // OnReceivedBroadcast()
    //-----------------------------------------------------------------

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        OnServerDetected(fromAddress.Split(':')[3], data);
    }


    //-----------------------------------------------------------------
    // Print()
    //-----------------------------------------------------------------

    void Print(string msg)
    {
        Debug.Log("[CND]: " + msg);
    }


    
}
