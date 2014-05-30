using UnityEngine;
using System.Collections;

public class HUDItemBar : MonoBehaviour 
{
	public Transform Point;
	public Transform Bar;
	public float Percentual;

	void Start() 
	{
	
	}
	

	void Update() 
	{
		Bar.position = new Vector3(Point.position.x + Percentual, Point.position.y, Point.position.z);
		Bar.localScale = new Vector3(Percentual, 1, 1);
	}
}

