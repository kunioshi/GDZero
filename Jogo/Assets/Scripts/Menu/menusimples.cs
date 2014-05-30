using UnityEngine;
using System.Collections;

public class menusimples : MonoBehaviour {

    bool jogar = false;
    public GameObject play;
    public GameObject back;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

		if (Input.GetKeyDown("escape") || Input.GetButton("Fire2"))
        {
                Application.LoadLevel("Main Menu");            

        }

	
	}
}
