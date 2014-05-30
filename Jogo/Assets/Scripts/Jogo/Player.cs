using UnityEngine;
using System.Collections;

public enum Direction 
{
	Up = 1,
	Down = 2,
	Right = 3,
	Left = 4
}

public enum CharClass 
{
	Warrior = 1,
	Barbarian,
	Paladin,
	Thief,
	Archer
}

public enum ItemType 
{
	Bow = 1,
	Shield,
	LargeShield,
	Speedy,
	Beer
}

public class Player : MonoBehaviour 
{
	private Rigidbody2D rigidbody2d;
	private Animator animatorController;
	private int totalDeaths = 0;
	private bool midAir = false;
	private float percentual = 0f;
	private float eggTime = 0;
	private Egg egg;
	private float diengTime = 0;
	private float jumpDirection = 0;
	private float swordTime = 0;
	public float arrowAttackTime = 0;

	public bool On = false;
	public float MovieSpeed = 5;
	public float JumpSpeed = 7;
	public CharClass playerClass = CharClass.Archer;
	public bool IsRunning = false;
	public bool IsJumping = false;
	public bool IsSliding = false;
	public bool IsAttacking = false;
	public bool WithEgg = false;
	public bool NormalShield = false;
	public bool DoubleShield = false;
	public bool Bebado = false;
	public bool Dyieng = false;
	public bool hasBow = false;
	public bool IsAttackingArrow = false;
	public Direction Direction = Direction.Left;
	public ParticleSystem[] DustParticles;
	public ParticleSystem BubblusParticle;
	public GameObject NormalShieldObject;
	public GameObject DoubleShieldObject;
	public Transform EggPlace;
	public Transform Sight;
	public Transform Spawn;
	public GameObject ArrowPrefab;
	public HUDBar HUDBar;
	public float LevelTime;	
	public Sword AttackFront;
	public Sword BottonAttack;
	public Sword TopAttack;

	void Start () 
	{
		rigidbody2d = this.GetComponent<Rigidbody2D>();
		animatorController = this.GetComponent<Animator>();
	}
	
	void Update () 
	{
		GenereteAnimation();

		if (WithEgg)
			eggTime += Time.deltaTime;

		TopAttack.On = BottonAttack.On = AttackFront.On = false;
		if (IsAttacking) {
			swordTime += Time.deltaTime;
			if (this.Direction == Direction.Up)
				TopAttack.On = true;
			else if (this.Direction == Direction.Down)
				BottonAttack.On = true;
			else
				AttackFront.On = true;
		}

		if (Dyieng) {
			diengTime += Time.deltaTime;
			if (diengTime > 1f)
			{
				Dyieng = false;
				diengTime = 0;
				Respawn();
			}
		}

		if (IsAttackingArrow) {
			arrowAttackTime += Time.deltaTime;
			if (arrowAttackTime > 1f)
			{
				if (hasBow) {
					CreateArrow();
					hasBow = false;
				}
				if (arrowAttackTime > 1.5f)
				{
					IsAttackingArrow = false;
					arrowAttackTime = 0;
				}
			}
		}
				
		HUDBar.UpdateBar(playerClass, eggTime/LevelTime);
	}

	private void Respawn()
	{
		this.transform.position = Spawn.position;
	}

	private void GenereteAnimation()
	{
		animatorController.SetInteger("PlayerClass", (int)playerClass); 
		animatorController.SetBool("IsRunning", IsRunning);
		animatorController.SetBool("IsJumping", IsJumping);
		animatorController.SetBool("IsSliding", IsSliding);
		animatorController.SetBool("IsAttacking", IsAttacking);
		animatorController.SetBool("IsDyieng", Dyieng);
		animatorController.SetBool("IsAttackingArrow", IsAttackingArrow);
		animatorController.SetInteger("Direction", (int)this.Direction);
		if (Bebado) {
			if (!BubblusParticle.isPlaying)
				BubblusParticle.Play();
		}
		else
			if (BubblusParticle.isPlaying)
				BubblusParticle.Stop();
		
		NormalShieldObject.SetActive(NormalShield || DoubleShield);
		DoubleShieldObject.SetActive(DoubleShield);

		//if (IsAttackingArrow)
		//	Invoke("createArrow", 0.5f);
	}

	private void CreateArrow() 
	{
		GameObject go = (GameObject)Instantiate(ArrowPrefab, Sight.position, Sight.rotation);
		Arrow arrow = go.GetComponent<Arrow> ();
		arrow.transform.localScale = Sight.transform.localScale;	
	}


	public void Move(float direction, bool jump)
	{
		if (On) {
			float velocityX = MovieSpeed;

			if (jump && (!midAir || IsSliding)) {
					IsJumping = true;
					midAir = true;
					IsSliding = false;
					rigidbody2d.velocity = new Vector3 (rigidbody2d.velocity.x, JumpSpeed, 0.0f);

					jumpDirection = transform.localScale.x;
			}

			IsRunning = (direction != 0);
			if (direction != 0) {
					if (midAir && transform.localScale.x != jumpDirection)
							velocityX /= 2;

					if (direction < 0) {
							this.Direction = Direction.Left;
							if (IsSliding)
									transform.localScale = new Vector3 (0.6641114f, transform.localScale.y, transform.localScale.z);
							else 
									transform.localScale = new Vector3 (-0.6641114f, transform.localScale.y, transform.localScale.z);

					} else if (direction > 0) {
							this.Direction = Direction.Right;
							if (IsSliding)
									transform.localScale = new Vector3 (-0.6641114f, transform.localScale.y, transform.localScale.z);
							else 
									transform.localScale = new Vector3 (0.6641114f, transform.localScale.y, transform.localScale.z);
					}


			}
			if (!IsSliding)
					rigidbody2d.velocity = new Vector3 (velocityX * direction, rigidbody2d.velocity.y, 0.0f);
		}
	}

	public void Attack(float direction, bool attacking)
	{
		if (On) {
			if (attacking) {
					IsAttacking = true;
					swordTime = 0;
			} else if (swordTime > 0.5f) 
					IsAttacking = false;

			if (direction > 0)
					this.Direction = Direction.Up;
			else if (direction < 0)
					this.Direction = Direction.Down;
		}
	}

	public void SpecialAttack()
	{
		if (On) 
			if (hasBow)
				IsAttackingArrow = true;
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		switch (collision.collider.tag) 
		{
			case "Solido":
				IsJumping = IsSliding = midAir = false;
				break;

			case "Wall":
				IsRunning = false;
				IsSliding = true;
				break;
				
			case "Fogo":
				Hit();
				break;

			case "Ovo":
				GetEgg(collision.gameObject);
				break;

			case "Item":
				GetItem(collision.gameObject);
				Destroy(collision.gameObject);
				break;
		}
	}

	void OnCollisionExit2D(Collision2D collision) 
	{
		IsSliding = false;
	}

	public void Hit()
	{
		rigidbody2d.velocity = new Vector3(rigidbody2d.velocity.x, 3f, 0.0f);
		if (DoubleShield) 
		{
			DoubleShield = false;
			NormalShield = true;
		}
		else if (NormalShield)
			NormalShield = false;
		else if (!Dyieng)
			Die();
	}

	private void Die() 
	{
		if (WithEgg) 
		{
			WithEgg = false;
			egg.IsFlying = false;
		} 
		else if (eggTime >= 1)
			eggTime -= totalDeaths;

		totalDeaths++;
		Dyieng = true;
	}

	private void GetEgg(GameObject item) 
	{
		WithEgg = true;
		this.egg = item.GetComponent<Egg>();
	}

	private void GetItem(GameObject gameObject) 
	{
		Item item = gameObject.GetComponent<Item>();
		switch (item.Type) 
		{
			case ItemType.Shield:
				NormalShield = true;
				break;

			case ItemType.LargeShield:
				DoubleShield = true;
				break;

			case ItemType.Bow:
				hasBow = true;
				break;
		}
	}

	private void PlayJumpingDust()
	{
		foreach(ParticleSystem particle in DustParticles)
			particle.Play();
	}

}
