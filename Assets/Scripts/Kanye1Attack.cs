using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanye1Attack : MonoBehaviour {

    private bool attacking = false;
	private bool attackcombo1 = false;
    private float attackTimer = 0;
    private float attackCooldown = 0.2f;
	public float attackMoveForce;

    public Collider2D attackcol;
	public Collider2D attackcol2;
	private float direction;
    private Animator anim;
	private Rigidbody2D rb;
	private Player1Controller p1con;

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
    }
		
    void Update()
    {
		direction= p1con.facingLeft? 1: -1;
        if( Input.GetKeyDown("f") && !attacking)
        {
			
            attacking = true;
            attackTimer = attackCooldown;
            attackcol.enabled = true;
//			rb.AddForce (transform.right * attackMoveForce);
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
				if( Input.GetKeyDown("f") && !attackcombo1) {
					attackcombo1 = true;
					attackTimer = attackCooldown;
					attackcol2.enabled = true;
					rb.AddForce (transform.right * attackMoveForce*direction);

				} else {
					attackTimer -= Time.deltaTime;
				}
            }
            else
            {
                attacking = false;
				attackcombo1 = false;
                attackcol.enabled = false;
				attackcol2.enabled = false;
            }
        }

        anim.SetBool("AttackActive", attacking);
		anim.SetBool ("AttackCombo1", attackcombo1);
//		rb.AddForce (transform.right * attackMoveForce);

    }
    
}
