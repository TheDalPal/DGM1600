using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public enum Type {healthup, splitlaser, invincible, gunspeedup};
	public Type powerType;
	public Sprite[] images;

	// Use this for initialization
	void Start () {
		switch (powerType) {
		case Type.healthup:
			gameObject.GetComponent<SpriteRenderer> ().sprite = images[0];
			break;
		case Type.splitlaser:
			gameObject.GetComponent<SpriteRenderer> ().sprite = images [1];
			break;
		case Type.invincible:
			gameObject.GetComponent<SpriteRenderer> ().sprite = images [2];
			break;
		case Type.gunspeedup:
			gameObject.GetComponent<SpriteRenderer> ().sprite = images [3];
			break;
		}
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{ 
		Destroy (this.gameObject);

		switch (powerType) 
		{
		case Type.healthup:
			//other.GetComponent<PlayerController> ().health + 1;
			Debug.Log ("HealthUp");
			break;
		case Type.splitlaser:
			//Tribolt shots
			break;
		case Type.invincible:
			//Disable health--
			break;
		case Type.gunspeedup:
			//reload time is shorter
			break;		
		}
	}
}
