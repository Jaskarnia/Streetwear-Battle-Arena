using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanye1Attack : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCooldown = 0.3f;

    public Collider2D attackcol;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackcol.enabled = false;
    }
		
    void Update()
    {
        if( Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = attackCooldown;
            attackcol.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackcol.enabled = false;
            }
        }

        anim.SetBool("AttackActive", attacking);

    }
    
}
