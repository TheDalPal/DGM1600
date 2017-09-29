using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateScript : MonoBehaviour 
{

	public Text textbox;

	public enum State
	{
		start, forest, river, mountain, beach, treetops, deepwoods, house, calmwaters, waterfall, planes, cave, right, left, center, forward, theend, island, city, gameover, victory
	};
	public State myState;

	public bool oars = false;
	public bool rope = false;
	public bool wood = false;
	public bool matches = false;
	public bool lantern = false;
	public bool flare = false;
	public bool shovel = false;
	public bool ax = false;
	public bool coal = false;
	public bool ammo = false;
	public bool shotgun = false;


	void Start () 

	{myState = State.start;}

	void Update ()
	{
		

		if (myState == State.start) {
			State_Start ();
		} else if (myState == State.forest) {
			State_Forest ();
		} else if (myState == State.deepwoods) {
			State_DeepWoods ();
		} else if (myState == State.house) {
			State_House ();
		} else if (myState == State.treetops) {
			State_Treetops ();
		} else if (myState == State.river) {
			State_River ();
		} else if (myState == State.calmwaters) {
			State_CalmWaters ();
		} else if (myState == State.waterfall) {
			State_Waterfall ();
		} else if (myState == State.mountain) {
			State_Mountain ();
		} else if (myState == State.cave) {
			State_Cave ();
		} else if (myState == State.left) {
			State_Left ();
		} else if (myState == State.right) {
			State_Right ();
		} else if (myState == State.center) {
			State_Center (); 
		} else if (myState == State.forward) {
			State_Forward (); 
		} else if (myState == State.theend) {
			State_TheEnd (); 
		}  else if (myState == State.planes) {
			State_Planes ();
		} else if (myState == State.beach) {
			State_Beach ();
		} else if (myState == State.island) {
			State_Island ();
		} else if (myState == State.city) {
			State_City ();
		} else if (myState == State.gameover) {
			State_GameOver ();
		} else if (myState == State.victory) {
			State_Victory ();
		}


	}

	void State_Start()
	{textbox.text = "You wake up stranded on an Island." +
			"\n You don't remember how you got there you just know that you are hungry and you need to get off the island." +
			"\n You are in a field with nothing around you. You see a Mountain, a Forest, a River, and a Beach." +
			"\n Press M to go to the Mountain, F to go to Forest, R to go to the Rivier, and B to go to Beach.";
		
		if (Input.GetKeyDown (KeyCode.F)) 
		{myState = State.forest;} 
		else if (Input.GetKeyDown (KeyCode.M)) 
		{myState = State.mountain;}
		else if (Input.GetKeyDown (KeyCode.B)) 
		{myState = State.beach;}
		else if (Input.GetKeyDown (KeyCode.R)) 
		{myState = State.river;}
	}

	//FOREST PATH
	void State_Forest()
	{
		if (ax == true) {wood = true;
			textbox.text = "You are in the Forest. You can see something in the Treetops. You can also continue to walk into the Deep Woods." +
			"\n\n You used the Ax to cut down some trees to make some Wooden Planks." +
			"\n\n Press T to go to the Treetops or press D to go into the Deep Woods." +
			"\n You can also turn around and head back to the River, Mountain, or Beach."; 
		} else {
			textbox.text = "You are in the Forest. You can see something in the Treetops. You can also continue to walk into the Deep Woods." +
			"\n Press T to go to the Treetops or press D to go into the Deep Woods." +
			"\n You can also turn around and head back to the River, Mountain, or Beach.";
		}
		 
		if (Input.GetKeyDown (KeyCode.M)) 
		{myState = State.mountain;}
		else if (Input.GetKeyDown (KeyCode.B)) 
		{myState = State.beach;}
		else if (Input.GetKeyDown (KeyCode.R)) 
		{myState = State.river;}
		if (Input.GetKeyDown (KeyCode.T)) 
		{myState = State.treetops;} 
		else if (Input.GetKeyDown (KeyCode.D))
		{myState = State.deepwoods;}
	}

	void State_DeepWoods()
	{if (lantern && matches == true) {
			textbox.text = "You use your Matches to light your Lantern. You take a look around and notice an old House." +
			"\n Press H to go inside the House or F to return to the forest.";
				if (Input.GetKeyDown (KeyCode.H))
				{myState = State.house;}
		} else{
			textbox.text = "You find yourself in a part of the forest where it is to dark to see come back when you have a source of light." +
			"\n Press F to return to the Forest.";
		}
	

		if (Input.GetKeyDown (KeyCode.F)) 
		{myState = State.forest;} 
		
	}

	void State_House()
	{ if (coal == true) {
			textbox.text = "You put the coal into the generator and now the House has power." +
			"\n You use the phone to call a friend who owes you a favor." +
			"\n He flies over in his hot air ballon and gets you off the Island." +
			"\n Press Return to Escape the Island.";

			if (Input.GetKeyDown (KeyCode.Return)) {
				myState = State.victory;
			}
		}
		if (shotgun == true) {
			textbox.text = "You have found yourself in an abandond house. There is a telephone but there is no power in the house." +
			"\n There is a generator on the side of the house but it needs coal to be powered." +
			"\n Press D to return to the Deep Forest.";

			if (Input.GetKeyDown (KeyCode.D)) {
				myState = State.deepwoods;
			}
		}
		else {
			textbox.text = "You have found yourself in an abandond house. There is a telephone but there is no power in the house." +
				"\n You find an old but still working Shotgun on the mantel." +
				"\n Press A to add the Shotgun to your inventory" +
			"\n There is a generator on the side of the house but it needs coal to be powered." +
			"\n Press D to return to the Deep Forest.";
		
			if (Input.GetKeyDown (KeyCode.D)) {
				myState = State.deepwoods;
			}
			else if (Input.GetKeyDown (KeyCode.A)) 
			{shotgun = true;} 

		}
	}

	void State_Treetops ()
	{
		if (matches == true) {
			textbox.text = "You are in a TreeHouse." +
			"\n Press F to return to the Forest.";
		} else {
			textbox.text = "You have found yourself in a TreeHouse. On the floor is a box of Matches. " +
			"\n Press A to Add them to your inventory." +
			"\nPress F to return to the Forest.";
		}

		if (Input.GetKeyDown (KeyCode.F)) 
		{myState = State.forest;} 
		else if (Input.GetKeyDown (KeyCode.A)) 
		{matches = true;} 
	}

	//RIVER PATH
	void State_River()
	{
		textbox.text = "You are on bank of a River. You can take a closer look in the Calm Waters or head to the Waterfall." +
		"\n Press C to go to the Calm Waters or W to go to the Waterfall." +
		"\n You can also turn around and head back to the Forest, Mountain, or Beach.";
		if (Input.GetKeyDown (KeyCode.F)) 
		{myState = State.forest;} 
		else if (Input.GetKeyDown (KeyCode.M)) 
		{myState = State.mountain;}
		else if (Input.GetKeyDown (KeyCode.B)) 
		{myState = State.beach;}
		else if (Input.GetKeyDown (KeyCode.C)) 
		{myState = State.calmwaters;}
		else if (Input.GetKeyDown (KeyCode.W))
		{myState = State.waterfall;}
	}

	void State_CalmWaters ()
	{
		if (shovel == true) {
			textbox.text = "The water is cold and you want to get out." +
			"\n Press R to return to the Riverbank.";
			
		} 
		else 
		{
			textbox.text = "You notice a glit of light come off of someting at the bottom of the River. You see a Shovel half burried by sand and rocks." +
			"\n Press A to Add the Shovel to your Inventory." +
			"\n Press R to return to the Riverbank.";
			if (Input.GetKeyDown (KeyCode.A)) {shovel = true;}
		}
		if (Input.GetKeyDown (KeyCode.R)) 
		{myState = State.river;}
	}

	void State_Waterfall()
	{
		
		if (oars == true)
		{textbox.text = "You walk behind the Waterfall and find an empty ledge." +
				"\n Press R to return to the River.";} 
		else 
		{
			textbox.text = "You walk behind the Waterfall and find a pair of Oars in a small carved out ledge." +
				"\n Press A to Add the Oars to your Inventory." +
				"\n Press R to return to the River.";
		}
		if (Input.GetKeyDown (KeyCode.R)) 
		{myState = State.river;}

		if (Input.GetKeyDown (KeyCode.A)) 
		{oars = true;}
	}

	//MOUNTAIN PATH
	void State_Mountain()
	{textbox.text = "You are on the top of the Mountain You can see the whole island from here. There are Planes flying overhead that can't see you. There is a nearby cave." +
		"\n Press C to explore the Cave or press P to try and flag down the Planes." +
		"\n You can also turn around and head back to the Forest, River, or Beach.";
		if (Input.GetKeyDown (KeyCode.F)) 
		{myState = State.forest;} 
		else if (Input.GetKeyDown (KeyCode.B)) 
		{myState = State.beach;}
		else if (Input.GetKeyDown (KeyCode.R)) 
		{myState = State.river;}
		else if (Input.GetKeyDown (KeyCode.C)) 
		{myState = State.cave;}
		else if (Input.GetKeyDown (KeyCode.P)) 
		{myState = State.planes;}
	}

	void State_Cave()
	{if (lantern && matches == true)
		{
			textbox.text = "You used the matches to light the lantern and now you can venture into the cave." +
				"\n You find that the cave is an old Coal mine." +
				"\n The coal was added into your inventory." +
				"\n Would you like to go Left, Right, or Center?" +
				"\n L for Left, R for Right, or C for Center, You can also return to the Mountain";
		
			if(Input.GetKeyDown (KeyCode.R)) 
			{myState = State.right;}
			else if(Input.GetKeyDown (KeyCode.L)) 
			{myState = State.left;}
			else if(Input.GetKeyDown (KeyCode.C)) 
			{myState = State.center;}
			else if (Input.GetKeyDown (KeyCode.M)) 
			{myState = State.mountain;}
			coal = true;
		}

	else {
		textbox.text = "You walk into a cave that branches off in three directions, however the cave is too dark to venture forward." +
		"\n Come back when you have a light source." +
			"\n Press M to return to the Mountain.";}
	
		if (Input.GetKeyDown (KeyCode.M)) 
		{myState = State.mountain;}
	}
	
	void State_Left()
	{if (flare == true) {
			textbox.text = "You are in a small empty cavern." +
			"\n Press C to return to the Cave.";
		if (Input.GetKeyDown (KeyCode.C)) 
				{myState = State.cave;}

		} else {
			textbox.text = "You walk into a small cavern and find a Flare lying on the floor." +
			"\n Press A to Add the Flare to your inventory." +
			"\n Press M to return to the Mountain";

			if (Input.GetKeyDown (KeyCode.A)) {
				flare = true;
		} else if (Input.GetKeyDown (KeyCode.C)) 
		{myState = State.cave;}
			} 
		}
	

	void State_Right()
	{
		if (rope == true) {
			textbox.text = "You are in a small empty cavern." +
				"\n Press C to return to the Cave.";
			if (Input.GetKeyDown (KeyCode.C)) 
			{myState = State.cave;}
		}else {
				textbox.text = "You walk into a small cavern and lying on the floor is a coil of Rope." +
				"\n Press A to Add the rope to your Inventory." +
				"\n Press M to Escape the Cave and return to the Mountain.";
				if (Input.GetKeyDown (KeyCode.C)) 
				{myState = State.cave;}
				if (Input.GetKeyDown (KeyCode.A)) {
					rope = true;}
			}
		}


	void State_Center()
	{if (shotgun && ammo == true) {
			textbox.text = "There is a bear sleeping in the cave. It wakes up when you walk in." +
			"\n The bear charges at you but you use your Shotgun to kill the bear." +
			"\n After walking around the bears body you find he was blocking a path that leads deeper into the moutain." +
			"\n Press F to venture forward.";
			if (Input.GetKeyDown (KeyCode.F)) {
				myState = State.forward;
			}
		}

			else {
				textbox.text = "You have been attacked by a local bear who really enjoys his privacy" +
				"\n Press Return to Continue.";
				if (Input.GetKeyDown (KeyCode.Return)) {
					myState = State.gameover;
				}
			}
		}		
	void State_Forward()
	{
		textbox.text = "You continue to walk down the tunnel until you reach the heart of the Mountain." +
		"\n When the tunnel ends you find a huge cavern with a lake of lava." +
		"\n Upon further investigation you find that this cavern has been set up as an evil lair. However it hasn't been used in years." +
		"\n The evil scientists were trying to harness the power of the volcano to create a death ray." +
		"\n There is a big red button that says Do Not Push" +
		"\n Press P to Give into the urge to Push the button.";

		if (Input.GetKeyDown (KeyCode.P)) {
			myState = State.theend;
		}
	}

	void State_TheEnd()
	{
		textbox.text = "The Death Ray shoots a beam at the moon that blows it up." +
		"\n The beam was noticed by everyone around the world and people swarm to see what happened." +
		"\n You're able to escape now that people know you are stranded, but the moon is gone. Oh Well." +
		"\n Press Return to escape the island.";
		if (Input.GetKeyDown (KeyCode.Return)) {
			myState = State.victory;
		}
	}

	void State_Planes ()
	{
		if (flare && matches == true) {
			textbox.text = "You used your matches to light your flare. The pilot over head noticed you and is flying down to rescue you" +
			"\n Press Return to Escape the Island.";
			
			if (Input.GetKeyDown (KeyCode.Return)) {
				myState = State.victory;
			}
		} else {
			textbox.text = " You start waving your hands in the air hoping any one of the pilots with notice you on the mountain. No matter how hard you try they don't notice you." +
			"\n Come back when you have something more noticable." +
			"\n Press M to return to the Mountain";
		}

		if (Input.GetKeyDown (KeyCode.M)) 
		{myState = State.mountain;}
	}

	//BEACH PATH
	void State_Beach()
	{
		if (rope && wood && oars == true) {
			textbox.text = "You used your Rope, Wood, and Oars to construct a crude raft. You can paddle to the city." +
			"\n Press Return to Escape the Island.";
			if (Input.GetKeyDown (KeyCode.Return)) 
			{myState = State.victory;}
		} else {
			textbox.text = "You reach the Beach, from here you can see civilization across the ocean on the horizon. You also see a smaller Island close by." +
			"\n Press I to swim to the Island or press C to swim to the City." +
			"\n You can also turn around and head back to the Forest, River, or Mountain";
		}
		if (Input.GetKeyDown (KeyCode.F)) 
		{myState = State.forest;} 
		else if (Input.GetKeyDown (KeyCode.M)) 
		{myState = State.mountain;}
		else if (Input.GetKeyDown (KeyCode.R)) 
		{myState = State.river;}
		else if (Input.GetKeyDown (KeyCode.I)) 
		{myState = State.island;}
		else if (Input.GetKeyDown (KeyCode.C)) 
		{myState = State.city;}
			

	}
	
	void State_Island()
	{
		if (shovel == true) {
			textbox.text = "On the island you notice a big X under a palm tree. Using your shovel you dig at the X. You find a treasure chest. " +
				"\n Inside the chest is a Lantern an Ax, and some Shotgun ammo." +
				"Press A to Add them to your Inventory.";
		} 
		if(ax == true)
		{
			textbox.text = "There is an empty treasure chest and a hole." +
			"\n Press B to return to the Beach.";
		}
		else if (shovel == false)
		{
			textbox.text = "You reach the Island and notice a big red X underneath a palm tree." +
			"\n If only you had something to dig with." +
			"\n Press B to return to the Beach.";
		}

		if (Input.GetKeyDown (KeyCode.B)) 
		{myState = State.beach;}
		if (Input.GetKeyDown (KeyCode.A)) 
		{lantern = true;
			ax = true;
			ammo = true;}

	}

	void State_City()
	{  
		if (rope && wood && oars == true) {
			myState = State.victory;
		} else {
			textbox.text = "You try your hardest to reach the city on the Horizon." +
			"\n Despite your best efforts you run out of energy and drown." +
			"\n Press Return to Continue";
		}
		if (Input.GetKeyDown (KeyCode.Return)) 
		{myState = State.gameover;}
	}

	void State_GameOver()
	{
		textbox.text = "Game over." +
		"\n Would you like to try again?" +
		"\n Press Y for Yes Press N for No.";

			if (Input.GetKeyDown (KeyCode.Y)) 
			{myState = State.start;
			oars = false;
			rope = false;
			wood = false;
			matches = false;
			lantern = false;
			flare = false;
			shovel = false;
			ax = false;
			coal = false;
		}
			
		else if (Input.GetKeyDown (KeyCode.N))
		{Application.Quit();}
	}
	void State_Victory()
	{
		textbox.text = "Congratulations! You escaped the island! You win!" +
		"\n Would you like to play again and try to excape a different way?" +
		"\n Press Y for Yes and N for No.";
		if (Input.GetKeyDown (KeyCode.Y)) 
		{myState = State.start;
			oars = false;
			rope = false;
			wood = false;
			matches = false;
			lantern = false;
			flare = false;
			shovel = false;
			ax = false;
			coal = false;
		}

		//Figure out how to close game
		else if (Input.GetKeyDown (KeyCode.N))
		{Application.Quit();}
	}

}
