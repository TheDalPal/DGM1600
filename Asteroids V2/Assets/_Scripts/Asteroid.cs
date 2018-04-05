using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public float spin;
	public float lifetime;

	public float thrust;
	float randomRotate = 25;

	private Rigidbody2D rba;

	GameController gameController;
	public int scorevalue;

	AudioSource points;

	// Use this for initialization
	void Start () {

		rba = GetComponent<Rigidbody2D> (); 

		//look at center 
		transform.LookAt (Vector3.zero);
		//Transform vector 3 to render 2D
		transform.Rotate (0,90,90);
		transform.Rotate (0,0,Random.Range(-randomRotate,randomRotate));
		//add force
		rba.AddForce(transform.up * thrust);
		
		rba.AddTorque(Random.Range(-spin,spin),ForceMode2D.Impulse);

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

		points = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		

		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy (this.gameObject);
		}
		
	}

	void OnCollisionEnter2D (Collision2D Collider)
	{
		gameController.AddScore (scorevalue);

		StartCoroutine ( Destroy () );
	}

	IEnumerator Destroy ()
	{
		points.Play ();
		GetComponent <SpriteRenderer> ().enabled = false;
		GetComponent <Collider2D> ().enabled = false;

		yield return new WaitForSeconds (1);

		Destroy(gameObject);
	
	}
}
