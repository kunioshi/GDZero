using UnityEngine;
using System.Collections;

//TODO: Mover para proprio arquivo
public class NetworkHelper
{
	private int maxConexao = 4;
	private int porta = 25001;	

	public bool IniciarServidor()
	{
		DesconectarSePreciso();
		
		NetworkConnectionError retorno = Network.InitializeServer(maxConexao, porta);
		
		//TODO: ver se conectou ou deu erro
		return retorno == NetworkConnectionError.NoError;
	}
	
	public bool ConectarServidor(string IP)
	{	
		DesconectarSePreciso();
		
		NetworkConnectionError retorno = Network.Connect(IP, porta);
		
		//TODO: Tratar erro
		return retorno == NetworkConnectionError.NoError;		
	}
	
	private void DesconectarSePreciso()
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
    	    Sair();
	    }
	}
 

	void OnGUI()
	{
		if (GUI.Button(new Rect(100, 100, 500, 50), "Criar Jogo Local"))
			CriarJogoLocal();
		
		if (GUI.Button(new Rect(100, 200, 500, 50), "Criar Servidor"))
			CriarServidor();
		
		if (GUI.Button(new Rect(100, 300, 500, 50), "Conectar a um jogo"))
			ConectarUmJogo();
		
		if (GUI.Button(new Rect(100, 400, 500, 50), "Sair"))
			Sair();
		
		GUI.Label(new Rect(1, 1, 100, 25), Network.peerType.ToString());			
	}
	
	private void CriarJogoLocal()
	{
		AbrirJogo();
	}
	
	private void CriarServidor()
	{
		new NetworkHelper().IniciarServidor();
	}
	
	private void ConectarUmJogo()
	{
		string localHost = "127.0.0.1";
		if (new NetworkHelper().ConectarServidor(localHost))
			GUI.Label(new Rect(1, 500, 100, 25), "Deu erro");
	}
	
	private void Sair()
	{
		Application.Quit();
	}
	
	private void AbrirJogo()
	{
		Application.LoadLevel("Fase1");
	}
}
