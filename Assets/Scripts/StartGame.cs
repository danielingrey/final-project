using UnityEngine;
using System.Collections;

/// <summary>
/// Start game. This script is run when the title screen loads.
/// </summary>
public class StartGame : MonoBehaviour {
	/// <summary>
	/// The countdown is used so the player can't accidentally press a key to load the first level before the title has appeared.
	/// </summary>
	float countdown = 5.0f;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		Screen.showCursor = false; //hide mouse cursor

		//initialise StaticObjects variables
		StaticObjects.terrainBuilt = false;
		StaticObjects.caveBuilt = false;
		StaticObjects.pnTBuilt = false;
		StaticObjects.cahBuilt = false;
		StaticObjects.terrain = new int[128,128,60];
		StaticObjects.pnTerrain = new int[128,128];
		StaticObjects.cave = new int[64,64,60];
		StaticObjects.ahCave = new int[64,64,16];

		for(int x = 0; x < 128; x++) {
			for(int z = 0; z < 128; z++) {
				for(int y = 0; y < 60; y++) {
					StaticObjects.terrain[x,z,y] = 0;
				}
			}
		}
		for(int x = 0; x < 64; x++) {
			for(int z = 0; z < 64; z++) {
				for(int y = 0; y < 60; y++) {
					StaticObjects.cave[x,z,y] = 0;
				}
			}
		}
		for(int x = 0; x < 128; x++) {
			for(int z = 0; z < 128; z++) {
				StaticObjects.pnTerrain[x,z] = 0;
			}
		}
		for(int x = 0; x < 64; x++) {
			for(int z = 0; z < 64; z++) {
				for(int y = 0; y < 16; y++) {
					StaticObjects.ahCave[x,z,y] = 0;
				}
			}
		}

		Resources.LoadAll("Level Files"); //load resources folder
	}

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		countdown -= Time.deltaTime; //Time.deltaTime is the time in seconds it took to complete the last frame
		if(countdown < 0.0f && Input.anyKeyDown) { //if countdown has reached zero allow the player to press a key to begin the game
			Application.LoadLevel(1);
		}

	}
}
