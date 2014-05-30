using UnityEngine;
using System.Collections;

public class FundoSelecionarFase : MonoBehaviour {
	
	public Texture2D[] fases = new Texture2D[3];
	public int pos;
	bool ativo;
	bool Control_IdleY = true;
	
	// Use this for initialization
	void Start () {
		ativo = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetAxis("Vertical") > - 0.2 && Input.GetAxis("Vertical") < 0.2)
		{
			Control_IdleY = true;
		}
		
		if (Input.GetKeyDown("return") || Input.GetButton("Fire1"))
		{
			ativo = true;
		}

		if (Input.GetKeyDown ("escape") || Input.GetButton("Fire2")) 
		{
			ativo = false;
		}
		
		if (ativo)
		{
			
			if ((Input.GetKeyDown("left") || Input.GetAxis("Vertical") < 0) && Control_IdleY)
			{
				if (pos == 0)
					pos = fases.Length - 1;
				else
					pos--;
			}
			
			if ((Input.GetKeyDown("right") || Input.GetAxis("Vertical") < 0) && Control_IdleY)
			{
				if (pos == fases.Length - 1)
					pos = 0;
				else
					pos++;
			}
			
			
			renderer.material.mainTexture = fases[pos];
		}
		
	}
}
