using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public float arrowVel;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(arrowVel, 0, 0) * Time.deltaTime;
	}

	void OnCollisionEnter (Collision collision) {
		Destroy (gameObject);
	}
}
