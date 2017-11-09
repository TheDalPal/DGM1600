using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	public float spin;


	void Start () {
		GetComponent<Rigidbody2D> ().AddTorque(Random.Range(-spin,spin),ForceMode2D.Impulse);
	}
	
	void OnCollisionEnter2D (Collision2D Collider){

			Destroy(this.gameObject);
		}
	void Update () {

		
	}
}
