using UnityEngine;
using System.Collections;

public class JoinGame : MonoBehaviour 
{
	private const string GameTypeName = "GDZero";
	private NetworkManager networkManager = new NetworkManager();
	private HostData[] _hostList = null;

	void Start() 
	{
		networkManager.GameTypeName = GameTypeName;
	}
	
	// Update is called once per frame
	void Update () {
		if (_hostList == null)
			_hostList = networkManager.GetHostList();
	}

	void OnGUI()
	{
		if (_hostList != null)
			for (int i = 0; i < _hostList.Length; i++)
				if (GUI.Button(new Rect(100, 100 + (100 * i), 300, 50), _hostList[i].gameName))
					JoinServer(_hostList[i]);

		if (GUI.Button(new Rect(500, 375, 100, 25), "Voltar"))
			Back();
	}

	private void JoinServer(HostData hostData)
	{
		networkManager.JoinServer(hostData);
		LoadGame("FasePrototipo");
	}

	private void Back()
	{
		LoadGame("Menu");
	}

	private void CreateGame()
	{
		LoadGame("FasePrototipo");
	}
	
	private void LoadGame(string fase)
	{
		Application.LoadLevel(fase);
	}

	void OnConnectedToServer()
	{
		CreateGame();
	}
}
