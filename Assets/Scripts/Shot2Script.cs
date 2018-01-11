using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot2Script : MonoBehaviour {

	private Player1Health player1Health;
	public int dmg = 5;

	// Use this for initialization
	void Start ()
	{
		GameObject player1Object = GameObject.FindGameObjectWithTag ("Player1");
		if (player1Object != null)
		{
			player1Health = player1Object.GetComponent <Player1Health>();
		}
		if (player1Health == null)
		{
			Debug.Log ("Cannot find 'Player1Health' script");
		}
//		Debug.Log ("game started");
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.CompareTag("Player1"))
		{
			player1Health.TakeDamage (dmg);
			Collider2D collider = gameObject.GetComponentInParent(typeof(Collider2D)) as Collider2D;
			if (collider != null)
				collider.enabled = false;
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
