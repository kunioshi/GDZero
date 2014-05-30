using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Player Player;

	void Start() 
	{
	
	}
	
	void Update() 
	{
		Player.Move(Input.GetAxis("Horizontal"), Input.GetButton("Jump"));
		Player.Attack(Input.GetAxis("Vertical"), Input.GetButton("Fire1"));
		if (Input.GetButton("Fire2"))
			Player.SpecialAttack();
		//Player.Jump();

		//bool attack = Input.GetButton ("Fire1");
		//bool arrowAttack = Input.GetButton ("Fire2");
	}
}
