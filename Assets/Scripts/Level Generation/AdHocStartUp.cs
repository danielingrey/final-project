using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// Ad hoc system start up script.
/// </summary>
public class AdHocStartUp : MonoBehaviour {
	/// <summary>
	/// The length/depth of a section.
	/// </summary>
	int sectLen = 8; 
	/// <summary>
	/// The length/depth of the cave.
	/// </summary>
	int caveLen  = 64; 
	/// <summary>
	/// The height of the cave.
	/// </summary>
	int height = 16; 
	/// <summary>
	/// The number of sections.
	/// </summary>
	int sectNum = 64; 
	/// <summary>
	/// Used to access the LevelLoad.cs scrip
	/// </summary>
	LevelLoad ll;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		//Stopwatch stopWatch = new Stopwatch();
		//stopWatch.Start();
		ll = gameObject.GetComponent<LevelLoad>();
		if(!StaticObjects.cahBuilt){
			AdHoc myAdHoc = new AdHoc(sectLen, height, sectNum);
			myAdHoc.placeCorners();
			myAdHoc.placeWalls();
			myAdHoc.placeInteriors();
			StaticObjects.ahCave = myAdHoc.levelArr;
			StaticObjects.cahBuilt = true;
		}
		ll.setup(caveLen,height,StaticObjects.ahCave,3,0);
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}
}
