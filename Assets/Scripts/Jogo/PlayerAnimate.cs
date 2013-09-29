using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {			
		float horizontalInput = Input.GetAxis("Horizontal");
		if (horizontalInput == 0)
			SetAnimationStop();
		else
			SetAnimationRunning();	
		
		if (Input.GetButton("Jump"))
			SetAnimationJumping();
	
		if (Input.GetButton("Fire1"))
			SetAnimationAttack();
		
		if (Input.GetButton("Fire2"))
			SetAnimationDoSpecialAttack();
	}

	private void SetAnimationStop()
	{
		SetAnimation(0, 1);
	}
	
	private void SetAnimationRunning() 
	{
		SetAnimation(1, 8);
	}
	
	private void SetAnimationJumping() 
	{
		SetAnimation(2, 5);
	}
	
	private void SetAnimationAttack() 
	{
		SetAnimation(4, 6);
	}
	
	private void SetAnimationDoSpecialAttack() 
	{
		SetAnimation(3, 5);
	}
	
	private void SetAnimation(int rowIndex, int totalCellsOfRow) 
	{
		AnimateTexture animateTexture = GetComponent<AnimateTexture>();
		animateTexture.RowIndex = rowIndex;
		animateTexture.TotalCellsOfRow = totalCellsOfRow;
	}
}
