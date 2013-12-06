using UnityEngine;
using System.Collections;

public class LoadPlayer : MonoBehaviour 
{
	public GameObject Player1Prefab;
	public GameObject Player2Prefab;
	public Transform SPPlayer1;
	public Transform SPPlayer2;

	void Start () 
	{
		Network.Instantiate(Player1Prefab, SPPlayer1.position, Quaternion.identity, 0);
		Network.Instantiate(Player2Prefab, SPPlayer2.position, Quaternion.identity, 0);
		//else
		//	Network.Instantiate(Player2Prefab, Vector3.up, Quaternion.identity, 0);
	}
	
	void Update () {
	
	}

	void OnGUI() 
	{
		GUI.Box(new Rect(Screen.width - 100, 0, 100, 25), Network.peerType.ToString());
	}
}
