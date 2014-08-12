using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// Perlin terrain start up script.
/// </summary>
public class PerlinTerrainStartUp : MonoBehaviour {
	/// <summary>
	/// The length/width of the level in cubes.
	/// </summary>
	int length = 128;
	/// <summary>
	/// Used to access the LevelLoad.cs script.
	/// </summary>
	LevelLoad ll;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		//Stopwatch stopWatch = new Stopwatch();
		//stopWatch.Start();
		ll = gameObject.GetComponent<LevelLoad>();

		if(!StaticObjects.pnTBuilt){
			PNHeightMap myHM = new PNHeightMap(length);
			myHM.perlHghtMap(0.05f,0.05f);
			StaticObjects.pnTerrain = myHM.arr2D; //copy heightmap array to static variable so it isn't destroyed between scene transitions
			StaticObjects.pnTBuilt = true;
		}
		ll.setup(length,2);
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}

}
