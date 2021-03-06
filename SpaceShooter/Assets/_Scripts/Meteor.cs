﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour {

	public float spin;

	public float score;

	public GameObject explosion;

	private Rigidbody2D rb;

	public float thrust;
	float randomRotate = 25;

	public int scoreValue;
	GameController gameController;

	public AudioSource boom;


	void Start () 
	{	boom = GetComponent<AudioSource> ();
		
		rb = GetComponent<Rigidbody2D> (); 
		//look at center 
		transform.LookAt (Vector3.zero);
		//Transform vector 3 to render 2D
		transform.Rotate (0,90,90);
		transform.Rotate (0,0,Random.Range(-randomRotate,randomRotate));
		//add force
		rb.AddForce(transform.up * thrust);
		rb.AddTorque(Random.Range(-spin,spin),ForceMode2D.Impulse);

		//find game controller script
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();

		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
			
	}
	void Update()
	{
		StartCoroutine (IncreaseThrust ());
	}

	void OnCollisionEnter2D (Collision2D Collider)
	{
		boom.Play ();
		Destroy(this.gameObject);
		Instantiate(explosion, transform.position, Quaternion.identity);
		gameController.AddScore (scoreValue);

	}
	IEnumerator IncreaseThrust()
	{
		yield return new WaitForSeconds (1);
		thrust++;
	}
}
