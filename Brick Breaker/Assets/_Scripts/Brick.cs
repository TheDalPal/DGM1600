using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int health;

	void OnCollisionEnter2D (Collision2D Collider){

		health--;

		if (health <= 0) {
			Destroy(this.gameObject);
		}

	}

}
