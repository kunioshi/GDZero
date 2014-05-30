using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
	public float arrowVel = 10;

	void Start() 
	{
	}
	
	void Update()
	{
		transform.position += new Vector3(arrowVel, 0, 0) * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		Destroy(gameObject);
	}
}
