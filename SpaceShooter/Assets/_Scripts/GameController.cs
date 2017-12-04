using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float wavecount;

	public Text scoreText;
	public Text gameoverText;
	int score;

	GameController gameController;


	void Start ()
	{   
		score = 0;
		Score ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (wavecount >= 5) {
			spawnWait = .8f;
		}
		if (wavecount >= 10) {
			spawnWait = .7f;
		}
		if (wavecount >= 15) {
			spawnWait = .6f;
		}
		if (wavecount >= 25) {
			spawnWait = .5f;
		}
		if (wavecount >= 35) {
			spawnWait = .4f;
		}
		if (wavecount >= 50) {
			spawnWait = .3f;
		}
		if (wavecount >= 70) {
			spawnWait = .2f;
		}

	}



	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
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
		

	public void AddScore(int newscorevalue)
	{
		score += newscorevalue;
		Score ();
	}

	void Score()
	{
		scoreText.text = "Score: " + score;
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
