using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject projectile;
	public Transform shotPos;
	float shotForce = 450;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//wasd movement
		if (Input.GetKey ("w"))
		{	transform.position += Vector3.up * speed * Time.deltaTime;
			
		}
		if (Input.GetKey ("s"))
		{   transform.position += Vector3.down * speed * Time.deltaTime;
			
		}
		if (Input.GetKey ("a"))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey ("d"))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;

		}

		//Rotate to mouse
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//laser fire
		if(Input.GetButtonUp("Fire1"))
		{
			GameObject shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as GameObject;
			shot.GetComponent<Rigidbody2D> ().AddForce (shotPos.up * shotForce);
		}



	}
}
