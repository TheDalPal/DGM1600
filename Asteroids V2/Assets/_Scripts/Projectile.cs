using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float lifetime;

	void Start ()
	{

	}

	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy (this.gameObject);
		}

	}
		

	void OnCollisionEnter2D (Collision2D Collider)
	{
		Destroy(this.gameObject);

	}
}
