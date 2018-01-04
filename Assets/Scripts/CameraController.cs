using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject player2;
	private Vector3 offset;
	public Camera orthoCam;
//	float dist;
//	float leftBorder;
//	float rightBorder;
//	float topBorder;
//	float bottomBorder;

	void Start () {
		//offset = transform.position - ((player2.transform.position + player.transform.position));
//		offset=transform.position - (player.transform.position + player2.transform.position) * 0.5f;

	}

	// Update is called once per frame
	void LateUpdate () {
//		dist = (transform.position - Camera.main.transform.position).z;
//		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
//		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
//		bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
//		topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
//		orthoCam.orthographicSize = Vector3.Distance (player.transform.position, player2.transform.position);

		orthoCam.orthographicSize =.4f* Vector3.Distance (player.transform.position, player2.transform.position) + 5.0f;
		transform.position = new Vector3(((player.transform.position.x + player2.transform.position.x)/2.0f),((player.transform.position.y + player2.transform.position.y)/2.0f),-10) ;

//		if (player.transform.position.y < bottomBorder || player2.transform.position.y < bottomBorder ||player.transform.position.y > topBorder || player2.transform.position.y >topBorder) {
//			orthoCam.orthographicSize += 10.5f;
//		}
	}
}
