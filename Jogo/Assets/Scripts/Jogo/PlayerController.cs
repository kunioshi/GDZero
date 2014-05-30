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
		Player.Move(Input.GetAxis("joystick 1 X"), Input.GetButton("joystick 1 button 0"));
		Player.Attack(Input.GetAxis("joystick 1 Y"), Input.GetButton("joystick 1 button 2"));
		if (Input.GetButton("joystick 1 button 3"))
			Player.SpecialAttack();
		//Player.Jump();

		//bool attack = Input.GetButton ("Fire1");
		//bool arrowAttack = Input.GetButton ("Fire2");
	}
}
