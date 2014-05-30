using UnityEngine;
using System.Collections;

public class criarsala : MonoBehaviour {

    public string sala = "";
    private Vector3 posicao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        posicao = Camera.main.WorldToScreenPoint(transform.position);
	
	}

    void OnGUI()
    {
        GUI.skin.textField.normal.background = null;
        GUI.skin.textField.active.background = null;
        GUI.skin.textField.onHover.background = null;
        GUI.skin.textField.hover.background = null;
        GUI.skin.textField.onFocused.background = null;
        GUI.skin.textField.focused.background = null;
        GUI.skin.textField.normal.textColor = Color.black;
        sala = GUI.TextField(new Rect(posicao.x, Screen.height - posicao.y, 275, 20), sala);
    }
}
