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

		if (Input.GetAxis("Vertical") > - 0.2 && Input.GetAxis("Vertical") < 0.2)
		{
			selecao.Control_IdleY = true;
		}
		if (Input.GetAxis("Horizontal") > - 0.2 && Input.GetAxis("Horizontal") < 0.2)
		{
			selecao.Control_IdleX = true;
			selecaoFase.Control_IdleX = true;
		}

		if ((Input.GetKeyDown("left") || Input.GetAxis("Horizontal") < -0.3) && selecao.Control_IdleX && selecao.ativo)
		{
			selecao.inputEsquerda = true;
		}

		if ((Input.GetKeyDown("right") || Input.GetAxis("Horizontal") > 0.3) && selecao.Control_IdleX && selecao.ativo)
		{
			selecao.inputDireita = true;
		}
		
		if ((Input.GetKeyDown("left") || Input.GetAxis("Horizontal") < -0.3) && selecaoFase.Control_IdleX && selecaoFase.ativo)
		{
			selecaoFase.inputEsquerda = true;
		}
		
		if ((Input.GetKeyDown("right") || Input.GetAxis("Horizontal") > 0.3) && selecaoFase.Control_IdleX && selecaoFase.ativo)
		{
			selecaoFase.inputDireita = true;
		}
		
		if ((Input.GetKeyDown("up") || Input.GetAxis("Vertical") < -0.3 || Input.GetKeyDown("down") || Input.GetAxis("Vertical") > 0.3) && selecao.Control_IdleY && selecao.ativo)
		{
			selecao.inputVertical = true;
		}

		if (Input.GetKeyDown("return") || Input.GetButton("Fire1"))
		{
			if(selecaoFase.ativo)
			{
				Application.LoadLevel("FaseVulcao");
			}
			selecao.ativo = false;
			selecaoFase.ativo = true;
		}

		if (Input.GetKeyDown("escape") || Input.GetButton("Fire2"))
		{
			selecao.ativo = true;
			selecaoFase.ativo = false;
		}
	}
}
