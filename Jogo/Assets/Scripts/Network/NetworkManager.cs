using UnityEngine;
using System.Collections;

public class NetworkManager
{
	public NetworkManager()
	{
		MaxConnections = 4;
		Port = 25001;
	}

	public string GameTypeName { get; set; }
	public int MaxConnections { get; set; }
	public int Port { get; set; }

	public void StartServer(string gameName, string comment)
	{
		DisconnectIfNeed();

		Network.InitializeServer(MaxConnections, Port, UseNat());
		MasterServer.RegisterHost(GameTypeName, gameName, comment);
	}

	public HostData[] GetHostList()
	{
		MasterServer.RequestHostList(GameTypeName);
		return MasterServer.PollHostList();
	}

	public void JoinServer(HostData hostData)
	{
		//DisconnectIfNeed();

		Network.Connect(hostData);
	}

	public bool IsClient
	{
		get { return Network.isClient; }
	}

	public bool IsServer
	{
		get { return Network.isServer; }
	}

	public void Disconnect()
	{
		Network.Disconnect();
	}

	private void DisconnectIfNeed()
	{
		if (Network.peerType != NetworkPeerType.Disconnected)
			Disconnect();
	}
	
	private bool UseNat()
	{
		return !Network.HavePublicAddress();
	}
}
