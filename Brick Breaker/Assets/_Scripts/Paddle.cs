using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float paddleHeight;

	private Transform paddleTrans;


	void Start() {
		paddleTrans = gameObject.GetComponent<Transform> ();
	}

	void Update() {
		
		//paddle follow mouse
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//override y possition
		mousePos.y = paddleHeight;
		//Override z depth
		mousePos.z = 0;
		paddleTrans.position = mousePos;
	}
}
