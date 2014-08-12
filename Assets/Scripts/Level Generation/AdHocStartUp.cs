using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// Ad hoc system start up script. Creates an instance of an ad hoc cave building object and instantiates cubes based on its array coordinates. 
/// </summary>
public class AdHocStartUp : MonoBehaviour {
	/// <summary>
	/// The length of the sect.
	/// </summary>
	int sectLen; //section length
	/// <summary>
	/// The length of the cave.
	/// </summary>
	int caveLen  = 64; //cave length
	/// <summary>
	/// The height.
	/// </summary>
	int height = 16; //cave height
	/// <summary>
	/// The sect number.
	/// </summary>
	int sectNum = 64; //number of sections
	/// <summary>
	/// My ad hoc.
	/// </summary>
	AdHoc myAdHoc;
	/// <summary>
	/// My mesh.
	/// </summary>
	//CreateMesh myMesh; 
	/// <summary>
	/// The can co routine.
	/// </summary>
	//bool canCoRoutine = true;
	/// <summary>
	/// The cube prefab.
	/// </summary>
	//public Transform cubePrefab;
	/// <summary>
	/// The player.
	/// </summary>
	//public Transform player;
	/// <summary>
	/// The teleport.
	/// </summary>
	//public GUITexture teleport;
	LevelLoad ll;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		//Stopwatch stopWatch = new Stopwatch();
		//stopWatch.Start();
		//myMesh = new CreateMesh(sectNum);
		ll = gameObject.GetComponent<LevelLoad>();
		if(!StaticObjects.cahBuilt){
			sectLen = 8;
			myAdHoc = new AdHoc(sectLen, height, sectNum);
			myAdHoc.placeCorners();
			myAdHoc.placeWalls();
			myAdHoc.placeInteriors();
			StaticObjects.ahCave = myAdHoc.levelArr;
			StaticObjects.cahBuilt = true;
			//textures
		}
		ll.setup(caveLen,height,StaticObjects.ahCave,3,0);
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}

	/// <summary>
	/// Setup this instance.
	/// </summary>
	/*void setup() {
		for(int x = 0; x < caveLen; x++) {				
			for( int z = 0; z < caveLen; z++) {
				for(int y = 0; y < height; y++) {
					if(StaticObjects.ahCave[x,z,y]==1) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, y*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z,y);
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			}
			
		}
		Instantiate(player);
		audio.Play();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update(){
		if (Input.GetKeyDown(KeyCode.T) && canCoRoutine) {
			StartCoroutine(waitForSound());
		}
		if (!canCoRoutine) {
			Instantiate(teleport);
			teleport.transform.localScale += new Vector3(0.01f, 0.01f, 0);
		}
	}

	/// <summary>
	/// Waits for sound.
	/// </summary>
	/// <returns>The for sound.</returns>
	IEnumerator waitForSound() {
		canCoRoutine = false;
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel(3);
		//Application.LoadLevel(5);
		teleport.transform.localScale = new Vector3(2, 2, 1);
	}*/
}
