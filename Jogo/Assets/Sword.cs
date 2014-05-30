using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public bool On = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider) 
	{
		switch (collider.tag) 
		{
			case "Player":
				if (On)
					Hit(collider.gameObject);
				break;			
		}
	}	

	void OnTriggerStay2D(Collider2D collider)
	{
		switch (collider.tag) 
		{
			case "Player":
				if (On)
					Hit(collider.gameObject);
				break;			
		}
	}
		
	private void Hit(GameObject gameObject)
	{
		Player player = gameObject.GetComponent<Player>();
		player.Hit ();
	}

}
