using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsibility : MonoBehaviour {

	public GameObject effect;

	public float effecttime;
	public float timer;
	private bool pickedup = false;

	AudioSource powerup;
	AudioSource powerdown;

	void Start()
	{
		AudioSource[] audios = GetComponents<AudioSource> ();
		powerup = audios [0];
		powerdown = audios[1];
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

		stats.invinsibility = true;

		GetComponent <SpriteRenderer> ().enabled = false;
		GetComponent <Collider2D> ().enabled = false;

		yield return new WaitForSeconds (effecttime);

		powerdown.Play ();

		yield return new WaitForSeconds (2);

		stats.invinsibility = false;

		Destroy(gameObject);
	}
}
