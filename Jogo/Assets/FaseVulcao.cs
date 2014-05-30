using UnityEngine;
using System.Collections;

public class FaseVulcao : MonoBehaviour 
{
	public int PreGameTime = 5;
	public int GameTime = 180;
	public int DragonTime = 15;
	public int FirePlataformTime = 30;
	public int ItemRespawn = 15;
	public int FireBallTime = 10;
	private int currentTime = 0;
	private int indexItemRespawn = 0;

	public GameObject ItemPrefab;
	public Transform[] ItemRespawnPoints;
	public GameObject PlayerPrefab;
	public Transform[] PlayerRespawnPoints;
	public GameObject EggPrefab;
	public Transform EggRespawnPoint;

	public HUDBar HUDBar;

	void Start() 
	{
		CreateInitialObjects();
		StartCoroutine(Timer());
	}
	
	void Update() 
	{	
	}

	private void CreateInitialObjects()
	{
		CreateEgg();
		CreatePlayer();
	}

	private void CreateEgg()
	{
		GameObject createEgg = (GameObject)CreateObject(EggPrefab, EggRespawnPoint.position);
		Egg egg = createEgg.GetComponent<Egg>();
		egg.SpawnPoint = EggRespawnPoint;
	}

	private void CreatePlayer()
	{
		GameObject createPlayer = (GameObject)CreateObject(PlayerPrefab, PlayerRespawnPoints[0].position);
		Player player = createPlayer.GetComponent<Player>();
		player.HUDBar = HUDBar;
		player.playerClass = CharClass.Warrior;
		player.LevelTime = this.GameTime;
	}

	private IEnumerator Timer() 
	{
		for (currentTime = PreGameTime; currentTime > 0; currentTime--)
			yield return new WaitForSeconds(1);
		
		StartGame();
		
		for (currentTime = GameTime; currentTime > 0; currentTime--) 
		{
			if (currentTime % FirePlataformTime == 0)
				FirePlataform();

			if (currentTime % ItemRespawn == 0)
				RespawnItem();
			
			if (currentTime % FireBallTime == 0)
				FireBall();
			
			yield return new WaitForSeconds(1);
		}
		
		StartDragonRush();
		
		for (currentTime = DragonTime; currentTime > 0; currentTime--)
			yield return new WaitForSeconds(1);
		
		EndGame();
	}

	private void StartGame()
	{
		Debug.Log("StartGame");
	}

	private void RespawnItem() 
	{
		CreateObject(ItemPrefab, ItemRespawnPoints[indexItemRespawn].position);
		indexItemRespawn++;
		if (ItemRespawnPoints.Length == indexItemRespawn)
			indexItemRespawn = 0;
	}
	
	private void FireBall()
	{
		Debug.Log("FireBall");
	}

	private void FirePlataform()
	{
		Debug.Log("FirePlataform");
	}

	private void StartDragonRush()
	{
		Debug.Log("StartDragonRush");
	}
	
	private void EndGame()
	{
		Debug.Log("EndGame");
	}

	private object CreateObject(Object obj, Vector3 position)
	{
		return Instantiate(obj, position, Quaternion.identity);
	}

	private void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2 - 40, Screen.height - 35, 100, 25), currentTime.ToString());
	}
}