using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public Animator animatorController;
	public SpriteRenderer spriteRenderer;
	public ParticleSystem steamParticle;
	public ParticleSystem[] dustParticles;
	public bool midAir = false;
	public bool attacking = false;
	public Arrow arrowPrefab;
	public Transform mira;
	public int numOfArrows = 1;
	public float moveSpeed = 5;
	public float jumpSpeed = 6;
	public float jumpDirection;
	public Transform checkPoint;
	public float swordTime = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float run = Input.GetAxis ("Horizontal");
		bool jump = Input.GetButton ("Jump");
		bool attack = Input.GetButton ("Fire1");
		bool arrowAttack = Input.GetButton ("Fire2");
		bool rageTest = Input.GetKey (KeyCode.R);
		
		if (rageTest) {
			spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1);
			steamParticle.Play();
		}
		
		MakeRun (run);
		MakeJump (jump);
		MakeSwordAttack (attack);
		MakeArrowAttack (arrowAttack);
	}
	
	void MakeRun (float run) {
		// Make run editing velocity
		if (run != 0) {
			animatorController.SetBool ("running", true);
			
			if (run > 0) {
				if(animatorController.GetCurrentAnimatorStateInfo(0).IsName("WarriorWallSliding"))
					transform.localScale = new Vector3(-1, 1, 1);
				else
					transform.localScale = new Vector3(1, 1, 1);
				
				// Make the character back with lower speed when in mid air
				if (midAir && transform.localScale.x != jumpDirection)
					rigidbody.velocity = new Vector3(moveSpeed/2 * run, rigidbody.velocity.y, 0.0f);
				else
					rigidbody.velocity = new Vector3(moveSpeed * run, rigidbody.velocity.y, 0.0f);
			} else {
				if(animatorController.GetCurrentAnimatorStateInfo(0).IsName("WarriorWallSliding"))
					transform.localScale = new Vector3(1, 1, 1);
				else
					transform.localScale = new Vector3(-1, 1, 1);
				
				if (midAir && transform.localScale.x != jumpDirection)
					rigidbody.velocity = new Vector3(moveSpeed/2 * run, rigidbody.velocity.y, 0.0f);
				else
					rigidbody.velocity = new Vector3(moveSpeed * run, rigidbody.velocity.y, 0.0f);
			}
		} else {
			// No inertia
			Vector3 idleVel = new Vector3(0, gameObject.rigidbody.velocity.y, 0);
			
			gameObject.rigidbody.velocity = idleVel;
			
			animatorController.SetBool ("running", false);
		}
		
		// Make run adding force
		//		if (run != 0) {
		//			animatorController.SetBool ("running", true);
		//			if (run > 0) {
		//				if(gameObject.rigidbody.velocity.x <= 5 && !attacking) {
		//					gameObject.rigidbody.AddForce (new Vector3(gameObject.rigidbody.mass * 16.5f, 0, 0));
		//
		//					transform.localScale = new Vector3(1, 1, 1);
		//				}
		//			} else {
		//				if(gameObject.rigidbody.velocity.x >= -5 && !attacking) {
		//					gameObject.rigidbody.AddForce (new Vector3(-gameObject.rigidbody.mass * 16.5f, 0, 0));
		//
		//					transform.localScale = new Vector3(-1, 1, 1);
		//				}
		//			}
		//		} else {
		//			Vector3 idleVel = new Vector3(0, gameObject.rigidbody.velocity.y, 0);
		//			float slowTime;
		//			if (midAir)
		//				slowTime = 1.0f;
		//			else
		//				slowTime = 2.0f;
		//
		//			gameObject.rigidbody.velocity = Vector3.Lerp(gameObject.rigidbody.velocity, idleVel, slowTime * Time.deltaTime);
		//
		//			animatorController.SetBool ("running", false);
		//		}
	}
	
	void MakeJump(bool jump) {
		// Make jump editing velocity
		if (jump && !midAir) {
			midAir = true;
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpSpeed, 0.0f);
			
			animatorController.SetBool ("jumping", true);
			
			PlayDust();

			jumpDirection = transform.localScale.x;
		}

		// Add vel negativa na queda pra cair mais rapido
		
		// Make jump adding force
		//		if (jump && !midAir) {
		//			midAir = true;
		//			gameObject.rigidbody.AddForce (new Vector3(0, gameObject.rigidbody.mass * 300, 0));
		//			
		//			animatorController.SetBool ("jumping", true);
		//		}
	}
	
	void MakeSwordAttack (bool attack) {
		if (!animatorController.GetCurrentAnimatorStateInfo(0).IsName("WarriorAttackingFront") && !animatorController.GetCurrentAnimatorStateInfo(0).IsName("WarriorStandAtackArrow")) {
			attacking = false;
			animatorController.SetBool ("attacking", false);
		}
		
		if (attacking) {
			swordTime += Time.deltaTime;
		} else {
			swordTime = 0;
		}
		
		if (attack && !attacking) {
			attacking = true;
			animatorController.SetBool ("attacking", true);
		}
		
		if(swordTime > 0.1f){
			print (@"Cast");
			
			Ray swordRange = new Ray (transform.position, transform.right);
			RaycastHit swordHit;
			Physics.Raycast (swordRange, out swordHit, 1.2f);
			
			if(swordHit.rigidbody != null){
				swordHit.rigidbody.AddForce(transform.right*10,ForceMode.Impulse);
			}
			
			//swordTime = 0;
			//animatorController.SetBool("attacking",false);
			//Instantiate(shot,transform.position,transform.rotation);
		}
	}
	
	void MakeArrowAttack (bool arrowAttack) {
		if (!animatorController.GetCurrentAnimatorStateInfo(0).IsName("WarriorStandAtackArrow") && !animatorController.GetCurrentAnimatorStateInfo(0).IsName("WarriorAttackingFront")) {
			attacking = false;
			animatorController.SetBool ("attackingArrow", false);
			numOfArrows = 1;
		}
		
		if (arrowAttack && !attacking && !midAir) {
			attacking = true;
			animatorController.SetBool ("attackingArrow", true);
			
			Invoke("createArrow", 0.5f);
		}
	}
	
	void createArrow () {
		if (numOfArrows >= 1) {
			numOfArrows--;
			Arrow arrow = (Arrow) Instantiate(arrowPrefab, mira.position, mira.rotation);
			arrow.transform.localScale = gameObject.transform.localScale;
			arrow.arrowVel = 10 * gameObject.transform.localScale.x;
		}
	}
	
	void OnCollisionEnter (Collision collision) {
		print (rigidbody.velocity.y);
		if (collision.gameObject.tag.Equals ("Terrain") && rigidbody.velocity.y < 0.1) {
			animatorController.SetBool ("jumping", false);
			animatorController.SetBool("wallsliding", false);
			PlayDust();
			
			midAir = false;
		} else if (collision.gameObject.tag.Equals ("Wall")) {
			animatorController.SetBool("wallsliding", true);
		}
	}

	void OnCollisionExit (Collision collision) {
		animatorController.SetBool("wallsliding", false);
	}
	
	void PlayDust() {
		foreach(ParticleSystem dust in dustParticles) {
			dust.Play();
		}
	}
}
