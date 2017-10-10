using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	public LevelManager myLevelManager;

	void OnTriggerEnter2D (Collider2D trigger) {
		myLevelManager.LoadLevel ("GameOver");
	}
}
