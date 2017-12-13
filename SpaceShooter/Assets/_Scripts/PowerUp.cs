using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public enum Type {healthup, gunspeedup};
	public Type powerType;
	public Sprite[] images;


	// Use this for initialization
	void Start () 
	{				
		switch (powerType) 
		{
		case Type.healthup:
			gameObject.GetComponent<SpriteRenderer> ().sprite = images[0];
			break;
		case Type.gunspeedup:
			gameObject.GetComponent<SpriteRenderer> ().sprite = images [1];
			break;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{ 
		Destroy (this.gameObject);

		switch (powerType) 
		{
		case Type.healthup:
			other.GetComponent<PlayerController> ().health++;
			other.GetComponent<PlayerController> ().HeartDisplay();
			break;
		case Type.gunspeedup:
			other.GetComponent<PlayerController> ().fireRate -=.02f;
			break;		
		}
	}
}
