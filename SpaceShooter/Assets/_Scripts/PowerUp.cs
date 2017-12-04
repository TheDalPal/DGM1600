using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public enum Type {healthup, doublepoints, invincible, gunspeedup};
	public Type powerType;
	public Sprite[] images;

	public float timer1;
	private float timerSave1;
	bool t1s = false;
	public float timer2;
	private float timerSave2;
	bool t2s = false;
	public float timer3;
	private float timerSave3;
	bool t3s = false;



	// Use this for initialization
	void Start () {
		timerSave1 = timer1;
		timerSave2 = timer2;
		timerSave3 = timer3;
		
		switch (powerType) {
		case Type.healthup:
			gameObject.GetComponent<SpriteRenderer> ().sprite = images[0];
			break;
		case Type.doublepoints:
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
		if (t1s == true) 
		{
			timer1 -= Time.deltaTime;
			if (timer1 <= 0) 
			{
				timer1 = timerSave1;
				t1s = false;
			}
		}
		if (t2s == true) 
		{
			timer2 -= Time.deltaTime;
			if (timer2 <= 0) 
			{
				timer2 = timerSave2;
				t2s = false;
			}
		}
		if (t3s == true) 
		{
			timer3 -= Time.deltaTime;
			if (timer3 <= 0) 
			{
				timer3 = timerSave3;
				t3s = false;
			}
		}
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
		case Type.doublepoints:
			//points x2
			t1s = true;
			break;
		case Type.invincible:
			other.GetComponent<PlayerController> ().invincible = true;
			t2s = true;
			break;
		case Type.gunspeedup:
			other.GetComponent<PlayerController> ().fireRate = .2f;
			t3s = true;
			break;		
		}
	}


}
