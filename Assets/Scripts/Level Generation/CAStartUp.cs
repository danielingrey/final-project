using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// Start up script for interior CA levels.
/// </summary>
public class CAStartUp : MonoBehaviour {
	/// <summary>
	/// The length.
	/// </summary>
	int length = 128;
	/// <summary>
	/// The height.
	/// </summary>
	int height = 100;
	/// <summary>
	/// The start level to seed from.
	/// </summary>
	int strtLev = 20;
	/// <summary>
	/// The roof level to begin building the roof.
	/// </summary>
	int roofLev = 26;
	/// <summary>
	/// The floor level to begin building the floor.
	/// </summary>
	int floorLev = 16;
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
		if(!StaticObjects.caveBuilt){
			CA3D myCA = new CA3D(strtLev, roofLev, floorLev, length, height);
			myCA.seed("random");
			myCA.fillNextGen("cave", 6, strtLev);
			myCA.border();
			myCA.buildWalls();
			myCA.buildRoof();
			myCA.optimiseCells();
			StaticObjects.cave = myCA.caveArr;
			StaticObjects.caveBuilt = true;
		}
		ll.setup(length,height,StaticObjects.cave,5,0);
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}
}
