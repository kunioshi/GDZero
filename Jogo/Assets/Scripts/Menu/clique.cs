using UnityEngine;
using System.Collections;

public class clique : MonoBehaviour {

    int selecao = 0;
    public int pos;
    bool intro;
	bool ControlVertical = true;

	// Use this for initialization
	void Start () {
        intro = true;
	
	}
	
	// Update is called once per frame
	void Update () {
               
		if(Input.GetAxis("Vertical") == 0)
	    {
			ControlVertical = true;
		}

        if (!intro)
        {
			if ((Input.GetKeyDown("down") || Input.GetAxis("Vertical") < 0) && selecao < 3 && ControlVertical)
            {
                selecao++;
				ControlVertical = false;
            }

			if ((Input.GetKeyDown("up") || Input.GetAxis("Vertical") > 0)  && selecao > 0 && ControlVertical)
            {
                selecao--;
				ControlVertical = false;
            }

            if (selecao == pos)
            {
                renderer.material.color = Color.yellow;
            }
            else
            {
                renderer.material.color = Color.white;
            }

			if (Input.GetKeyDown("return") || Input.GetButton("Fire1"))
            {
                switch (selecao)
                {
                    case 0:
                        Application.LoadLevel("CriarSala");
                        break;
                    case 1:
                        Application.LoadLevel("Instrucoes");
                        break;
                    case 2:
                        Application.LoadLevel("Creditos");
                        break;
                    case 3:
                        Application.Quit();
                        break;
                }

            }
        }
        else
        {
			if (Input.GetKeyDown("return") || Input.GetButton("joystick button 7"))
            {
                intro = false;
            }
        }
	
	}
}
