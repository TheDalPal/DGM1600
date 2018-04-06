using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour {

	public GameObject effect;

	AudioSource powerup;

	void Start()
	{
		powerup = GetComponent<AudioSource> ();
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
		Instantiate (effect, transform.position, transform.rotation);

		powerup.Play ();

		Player1 stats = player.GetComponent<Player1> ();

		stats.health++;
		stats.HeartDisplay();

		GetComponent <SpriteRenderer> ().enabled = false;
		GetComponent <Collider2D> ().enabled = false;

		yield return new WaitForSeconds (1);

		Destroy(gameObject);
	}
}
