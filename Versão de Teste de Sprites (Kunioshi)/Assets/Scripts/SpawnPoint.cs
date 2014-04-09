using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public Material startMat;
	public Material ativatedMat;
	public GameObject checkPointCube;

	// Use this for initialization
	void Start () {
		// Change self colors
		particleSystem.startColor = startMat.color;
		
		checkPointCube.renderer.material = startMat;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 2, 0);
	}

	void OnTriggerEnter (Collider other) {
		if (other.collider.tag.Equals("Player")) {
			// Change player's check point
			Character playerScript = other.GetComponent<Character>();
			playerScript.checkPoint = transform;

			// Change self colors
			particleSystem.startColor = ativatedMat.color;

			checkPointCube.renderer.material = ativatedMat;
		}
	}
}
