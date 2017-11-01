using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int health;
	public Sprite[] image;
	int count = 0;
	LevelManager levelmanager;

	void Start(){
		levelmanager = FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D (Collision2D Collider){

		health--;
		count++;

		if (health <= 0) {
			
			LevelManager.brickcount--;
			levelmanager.CheckBrickCount ();
			Destroy(this.gameObject);
		}

		GetComponent<SpriteRenderer> ().sprite = image[count];

	}

}
