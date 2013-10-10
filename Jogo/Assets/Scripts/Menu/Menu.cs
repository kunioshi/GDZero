using UnityEngine;
using System.Collections;

//TODO: Mover para proprio arquivo
public class NetworkHelper
{
	private int maxConnections = 4;
	private int port = 25001;
	private bool useNat = false;

	public bool InitializeServer()
	{
		DisconnectIfNeed();
		
		NetworkConnectionError retorno = Network.InitializeServer(maxConnections, port, useNat);
		
		//TODO: ver se conectou ou deu erro
		return retorno == NetworkConnectionError.NoError;
	}
	
	public bool Connect(string IP)
	{	
		DisconnectIfNeed();
		
		NetworkConnectionError retorno = Network.Connect(IP, port);
		
		//TODO: Tratar erro
		return retorno == NetworkConnectionError.NoError;		
	}
	
	private void DisconnectIfNeed()
	{
		if (Network.peerType != NetworkPeerType.Disconnected)
			Network.Disconnect();
	}

}

public class Menu : MonoBehaviour 
{
	
	void Update()
	{
    	if (Input.GetKey(KeyCode.Escape))
    	{
    	    Quit();
	    }
	}
 

	void OnGUI()
	{
		if (GUI.Button(new Rect(100, 100, 500, 50), "Criar Jogo Local - Fase 1"))
			CreateLocalGameFase1();

		if (GUI.Button(new Rect(100, 200, 500, 50), "Criar Jogo Local - Fase 2"))
			CreateLocalGameFase2();
		
		if (GUI.Button(new Rect(100, 300, 500, 50), "Criar Servidor"))
			CreateServer();
		
		if (GUI.Button(new Rect(100, 400, 500, 50), "Conectar a um jogo"))
			JoinGame();
		
		if (GUI.Button(new Rect(100, 500, 500, 50), "Sair"))
			Quit();
		
		GUI.Label(new Rect(1, 1, 100, 25), Network.peerType.ToString());			
	}
	
	private void CreateLocalGameFase1()
	{
		LoadGame("Fase1");
	}

	private void CreateLocalGameFase2()
	{
		LoadGame("Fase2");
	}
	
	private void CreateServer()
	{
		new NetworkHelper().InitializeServer();
	}
	
	private void JoinGame()
	{
		string localHost = "127.0.0.1";
		new NetworkHelper().Connect(localHost);
	}
	
	private void Quit()
	{
		Application.Quit();
	}
	
	private void LoadGame(string fase)
	{
		Application.LoadLevel(fase);
	}
}
