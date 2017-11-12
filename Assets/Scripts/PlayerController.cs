using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float maxSpeed = 7f;
	public float moveForce = 200f;
	public float jumpForce = 200f;
	
	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		if(moveHorizontal* rb2d.velocity.x < maxSpeed){
			//rb2d.AddForce (Vector2.right * moveHorizontal * moveForce);
			rb2d.velocity = new Vector2 (moveForce * moveHorizontal, rb2d.velocity.y);
		}
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}


		if (Input.GetButtonDown ("Jump")) {
			rb2d.AddForce (new Vector2 (0f, jumpForce));
		}
	}
}
