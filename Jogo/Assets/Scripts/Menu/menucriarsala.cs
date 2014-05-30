using UnityEngine;
using System.Collections;

public class menucriarsala : MonoBehaviour {

    int selecao = 0;
    private int modo = 0; // 0 = inicio / 1 = criar sala / 2 = entrar em sala
    public GameObject criarsala;
    public GameObject entrarsala;
    public GameObject posicao_popup;
    public GameObject posicao_inativo;
    public TextMesh entrar;
    public TextMesh criar;
	bool ControlVertical = true;

	// Use this for initialization
	void Start () {
        criarsala.transform.position = posicao_inativo.transform.position;
        entrarsala.transform.position = posicao_inativo.transform.position;
        criar.color = Color.yellow;
        entrar.color = Color.white;
	
	}
	
	// Update is called once per frame
	void Update () {

		
		if(Input.GetAxis("Vertical") == 0)
		{
			ControlVertical = true;
		}

		if ((Input.GetKeyDown("down") || Input.GetAxis("Vertical") < 0) && ControlVertical)
        {
            selecao = 1;
            criar.color = Color.white;
            entrar.color = Color.yellow;
			ControlVertical = false;
        }

		if ((Input.GetKeyDown("up") || Input.GetAxis("Vertical") > 0) && ControlVertical)
        {
            selecao = 0;
            criar.color = Color.yellow;
			entrar.color = Color.white;
			ControlVertical = false;
        }

		if (Input.GetKeyDown("escape") || Input.GetButton("Fire2"))
        {
            if(modo == 0)
                Application.LoadLevel("Main Menu");
            else if(modo == 1)
                Application.LoadLevel(Application.loadedLevel);
            else if(modo == 2)
                Application.LoadLevel(Application.loadedLevel);
        }

		if (Input.GetKeyDown("return") || Input.GetButton("Fire1"))
        {
            if (modo == 0)
            {
                switch (selecao)
                {
                    case 0:                        
                        criarsala.transform.position = posicao_popup.transform.position;
                        entrarsala.transform.position = posicao_inativo.transform.position;
                        entrar.transform.position = posicao_inativo.transform.position;
                        criar.transform.position = posicao_inativo.transform.position;
                        modo = 1;
                        break;
                    case 1:                        
                        entrarsala.transform.position = posicao_popup.transform.position;
                        criarsala.transform.position = posicao_inativo.transform.position;
                        entrar.transform.position = posicao_inativo.transform.position;
                        criar.transform.position = posicao_inativo.transform.position;
                        modo = 2;
                        break;
                }
            }
            else if (modo == 1)
                Debug.Log("Criar Sala");
            else if (modo == 2)
                Debug.Log("Entrar em sala");           

        }
	}
}
