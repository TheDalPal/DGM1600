using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour {

	public GameObject effect;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player"))
		{
			Pickup (other);
		}
	}
		
	void Pickup (Collider2D player)
	{
		Instantiate (effect, transform.position, transform.rotation);

		Player1 stats = player.GetComponent<Player1> ();
		stats.health++;
		stats.HeartDisplay ();


		Destroy(gameObject);
	}
}
