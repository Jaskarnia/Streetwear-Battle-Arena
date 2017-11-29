using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float maxSpeed = 7f;
	public float moveForce = 200f;
	public float jumpForce = 300f;
    private bool canjump = false;
	private bool walking = false;
	private Animator anim;
	public Transform player2Location;
	private bool facingLeft = true;

	void Awake(){
		anim = gameObject.GetComponent<Animator>();
	}

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
	}


	void Update(){

		anim.SetBool("WalkActive", walking);
		if (walking) {
			walking = false;
		}

	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Player1Horizontal");

		if (moveHorizontal != 0) {
			walking = true;
		} else {
			walking = false;
		}

        if(moveHorizontal* rb2d.velocity.x < maxSpeed){
			rb2d.velocity = new Vector2 (moveForce * moveHorizontal, rb2d.velocity.y);
			
		}
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
			
		}

        if (Input.GetKeyDown("w") && canjump == true)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            canjump = false;
        }

		if ((transform.position.x > player2Location.position.x && facingLeft) || transform.position.x<player2Location.position.x && !facingLeft) {
			transform.localScale = new Vector3(-transform.localScale.x,1,1);
			facingLeft = !facingLeft;
		}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canjump = true;
        }
    }

}
