#pragma strict

var preGameTime = 5;
var gameTime = 180;
var dragonTime = 15;
var firePlataformTime = 30;
var itemRespawn = 15;
var fireBallTime = 10;
var _currentTime = 0;
var ItemPrefab : GameObject;
var ItemSpawnPoints : GameObject[];

function Start () {
	for (_currentTime = preGameTime; _currentTime > 0; _currentTime--)
		yield WaitForSeconds(1);
		
	StartGame();
	
	for (_currentTime = gameTime; _currentTime > 0; _currentTime--) {
		if (_currentTime % firePlataformTime)
			FirePlataform();
			
		if (_currentTime % itemRespawn)
			RespawnItem();
			
		if (_currentTime % fireBallTime)
			FireBall();
		
		yield WaitForSeconds(1);
	}
		
	StartDragonRush();
	
	for (_currentTime = dragonTime; _currentTime > 0; _currentTime--)
		yield WaitForSeconds(1);
		
	EndGame();
}

function StartGame() {
Debug.Log("StartGame");
}

function FirePlataform() {
Debug.Log("FirePlataform");
}

function RespawnItem() 
{
	//Random.Range(0 ItemSpawnPoints.Count);
}

function FireBall() {
Debug.Log("FireBall");
}

function StartDragonRush() {
Debug.Log("StartDragonRush");
}

function EndGame() {
Debug.Log("EndGame");
}

function Update () {

}

function OnGUI() {
	GUI.Box(new Rect(Screen.width / 2 - 40, 685, 100, 25), _currentTime.ToString());
}
