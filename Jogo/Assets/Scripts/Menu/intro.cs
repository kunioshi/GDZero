using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour
{

    public TextMesh txtJogar;
    public TextMesh pressioneStart;
    public GameObject logo;
    public GameObject titulo;
    public GameObject itens;
    public GameObject blur;
    public Animator animTitulo;
    public Animator animLogo;
    bool introd = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (introd)
        {
			if (Input.GetKeyDown("return") || Input.GetButton("joystick button 7"))
            {
                Destroy(pressioneStart);
                Destroy(blur);
                this.animation.Play("ani_camera");
                itens.animation.Play("ani_itens");
                animTitulo.SetBool("intro", false);
                animLogo.SetBool("intro", false);
                introd = false;
            }
        }

    }
}
