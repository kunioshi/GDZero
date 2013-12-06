using UnityEngine;
using System.Collections;

public class MenuNetwork : MonoBehaviour 
{
	public GUITexture BackGroundMenu;
	public Transform SpawnPointPlayer1;
	public Transform SpawnPointPlayer2;
	public GameObject Player1Prefab;
	public GameObject Player2Prefab;

	private const string GameTypeName = "GDZero";
	private bool createServer = false;
	private bool joinGame = false;
	private string gameName = "";
	private HostData[] hostList = null;
	private NetworkManager networkManager = new NetworkManager();

	void Start() 
	{
		networkManager.GameTypeName = GameTypeName;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Quit();
		}
	}

	void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected)
		{
			ShowBackgroundMenu();

			if (!createServer && !joinGame)
				MenuPrincipal();
			else
			{
				if (createServer)
					MenuCreateServer();
				else if (joinGame)
					MenuJoinGame();
			}
		}
		else
		{
			BackGroundMenu.enabled = false;
			GUI.Box(new Rect(Screen.width - 100, 0, 100, 25), Network.peerType.ToString());
			GUI.Box(new Rect(Screen.width - 100, 30, 100, 25), string.Format("Sala: {0}", gameName));
		}
	}


	private void ShowBackgroundMenu()
	{
		BackGroundMenu.pixelInset = new Rect(Screen.width/2, Screen.height/2, 0, 0);
		BackGroundMenu.enabled = true;
	}

	private void MenuPrincipal()
	{
		if (GUI.Button(new Rect(GetPosicaoMeio(500), 300, 500, 50), "Criar Servidor"))
			CreateServer();			
		
		if (GUI.Button(new Rect(GetPosicaoMeio(500), 400, 500, 50), "Conectar a um jogo"))
			JoinGame();	
		
		if (GUI.Button(new Rect(GetPosicaoMeio(500), 500, 500, 50), "Sair"))
			Quit();
	}

	private void MenuCreateServer()
	{
		GUI.Label(new Rect(GetPosicaoMeio(500), 275, 500, 20), "Nome:");
		gameName = GUI.TextField(new Rect(GetPosicaoMeio(500), 300, 500, 20), gameName);
		
		if (GUI.Button(new Rect(GetPosicaoMeio(0), 375, 100, 25), "Voltar"))
			Back();
		
		if (GUI.Button(new Rect(GetPosicaoMeio(0) + 150, 375, 100, 25), "Criar"))
			CreateServerGame();
	}

	private void MenuJoinGame()
	{
		if (hostList != null && hostList.Length > 0)
		{
			for (int i = 0; i < hostList.Length; i++)
				if (GUI.Button(new Rect(GetPosicaoMeio(500), 300 + (100 * i), 500, 50), hostList[i].gameName))
					JoinServer(hostList[i]);
		}
		else
			GUI.Label(new Rect(GetPosicaoMeio(500), 200, 500, 20), "...");
		
		if (GUI.Button(new Rect(GetPosicaoMeio(0), 575, 100, 25), "Voltar"))
			Back();
		
		if (GUI.Button(new Rect(GetPosicaoMeio(0) + 150, 575, 100, 25), "Atualizar"))
			UpdateHostList();
	}

	private float GetPosicaoMeio(float tamanho)
	{
		return ((Screen.width - tamanho ) / 2);
	}

	private void CreateServer()
	{
		createServer = true;
	}
	
	private void JoinGame()
	{
		UpdateHostList();
		joinGame = true;
	}

	private void CreateServerGame()
	{
		networkManager.StartServer(gameName, "");
		createServer = false;
	}

	private void UpdateHostList()
	{
		hostList = networkManager.GetHostList();
	}

	private void Back()
	{
		createServer = false;
		joinGame = false;
	}

	private void JoinServer(HostData hostData)
	{
		networkManager.JoinServer(hostData);
		gameName = hostData.gameName;
		joinGame = false;
	}

	private void Quit()
	{
		Application.Quit();
	}

	void OnServerInitialized()
	{
		Network.Instantiate(Player1Prefab, SpawnPointPlayer1.position, Quaternion.identity, 0);
	}

	void OnConnectedToServer()
	{
		Network.Instantiate(Player2Prefab, SpawnPointPlayer2.position, Quaternion.identity, 0);
	}
}
