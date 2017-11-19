using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1col : MonoBehaviour {

	private Player2Health player2Health;

    public int dmg = 20;

	void Start ()
	{
		GameObject player2Object = GameObject.FindGameObjectWithTag ("Player2");
		if (player2Object != null)
		{
			player2Health = player2Object.GetComponent <Player2Health>();
		}
		if (player2Health == null)
		{
			Debug.Log ("Cannot find 'Player2Health' script");
		}
		Debug.Log ("game started");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		
        if (other.CompareTag("Player2"))
        {
			player2Health.TakeDamage (dmg);
        }
    }

}
