using UnityEngine;
using System.Collections;
using System;

public class PlayerStartPos : MonoBehaviour {

	// Use this for initialization

	void Start () {

		bool placed = false;
		if(Application.loadedLevelName == "TerrainCA"){
			int i = StaticObjects.terrain.GetLength(2)-1;
			Debug.Log(i);
			while(!placed && i > 1) {
				Debug.Log(i-20);
				if(StaticObjects.terrain[20,20,i] == 1) {
					Debug.Log(StaticObjects.terrain[20,20,i]);
					//Debug.Log((i-20)*1.5f);
					Debug.Log((i-20)*1.5f+1.23f);
					placed = true;
					Debug.Log(placed);
					//Debug.Log(Math.Floor(i/1.75f)+0.5f);
					//transform.position = new Vector3(30f,(float)Math.Floor(i/1.75f)+0.5f, 30f);
					
					transform.position = new Vector3(30f,(i-20)*1.5f+1.23f, 30f);
				}
				i--;
			}
			if(i == 0) transform.position = new Vector3(30f,1.23f, 30f);
			print(Application.loadedLevelName);
		} else if(Application.loadedLevelName == "TerrainPN") {
			transform.position = new Vector3(30f,StaticObjects.pnTerrain[20,20]*1.5f+1.23f, 30f);
		}
	}

}
