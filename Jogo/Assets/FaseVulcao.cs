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

	public GameObject ItemPrefabs;
	public GameObject[] ItemRespawnPoints;
	private int indexItemRespawn = 0;

	void Start() 
	{
		StartCoroutine(Timer());
	}
	
	void Update() 
	{
	
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
		CreateObject(ItemPrefabs, ItemRespawnPoints[indexItemRespawn].transform.position);
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

	private void CreateObject(Object obj, Vector3 position)
	{
		Instantiate(obj, position, Quaternion.identity);
	}

	private void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2 - 40, Screen.height - 35, 100, 25), currentTime.ToString());
	}
}