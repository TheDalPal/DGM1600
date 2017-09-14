using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guessing : MonoBehaviour
{
	public Text textbox;

	int max = 500;
	int min = 1; 
	int guess;
	public int counter = 7;

	// Use this for initialization
	void Start ()
	{
		guess = Random.Range (min, max);

		textbox.text = "Welcome to Nuber Guesser! " +
			"\nPick a number in your head. Don't tell me what it is." +
			"\nThe highest number you can pick is 500, the lowest number you can pick is 1" +
			"\nIf I guess it in " +counter+ " guesses I win, if it takes me more you win." +
			"\n\nIs the number higher or lower than " +guess+ "?" +
			"\n\n Up Arrow for higher. Down Arrow for lower. Enter for I got it right.";
		
		max = max + 1;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			min = guess;
			guess = (max + min) / 2;
			textbox.text = "Is the number higher or lower than " +guess +"?" +
				"\n\n Up Arrow for higher. Down Arrow for lower. Enter for I got it right.";
			counter--;
		}

		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			max = guess;
			guess = (min + guess) / 2;
			textbox.text = "Is the number higher or lower than " +guess +"?" +
				"\n\n Up Arrow for higher. Down Arrow for lower. Enter for I got it right.";
			counter--;
		}

		else if (Input.GetKeyDown (KeyCode.KeypadEnter)) 
		{
			if (counter >= 0) 
			{
				textbox.text = "I win! Thanks for playing!";
			}
			if (counter < 0) 
			{
				textbox.text = "You win! Good Job!";
			}
		}

	}
}
