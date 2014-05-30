using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour 
{
	private Animator animatorController;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidbody2d;
	private Transform EggPlace;
	public Transform SpawnPoint;
	public bool IsFlying = false;
	public bool IsBaby = false;

	void Start () 
	{
		animatorController = this.GetComponent<Animator>();
		boxCollider = this.GetComponent<BoxCollider2D>();
		rigidbody2d = this.GetComponent<Rigidbody2D>();
	}

	void Update() 
	{
		animatorController.SetBool ("IsFlying", IsFlying);
		animatorController.SetBool ("IsBaby", IsBaby);

		boxCollider.isTrigger = IsFlying;
		rigidbody2d.isKinematic = IsFlying;
		if (IsFlying)
			this.transform.position = EggPlace.position;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		switch (collision.collider.tag) 
		{
			case "Fogo":
				Spawn();
				break;
			
			case "Player":
				Player player = collision.collider.gameObject.GetComponent<Player>();
				this.EggPlace = player.EggPlace;
				IsFlying = true;
				break;
		}	
	}

	private void Spawn()
	{
		StartCoroutine(Timer());
	}

	private IEnumerator Timer() 
	{
		yield return new WaitForSeconds(1);
		this.transform.position = this.SpawnPoint.position;

	}
}