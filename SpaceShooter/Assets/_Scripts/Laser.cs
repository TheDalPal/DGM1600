using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public float lifetime;
	float speed= 5;


	void OnCollisionEnter2D (Collision2D Collider){

		Destroy(this.gameObject);
	}
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy (this.gameObject);
		}

	}
}
