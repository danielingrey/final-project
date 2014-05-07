using UnityEngine;
using System.Collections;
using System;

public class PlayerStartPos : MonoBehaviour {

	// Use this for initialization
	float startOff = 1.08f; // start height offset

	void Start () {

		bool placed = false;
		if(Application.loadedLevelName == "TerrainCA"){
			int i = StaticObjects.terrain.GetLength(2)-1;
			//Debug.Log(i);
			while(!placed && i > 0) {
				//Debug.Log(i-20);
				if(StaticObjects.terrain[20,20,i] == 1) {
					//Debug.Log(StaticObjects.terrain[20,20,i]);
					//Debug.Log((i-20)*1.5f);
					//Debug.Log((i-20)*1.5f+1.23f);
					placed = true;
					//Debug.Log(placed);
					//Debug.Log(Math.Floor(i/1.75f)+0.5f);
					//transform.position = new Vector3(30f,(float)Math.Floor(i/1.75f)+0.5f, 30f);
					
					transform.position = new Vector3(30f,(i-20)*1.5f+startOff, 30f);
				}
				i--;
			}
			if(i == 0) transform.position = new Vector3(30f,startOff, 30f);

		} else if(Application.loadedLevelName == "TerrainPN") {
			//Debug.Log (StaticObjects.pnTerrain[20,20]*1.5f+1.08f);
			//Debug.Log (StaticObjects.pnTerrain[20,20]*1.5f+1.23f);
			if(StaticObjects.pnTerrain[20,20] == 0) {
				transform.position = new Vector3(30f,startOff, 30f);
			}else {
				transform.position = new Vector3(30f,StaticObjects.pnTerrain[20,20]*1.5f+startOff, 30f);
			}
		} else if(Application.loadedLevelName == "CaveCA") {
			int length = StaticObjects.cave.GetLength(0)-1;
			int height = StaticObjects.cave.GetLength(2)-1;

			int x = 20;
			int z = 20;
			//Debug.Log("outside while");
			while(!placed && z < length-20) {

			//for(int i = 10; i < length/3; i++) {
				//for(int j = 10; j < length/3; j++) {
					int count = 0;
					int dist = 0;
					//int y = 0;
					ArrayList numArr = new ArrayList();
					for(int k = 0; k < height; k++) {
						numArr.Add(StaticObjects.cave[x,z,k]);
						if(StaticObjects.cave[x,z,k] == 1) {								
								count++;
							}
							//y = k;
						}
				//Debug.Log (numArr.Count);
				//Debug.Log (numArr.IndexOf(1));
				//Debug.Log("x: " + x + "z: " + z + "count: " + count);
					if(count == 2) {
						int y1 = numArr.IndexOf(1);
						int y2 = numArr.LastIndexOf(1);
						dist = (int)Math.Abs(y1 - y2);
						//Debug.Log ("y1 " + y1 + " y2 " + y2 + " dist " + dist);
						if (dist > 5) {							
							placed = true;
							transform.position = new Vector3(x*1.5f,y1*1.5f+startOff, z*1.5f);
						}
					}
				if (x < length-20) {
					x++;
				} else {
					x = 20;
					z++;
				}
				//}
			//}
			} 
		} else if(Application.loadedLevelName == "CaveAdHoc") {
			transform.position = new Vector3(4.5f,8.58f,4.5f);
		}
	}

}
