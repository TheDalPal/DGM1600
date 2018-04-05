using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUp : MonoBehaviour {

	public GameObject effect;
	public float multiplier;
	public float effecttime;

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

		Player1 stats = player.GetComponent<Player1> ();

		stats.fireRate *= multiplier;

		GetComponent <SpriteRenderer> ().enabled = false;
		GetComponent <Collider2D> ().enabled = false;

		yield return new WaitForSeconds (effecttime);

		stats.fireRate /= multiplier;

		Destroy(gameObject);
	}
}
