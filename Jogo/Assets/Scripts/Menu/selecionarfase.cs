using UnityEngine;
using System.Collections;

public class selecionarfase : MonoBehaviour {
	
	public Texture2D[] fases = new Texture2D[3];
	public GameObject[] FaseObj = new GameObject[3];
	public int pos;
	public bool ativo;
	public bool Control_IdleX = false;
	public bool inputEsquerda = false;
	public bool inputDireita = false;
	public bool inputEscape = false;
	
	// Use this for initialization
	void Start () {
		ativo = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//		if (inputEscape)
		//        {
		//            Application.LoadLevel("Main Menu");
		//        }
		
		if (ativo)
		{
			if (inputEsquerda)
			{
				Control_IdleX = false;
				if (pos == 0)
					pos = fases.Length - 1;
				else
					pos--;
				inputEsquerda = false;
			}
			
			if (inputDireita)
			{
				Control_IdleX = false;
				if (pos == fases.Length - 1)
					pos = 0;
				else
					pos++;
				inputDireita = false;
			}
			
			switch(pos)
			{
			case 0:
				FaseObj[0].renderer.material.mainTexture = fases[0];
				FaseObj[1].renderer.material.mainTexture = fases[1];
				FaseObj[2].renderer.material.mainTexture = fases[2];
				break;
			case 1:
				FaseObj[0].renderer.material.mainTexture = fases[1];
				FaseObj[1].renderer.material.mainTexture = fases[2];
				FaseObj[2].renderer.material.mainTexture = fases[0];
				break;
			case 2:
				FaseObj[0].renderer.material.mainTexture = fases[2];
				FaseObj[1].renderer.material.mainTexture = fases[0];
				FaseObj[2].renderer.material.mainTexture = fases[1];
				break;
			}
			
			
			
			
		}
		
	}
}
