using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanye1Attack : MonoBehaviour {

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
	private Player1Controller p1con;

	public Rigidbody2D shot;

    void Awake()
    {
		GameObject player1Object = GameObject.FindGameObjectWithTag ("Player1");
		if (player1Object != null)
		{
			p1con = player1Object.GetComponent <Player1Controller>();
		}
		if (p1con == null)
		{
			Debug.Log ("Cannot find 'Player1Controller' script");
		}
	
        anim = gameObject.GetComponent<Animator>();
		rb = this.GetComponent (typeof(Rigidbody2D)) as Rigidbody2D;
        attackcol.enabled = false;
		attackcol2.enabled = false;
		attackcol3.enabled = false;
    }
		
    void Update()
    {
		direction= p1con.facingLeft? 1: -1;
		if (Input.GetKey ("q") && !crouching) {
			crouching = true;
		}
        else if( Input.GetKeyUp("f") && !attacking)
        {
			
            attacking = true;
            attackTimer = attackCooldown;
            attackcol.enabled = true;
//			rb.AddForce (transform.right * attackMoveForce);
        }

		else if( Input.GetKeyUp("g") && !attackcombo2) {
			attackcombo2 = true;
			attackTimer = attackCooldown;
			attackcol3.enabled = true;
//			rb.AddForce (transform.right * attackMoveForce*direction*2);

		} 

		if (attacking) {
			if (attackTimer > 0) {
				if (Input.GetKeyDown ("f") && !attackcombo1) {
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
				if (Input.GetKeyUp ("g") && attackcombo2) {
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
			if (Input.GetKey ("q")) {
				crouching = true;
			} else {
				crouching = false;
			}
		}

		attackTimer -= Time.deltaTime;
        

		if(Input.GetKeyDown("t")){
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
