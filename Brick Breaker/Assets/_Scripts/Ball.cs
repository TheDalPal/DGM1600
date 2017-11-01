using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public GameObject paddle;

	bool playing = false;
	Vector3 PaddleToBallVector; // distance from ball to paddle
	Rigidbody2D rigid;

	void Start () {
		
		PaddleToBallVector = this.transform.position - paddle.transform.position;
		rigid = this.GetComponent<Rigidbody2D> ();

	}
	

	void Update () {
		if (!playing) {
			this.transform.position = paddle.transform.position + PaddleToBallVector;

			if(Input.GetMouseButtonDown(0)) {

				rigid.velocity = new Vector2 (7, 17);
				playing = true;
			}
		}

	}
}
