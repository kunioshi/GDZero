using UnityEngine;
using System.Collections;

public class menuselecaoAcao : MonoBehaviour {
	
	bool ativo;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{		
		menuselecao selecao = GetComponent<menuselecao>();
		selecionarfase selecaoFase = GetComponent<selecionarfase>();
		
		if (Input.GetAxisRaw ("Y axis") > - 0.2 && Input.GetAxisRaw ("Y axis") < 0.2) 
		{
			selecao.Control_IdleY = true;
		}
		if (Input.GetAxisRaw ("X axis") > - 0.2 && Input.GetAxisRaw ("X axis") < 0.2) 
		{
			selecao.Control_IdleX = true;
			selecaoFase.Control_IdleX = true;
		}
		
		if ((Input.GetKeyDown("left") || Input.GetAxisRaw("X axis") > 0.3) && selecao.Control_IdleX && selecao.ativo)
		{
			selecao.inputEsquerda = true;
		}
		
		if ((Input.GetKeyDown("right") || Input.GetAxisRaw("X axis") < -0.3) && selecao.Control_IdleX && selecao.ativo)
		{
			selecao.inputDireita = true;
		}
		
		if ((Input.GetKeyDown("left") || Input.GetAxisRaw("X axis") > 0.3) && selecaoFase.Control_IdleX && selecaoFase.ativo)
		{
			selecaoFase.inputEsquerda = true;
		}
		
		if ((Input.GetKeyDown("right") || Input.GetAxisRaw("X axis") < -0.3) && selecaoFase.Control_IdleX && selecaoFase.ativo)
		{
			selecaoFase.inputDireita = true;
		}
		
		if ((Input.GetKeyDown("up") || Input.GetAxisRaw("Y axis") < -0.3 || Input.GetKeyDown("down") || Input.GetAxisRaw("Y axis") > 0.3) && selecao.Control_IdleY && selecao.ativo)
		{
			selecao.inputVertical = true;
		}
		
		if (Input.GetKeyDown("return") || Input.GetButton("joystick button 0"))
		{
			if(selecaoFase.ativo)
			{
				Application.LoadLevel("FaseVulcao");
			}
			selecao.ativo = false;
			selecaoFase.ativo = true;
		}
		
		if (Input.GetKeyDown("escape") || Input.GetButton("joystick button 1"))
		{
			selecao.ativo = true;
			selecaoFase.ativo = false;
		}
	}
}
