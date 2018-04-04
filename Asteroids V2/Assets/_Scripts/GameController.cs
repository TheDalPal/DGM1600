using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float wavecount;

	// Use this for initialization
	void Start () {

		StartCoroutine (SpawnWaves ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				SpawnTop ();
				yield return new WaitForSeconds (spawnWait);

				SpawnBottom ();
				yield return new WaitForSeconds (spawnWait);

				SpawnLeft ();
				yield return new WaitForSeconds (spawnWait);

				SpawnRight ();
				yield return new WaitForSeconds (spawnWait);
				wavecount++;
			}
		}
	}

	void SpawnTop()
	{
		Vector3 spawnTop = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnTop, spawnRotation);
	}
	void SpawnBottom()
	{
		Vector3 spawnBottom = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnBottom, spawnRotation);
	}
	void SpawnLeft()
	{
		Vector3 spawnLeft = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnLeft, spawnRotation);
	}
	void SpawnRight()
	{
		Vector3 spawnRight = new Vector3 (-spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnRight, spawnRotation);
	}

}
