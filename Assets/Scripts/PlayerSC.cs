using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSC : MonoBehaviour {


	private bool isGrounded;
	private float speed;
	private float maxSpeed;
	private float jumpForce;
	private Rigidbody2D rb2d;
	private float jumpResistance;
	private Animator anim;
	private SpriteRenderer spRen;



	private const int maxHealth = 300;
	private int currentHeath = maxHealth;

	public Text casCount;
	public static int CassetteCount = 0;
	public Slider healthSlider;
	public bool onTune;

	void Awake () {
		casCount.text = "0";
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		onTune = false;
		speed = 50f;
		maxSpeed = 5f;
		jumpForce = 600f;
		jumpResistance = .9f;
		rb2d = GetComponent <Rigidbody2D> ();
		spRen = GetComponent <SpriteRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!TubularTransmission.mixTapeOn) {
			
			float axisH = Input.GetAxis ("Horizontal");
			if (axisH >= .02f) {
				spRen.flipX = false;
			} else if (axisH <= -.02f) {
				spRen.flipX = true;
			}


			if (rb2d.velocity.x >= .02f && !isGrounded) {
				anim.SetTrigger ("Skate");

			} else if (rb2d.velocity.x <= -.02f && !isGrounded) {
				anim.SetTrigger ("Skate");

			} else {
				anim.SetTrigger ("Idle");
			}

			rb2d.AddForce (new Vector2 (speed * axisH, rb2d.velocity.y));

			if (rb2d.velocity.x >= maxSpeed) {
				rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
			} else if (rb2d.velocity.x <= -maxSpeed) {
				rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
			}
			if (Input.GetKeyDown (KeyCode.Space) && !isGrounded) {
				if (rb2d.velocity.y <= jumpResistance && rb2d.velocity.y >= -jumpResistance) {
					isGrounded = true;
					anim.SetTrigger ("Jump");
					rb2d.AddForce (Vector2.up * jumpForce);	
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
			isGrounded = false;
			anim.SetTrigger("Idle");
		if (coll.gameObject.tag == "Cassette") {
			GetComponentInChildren<WalkManSc>().PlayJam(coll.gameObject.GetComponent <CassetteSC>().song);
			CassetteCount++;
			casCount.text = CassetteCount.ToString ();
			PowerUp (coll.gameObject.GetComponent <CassetteSC>().powerUp);
			Destroy (coll.gameObject);
		
		}

	}
	void OnCollisionStay2D(Collision2D coll) {
		isGrounded = false;
	}
	void OnCollisionExit2D (Collision2D coll) {
		
	}


//	void OnTriggerStay2D (Collider2D col) {
//		if (col.tag == "Zombie") {
//			Debug.Log ("You are being zombified");
//			Zombified (1);
//		}
//	}



	void SpeedUp() {
		speed = 80f;
		maxSpeed = 8f;
		jumpResistance = 1f;
	}
	//void Speed

	void StrenghtUp() {
		
	}



	void PowerUp(string power) {
		if (power == "power") {
			//StrenghtUp ();
		}
		else if (power == "speed") {
			//SpeedUp ();
		}
		else if (power == "something") {

		}
	}

	public void Zombified (int amount) {
		healthSlider.value = currentHeath;
		currentHeath -= amount;
		if (currentHeath <= 0) {
			currentHeath = 0;
			YoureZombie();
		}
	}

	public void YoureZombie() {
		Debug.Log ("You are a zombie");
		GameControl.PlayerDied ();

	}


}
