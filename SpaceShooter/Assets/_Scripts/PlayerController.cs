using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
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

	}
}
