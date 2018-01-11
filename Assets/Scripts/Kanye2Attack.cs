using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanye2Attack : MonoBehaviour {

	private bool attacking = false;
	private bool crouching = false;
	private bool attackcombo1 = false;
	private bool attackcombo2 = false;
	private float attackTimer = 0;
	private float attackCooldown = 0.2f;
	public float attackMoveForce;

	public Collider2D attackcol;
	public Collider2D attackcol2;
	public Collider2D attackcol3;
	private float direction;
	private Animator anim;
	private Rigidbody2D rb;

	private Player2Controller p2con;
	public Rigidbody2D shot;

	void Awake()
	{
		GameObject player2Object = GameObject.FindGameObjectWithTag ("Player2");
		if (player2Object != null)
		{
			p2con = player2Object.GetComponent <Player2Controller>();
		}
		if (p2con == null)
		{
			Debug.Log ("Cannot find 'Player2Controller' script");
		}

		anim = gameObject.GetComponent<Animator>();
		rb = this.GetComponent (typeof(Rigidbody2D)) as Rigidbody2D;
		attackcol.enabled = false;
		attackcol2.enabled = false;
		attackcol3.enabled = false;
	}

	void Update()
	{
		direction= p2con.facingLeft? -1: 1;
		if (Input.GetKey (",") && !crouching) {
			crouching = true;
		}
		else if( Input.GetKeyUp("/") && !attacking)
		{

			attacking = true;
			attackTimer = attackCooldown;
			attackcol.enabled = true;
			//			rb.AddForce (transform.right * attackMoveForce);
		}

		else if( Input.GetKeyUp(".") && !attackcombo2) {
			attackcombo2 = true;
			attackTimer = attackCooldown;
			attackcol3.enabled = true;
			//			rb.AddForce (transform.right * attackMoveForce*direction*2);

		} 

		if (attacking) {
			if (attackTimer > 0) {
				if (Input.GetKeyDown ("/") && !attackcombo1) {
					attackcombo1 = true;
					attackTimer = attackCooldown;
					attackcol2.enabled = true;
					rb.AddForce (transform.right * attackMoveForce * direction);

				} else {
					//					attackTimer -= Time.deltaTime;
				}
			} else {
				attacking = false;
				attackcombo1 = false;
				attackcombo2 = false;
				attackcol.enabled = false;
				attackcol2.enabled = false;
				attackcol3.enabled = false;
			}
		}

		else if (attackcombo2) {
			if (attackTimer > 0) {
				if (Input.GetKeyUp (".") && attackcombo2) {
					rb.AddForce (transform.right * attackMoveForce * direction);
				} else {
					//					attackTimer -= Time.deltaTime;
				}
			} else {

				attackcombo2 = false;
				attackcol3.enabled = false;
			}
		}
		else if (crouching) {
			if (Input.GetKey (",")) {
				crouching = true;
			} else {
				crouching = false;
			}
		}

		attackTimer -= Time.deltaTime;


		if(Input.GetKeyDown("'")){
			//			Quaternion shotQuat = transform.rotation;
			//			shotQuat.eulerAngles = new Vector3(0,180,0);
			Rigidbody2D shotInstance = Instantiate(shot, transform.position, transform.rotation) as Rigidbody2D;
			shotInstance.transform.localScale = new Vector3 (direction, 1,1);
			shotInstance.velocity = new Vector2 (direction*20, 0);
		}

		anim.SetBool("AttackActive", attacking);
		anim.SetBool ("AttackCombo1", attackcombo1);
		anim.SetBool ("AttackCombo2", attackcombo2);
		anim.SetBool ("IsCrouched", crouching);
		//		rb.AddForce (transform.right * attackMoveForce);

	}

}
