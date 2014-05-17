using UnityEngine;
using System.Collections;

public class StartGameTest : MonoBehaviour {
	//string[] levels;
	float countdown = 5.0f;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		StaticObjects.terrainBuilt = false;
		StaticObjects.caveBuilt = false;
		StaticObjects.pnTBuilt = false;
		StaticObjects.cahBuilt = false;
		StaticObjects.terrain = new int[128,128,60];
		StaticObjects.pnTerrain = new int[128,128];
		StaticObjects.cave = new int[64,64,60];
		StaticObjects.ahCave = new int[64,64,16];
		StaticObjects.teleLength = 4.250f;


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
		Resources.LoadAll("Level Files");

	}


	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if(countdown < 0.0f && Input.anyKeyDown) {
			//Application.LoadLevel("TerrainPN");
			Application.LoadLevel(1);
		}

	}
}
