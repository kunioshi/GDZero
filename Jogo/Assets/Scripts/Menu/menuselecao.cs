using UnityEngine;
using System.Collections;

public class menuselecao : MonoBehaviour {
	
	public GameObject[] opcoes = new GameObject[4];
	public GameObject selecionado;
	public bool Control_IdleX = false;
	public bool Control_IdleY = false;
	public bool ativo;
	public bool inputEsquerda = false;
	public bool inputDireita = false;
	public bool inputVertical = false;
	public int opcao;
	
	// Use this for initialization
	void Start () {
		opcao = 0;
		ativo = true;
		selecionado.transform.position = opcoes[opcao].transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (ativo)
		{
			//(Input.GetKeyDown("left") || Input.GetAxisRaw("X axis") > 0.3)
			if (inputEsquerda)
			{
				Control_IdleX = false;
				if (opcao == 0)
				{
					opcao = 3;
				}
				else
				{
					opcao--;
				}
				inputEsquerda = false;
			}
			//(Input.GetKeyDown("right") || Input.GetAxisRaw("X axis") < -0.3)
			if (inputDireita)
			{
				Control_IdleX = false;
				if (opcao == 3)
				{
					opcao = 0;
				}
				else
				{
					opcao++;
				}
				inputDireita = false;
			}
			
			if (inputVertical)
			{
				Control_IdleY = false;
				if (opcao <= 1)
				{
					opcao += 2;
				}
				else
				{
					opcao -= 2;
				}
				inputVertical = false;
			}
			
//			Player player = GetComponent<Player>();
//			switch(opcao)
//			{
//			case 0:
//				player.playerClass = CharClass.Barbarian;
//				break;
//			case 1:
//				player.playerClass = CharClass.Paladin;
//				break;
//			case 2:
//				player.playerClass = CharClass.Thief;
//				break;
//			case 3:
//				player.playerClass = CharClass.Warrior;
//				break;
//			}
			
			
			selecionado.transform.position = new Vector3(opcoes[opcao].transform.position.x, 
			                                             opcoes[opcao].transform.position.y, opcoes[opcao].transform.position.z - 10);
			
		}
		
		
	}
}
