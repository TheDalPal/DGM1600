using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUp : MonoBehaviour {

	public GameObject effect;
	public float multiplier;
	public float effecttime;
	public float timer;
	private bool pickedup = false;

	AudioSource powerup;

	void Start()
	{
		powerup = GetComponent<AudioSource> ();
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0 && pickedup == false) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.CompareTag ("Player"))
		{
			StartCoroutine ( Pickup (other) );
		}
	}

	IEnumerator Pickup (Collider2D player)
	{

		pickedup = true;

		Instantiate (effect, transform.position, transform.rotation);

		powerup.Play ();

		Player1 stats = player.GetComponent<Player1> ();

		stats.fireRate *= multiplier;

		GetComponent <SpriteRenderer> ().enabled = false;
		GetComponent <Collider2D> ().enabled = false;

		yield return new WaitForSeconds (effecttime);

		stats.fireRate /= multiplier;
		//stats.fireRate -= .01f;

		Destroy(gameObject);
	}
}
