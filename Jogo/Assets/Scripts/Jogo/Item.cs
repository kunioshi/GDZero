using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
	private Animator animatorController;
	public ItemType Type;
	public System.DateTime CreateTime; 

	void Start() 
	{
		animatorController = this.GetComponent<Animator>();
		CreateTime = System.DateTime.Now;
		GenereteItem();
	}
	
	void Update() 
	{
		animatorController.SetInteger("ItemType", (int)Type); 
	}

	private void GenereteItem()
	{
		this.Type = (ItemType)Random.Range(1, 4);
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		switch (collision.collider.tag) 
		{
			case "Fogo":
				Destroy(collision.gameObject);
				break;

			case "Item":
				Item item = collision.gameObject.GetComponent<Item>();
				if (item.CreateTime < this.CreateTime)
					Destroy(collision.gameObject);
				break;
		}	
	}
}
