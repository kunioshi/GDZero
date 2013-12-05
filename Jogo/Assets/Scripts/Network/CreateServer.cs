using UnityEngine;
using System.Collections;

public class CreateServer : MonoBehaviour 
{
	private const string GameTypeName = "GDZero";
	private string gameName = "";
	private string comment = "";
	private NetworkManager networkManager = new NetworkManager();

	void Start() 
	{
		networkManager.GameTypeName = GameTypeName;
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(100, 75, 500, 20), "Nome:");
		gameName = GUI.TextField(new Rect(100, 100, 500, 20), gameName);
		GUI.Label(new Rect(100, 125, 500, 20), "Descrição:");
		comment = GUI.TextArea(new Rect(100, 150, 500, 200), comment);

		if (GUI.Button(new Rect(375, 375, 100, 25), "Voltar"))
			Back();
		
		if (GUI.Button(new Rect(500, 375, 100, 25), "Criar"))
			CreateServerGame();
	}

	private void Back()
	{
		LoadGame("Menu");
	}

	private void CreateServerGame()
	{
		networkManager.StartServer(gameName, comment);
	}

	private void CreateGame()
	{
		LoadGame("FasePrototipo");
	}
	
	private void LoadGame(string fase)
	{
		Application.LoadLevel(fase);
	}

	void OnServerInitialized()
	{
		CreateGame();
	}
}
