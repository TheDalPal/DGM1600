using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;


	void Start ()
	{ 
		
		StartCoroutine (SpawnWaves ());
	}



	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnTop = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnTop, spawnRotation);

				Vector3 spawnBottom = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -spawnValues.y, spawnValues.z);
				Instantiate (hazard, spawnBottom, spawnRotation);

				Vector3 spawnRight = new Vector3 (-spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Instantiate (hazard, spawnRight, spawnRotation);

				Vector3 spawnLeft = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Instantiate (hazard, spawnLeft, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}

		}
	}

}
