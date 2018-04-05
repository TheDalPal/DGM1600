using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour {

	public GameObject healthup;
	public GameObject gunup;

	public Vector3 powerupPos;
	public float spawntimer;
	public float spawntimersave;

	int randomvalue;


	// Use this for initialization
	void Start () {
		
		spawntimersave = spawntimer;

	}
	
	// Update is called once per frame
	void Update () {

		spawntimer -= Time.deltaTime;

		// timer reaches 0 spawn the power up
		if (spawntimer <= 0) {
			SpawnPowerUp ();
			spawntimer = spawntimersave;
		}
	}

	//Find random pos to spawn power up
	void SpawnPowerUp()
	{
		randomvalue = Random.Range (1, 5);

		if (randomvalue <= 2) {
			Vector3 spawnPowerUp = new Vector3 (Random.Range (-powerupPos.x, powerupPos.x), Random.Range (-powerupPos.y, powerupPos.y), powerupPos.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (healthup, spawnPowerUp, spawnRotation);
		}

		if (randomvalue >= 3) {
			Vector3 spawnPowerUp = new Vector3 (Random.Range (-powerupPos.x, powerupPos.x), Random.Range (-powerupPos.y, powerupPos.y), powerupPos.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (gunup, spawnPowerUp, spawnRotation);
		}
	}
}
