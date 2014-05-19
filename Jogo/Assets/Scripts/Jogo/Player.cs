using UnityEngine;
using System.Collections;
public enum Direction {
	Up = 1,
	Down = 2,
	Right = 3,
	Left = 4
}

public enum CharClass {
	Warrior = 1,
	Barbarian,
	Paladin,
	Thief,
	Archer
}

public class Player : MonoBehaviour {
	public CharClass playerClass = CharClass.Archer;
	private int totalKills = 0;
	public bool Running = false;
	public bool Jumping = false;
	public bool Sliding = false;
	public bool Attacking = false;
	public bool EstaComOvo = false;
	public bool Escudo = false;
	public bool EscudoDuplo = false;
	public bool Bebado = false;
	public bool Dyieng = false;
	public bool AttackingArrow = false;
	public Direction Direction = Direction.Left;
	public Animator animatorController;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		animatorController.SetInteger ("PlayerClass", (int)playerClass); 
		animatorController.SetBool ("IsRunning", Running);
		animatorController.SetBool ("IsJumping", Jumping);
		animatorController.SetBool ("IsSliding", Sliding);
		animatorController.SetBool ("IsAttacking", Attacking);
		animatorController.SetBool ("IsDyieng", Dyieng);
		animatorController.SetBool ("IsAttackingArrow", AttackingArrow);
		animatorController.SetInteger ("Direction", (int)this.Direction);

	}

	void OnCollisionEnter (Collision collision) {
		switch (collision.collider.tag) {
			case "Fogo":
				Die();
				break;

			case "Ovo":
				GetEgg(collision.gameObject);
				break;

			case "Item":
				GetItem(collision.gameObject);
				break;
		}	
	}

	private void Die() {
	}

	private void GetEgg(GameObject item) {
	}

	private void GetItem(GameObject item) {

	}

}
