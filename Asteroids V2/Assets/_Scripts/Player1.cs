using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

	public float thrust;
	Rigidbody2D rb;

	private Renderer[] renderers;
	private bool isWrappingX = false;
	private bool isWrappingY = false;

	public GameObject projectile;
	public Transform shotPos;
	float shotForce = 450;
	public float fireRate;
	private float nextFire = 0.0F;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();

		renderers = GetComponentsInChildren<Renderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetKey ("space"))
		{
			rb.AddForce(transform.up * thrust);
		}
		
		//Rotate to mouse
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//laser fire
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			GameObject shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as GameObject;
			shot.GetComponent<Rigidbody2D> ().AddForce (shotPos.up * shotForce);

			nextFire = Time.time + fireRate;

		}

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
