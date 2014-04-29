using UnityEngine;
using System.Collections;

public class StartGameTest : MonoBehaviour {
	//string[] levels;


	// Use this for initialization
	void Start () {
		StaticObjects.terrainBuilt = false;
		StaticObjects.caveBuilt = false;
		StaticObjects.terrain = new int[128,128,60];
		StaticObjects.cave = new int[64,64,60];
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
		//levels = new string[] {"CaveCA", "CaveAdHoc"};
		//int rand = Random.Range(0,2);
		Application.LoadLevel("TerrainCA");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
