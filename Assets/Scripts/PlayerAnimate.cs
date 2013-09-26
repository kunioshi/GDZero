using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Player player = GetComponent<Player>();
			
		float horizontalInput = Input.GetAxis("Horizontal");
		if (horizontalInput == 0)
			DefinirAnimacaoParado();
		else
			DefinirAnimacaoCorrendo();	
		
		if (Input.GetButton("Jump"))
			DefinirAnimacaoPulando();
	
		if (Input.GetButton("Fire1"))
			DefinirAnimacaoAtacando();
		
		if (Input.GetButton("Fire2"))
			DefinirAnimacaoEspecial();
	}

	private void DefinirAnimacaoParado()
	{
		DefinirAnimaca(0, 1);
	}
	
	private void DefinirAnimacaoCorrendo() 
	{
		DefinirAnimaca(1, 8);
	}
	
	private void DefinirAnimacaoPulando() 
	{
		DefinirAnimaca(2, 5);
	}
	
	private void DefinirAnimacaoAtacando() 
	{
		DefinirAnimaca(4, 6);
	}
	
	private void DefinirAnimacaoEspecial() 
	{
		DefinirAnimaca(3, 5);
	}
	
	private void DefinirAnimaca(int rowIndex, int totalCellsOfRow) 
	{
		AnimateTexture animateTexture = GetComponent<AnimateTexture>();
		animateTexture.RowIndex = rowIndex;
		animateTexture.TotalCellsOfRow = totalCellsOfRow;
	}
}
