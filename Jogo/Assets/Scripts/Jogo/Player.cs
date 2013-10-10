using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private string playerClass = "Archer";
	private int maxHealth = 100;
	private int currentHealth = 100;
	private int maxMana = 500;
	private int currentMana = 0;
	private int totalKills = 0;
	
	private bool isAttacking = false;
	private bool isSpecialAttacking = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isAttacking = false;
		isSpecialAttacking = false;
		
		if (Input.GetButtonUp("Fire1"))
			DoAttack();
		else if (Input.GetButtonUp("Fire2"))
			DoSpecialAttack();
	}	
	
	void OnGUI() {
		GUI.Box(new Rect(1, 1, 125, 20), string.Format("{0} - {1}", name, playerClass));
		GUI.Box(new Rect(1, 25, 125, 20), string.Format("Life: {0} / {1}", currentHealth, maxHealth));
		GUI.Box(new Rect(1, 50, 125, 20), string.Format("Mana: {0} / {1}", currentMana, maxMana));
		GUI.Box(new Rect(1, 75, 125, 20), string.Format("Kills: {0}", totalKills));
	}
	
	private void DoAttack() {
		isAttacking = true;
		currentMana++;
	}
	
	private void DoSpecialAttack() {
		isSpecialAttacking = true;
		currentMana = 0;
	}
	
	public bool IsJumping()
	{
		return false;
	}
	
	public bool IsAttacking()
	{
		return isAttacking;
	}
	
	public bool IsSpecialAttacking()
	{
		return isSpecialAttacking;
	}
}
