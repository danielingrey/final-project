using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Handles player starting positions within levels.
/// </summary>
public class PlayerStartPos : MonoBehaviour {

	/// <summary>
	/// The start height offset. Change this if player size is changed.
	/// </summary>
	float startOff = 1.08f; 

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		bool placed = false; //player has not been placed yet

		if(Application.loadedLevelName == "TerrainCA"){
			int i = StaticObjects.terrain.GetLength(2)-1;
			while(!placed /*&& i > 0*/) { //start at the "top" of the array and work down until a 1 is found
				if(StaticObjects.terrain[20,20,i] == 1) {
					placed = true;					
					transform.position = new Vector3(30f,(i-20)*1.5f+startOff, 30f);
				}
				i--;
			}
			//if(i == 0) transform.position = new Vector3(30f,startOff, 30f);

		} else if(Application.loadedLevelName == "TerrainPN") {
			if(StaticObjects.pnTerrain[20,20] == 0) {
				transform.position = new Vector3(30f,startOff, 30f);
			}else {
				transform.position = new Vector3(30f,StaticObjects.pnTerrain[20,20]*1.5f+startOff, 30f);
			}
		} else if(Application.loadedLevelName == "CaveCA") {
			int length = StaticObjects.cave.GetLength(0)-1;
			int height = StaticObjects.cave.GetLength(2)-1;
			//(x,z) coordinate offsets to make sure player is not placed too close to an edge
			int x = 20;
			int z = 20;

			while(!placed && z < length-20) {
					int count = 0;
					int dist = 0;					
					ArrayList numArr = new ArrayList();
					for(int k = 0; k < height; k++) {
						numArr.Add(StaticObjects.cave[x,z,k]);
						if(StaticObjects.cave[x,z,k] == 1) { //count number of 1's in ArrayList from 0 to height-1 along k, the "y axis", at each (x,z) coordinate								
								count++;
							}							
						}
					if(count == 2) {
						int y1 = numArr.IndexOf(1);
						int y2 = numArr.LastIndexOf(1);
						dist = (int)Math.Abs(y1 - y2); //check distance between 1's if count is 2						
						if (dist > 5) { //distance of greater than 5 indicates a large room has been created							
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
			} 
		} else if(Application.loadedLevelName == "CaveAdHoc") {
			transform.position = new Vector3(4.5f,8.58f,4.5f); //place player directly as no procedural generation/randomisation implemented on corner sections
		}
	}

}
