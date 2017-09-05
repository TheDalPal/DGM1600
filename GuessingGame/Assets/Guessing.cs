using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guessing : MonoBehaviour
{

	int max = 500;
	int min = 1;
	int guess = 250;

	// Use this for initialization
	void Start ()
	{
		
		print ("Welcome to Nuber Guesser!");
		print ("Pick a number in your head. Don't tell me what it is.");

		print ("The highest number you can pick is " +max +".");
		print ("The lowest number you can pick is " +min +".");

		print ("Is the number higher or lower than " +guess +"?");
		print ("Up arrow for higher. Down arrow for Lower. Enter for I got it right.");
		max = max + 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			min = guess;
			guess = (max + min) / 2;
			print ("Is the number higher or lower than " +guess +"?");
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			max = guess;
			guess = (min + guess) / 2;
			print ("Is the number higher or lower than " +guess +"?");

		}
		if (Input.GetKeyDown (KeyCode.KeypadEnter)) 
		{
			print ("I win! Thanks for playing!");
		}
			
	}
}
