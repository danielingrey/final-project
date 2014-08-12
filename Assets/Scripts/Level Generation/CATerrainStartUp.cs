using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// CA terrain level start up script.
/// </summary>
public class CATerrainStartUp : MonoBehaviour {
	/// <summary>
	/// The length.
	/// </summary>
	int length = 128;
	/// <summary>
	/// The height.
	/// </summary>
	int height = 60;
	/// <summary>
	/// The start level to seed from.
	/// </summary>
	int strtLev = 20;
	/// <summary>
	/// The roof level to begin building the roof.
	/// </summary>
	int roofLev = 30;
	/// <summary>
	/// The floor level to begin building the floor.
	/// </summary>
	int floorLev = 13;
	/// <summary>
	/// Used to access the LevelLoad.cs script.
	/// </summary>
	LevelLoad ll;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		//Stopwatch stopWatch = new Stopwatch();
		//stopWatch.Start();
		ll = gameObject.GetComponent<LevelLoad>();
		if(!StaticObjects.terrainBuilt){
			CA3D myCA = new CA3D(strtLev, roofLev, floorLev, length, height);		
			myCA.seed("random");
			myCA.fillNextGen("cave", 5, strtLev);
			myCA.border();
			myCA.buildWalls();
			myCA.buildRoof();
			myCA.optimiseCells();
			myCA.buildFloor();
			StaticObjects.terrain = myCA.caveArr;
			StaticObjects.terrainBuilt = true;
		}
		//Debug.Log (StaticObjects.terrainBuilt);
		ll.setup(length,height,StaticObjects.terrain,4,20);
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}
}
