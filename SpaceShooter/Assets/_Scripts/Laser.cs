using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public float lifetime;
	float speed= 5;

	private Renderer[] renderers;
	private bool isWrappingX = false;
	private bool isWrappingY = false;


	void OnCollisionEnter2D (Collision2D Collider){

		Destroy(this.gameObject);
	}

	void Start ()
	{
		renderers = GetComponentsInChildren<Renderer> ();

	}

	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy (this.gameObject);
		}

	}

	void FixedUpdate ()
	{
		ScreenWrap ();
	}

	void ScreenWrap()
	{
		bool isVisable = CheckRenderers();


		isWrappingX = false;
		isWrappingY = false;


		if (isWrappingX && isWrappingY) 
		{
			return;
		}

		Vector3 newPosition = transform.position;

		//Wrap Right to Left
		if(newPosition.x > 7.3)
		{
			newPosition.x = -newPosition.x+1f;
			isWrappingX = true;

		}
		//Warp Left to Right
		if (newPosition.x < -7.3)
		{
			newPosition.x = 6.3f;
		}

		//Wrap Top to Bottom
		if(newPosition.y > 5.6)
		{
			newPosition.y = -newPosition.y+1f;
			isWrappingY = true;
		}
		//Warp Bottom to Top
		if (newPosition.y < -5.6) 
		{
			newPosition.y = 4.6f;
			isWrappingY = true;
		}

		transform.position = newPosition;
	}

	bool CheckRenderers()
	{
		foreach (Renderer r in renderers) 
		{
			if (r.isVisible) 
			{
				return true;
			}

		}
		return false;
	}
}
