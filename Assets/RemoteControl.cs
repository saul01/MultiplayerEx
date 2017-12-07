// [Command] code is called on the Client, but run on the Server!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class RemoteControl : NetworkBehaviour 
{

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isLocalPlayer)
        {
            return;
        }	
	}

	[Command]
	public void CmdMoveLeft()
	{
        Print("Move Left");
	}


	[Command]
	public void CmdMoveRight()
	{
        Print("Move Right");
	}



	[Command]
	public void CmdMoveUp()
	{
        Print("Move Up");
	}



	[Command]
	public void CmdMoveDown()
	{
        Print("Move Down");
	}

    //-------------------------------------------------------------
    //
    //-------------------------------------------------------------

    void Print(string msg)
    {
        Debug.Log("[RemoteCntl]: " + msg);
    }
}
