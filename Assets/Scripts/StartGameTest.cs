using UnityEngine;
using System.Collections;

public class StartGameTest : MonoBehaviour {
	//string[] levels;


	// Use this for initialization
	void Start () {
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

		//levels = new string[] {"CaveCA", "CaveAdHoc"};
		//int rand = Random.Range(0,2);
		Application.LoadLevel("TerrainPN");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
