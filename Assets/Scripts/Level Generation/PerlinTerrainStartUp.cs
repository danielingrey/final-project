using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// Perlin terrain start up script. Creates a perlin heightmap object and instantiates cubes in to the level based on array coordinates held within the heightmap.
/// </summary>
public class PerlinTerrainStartUp : MonoBehaviour {
	/// <summary>
	/// The length/width of the level in cubes.
	/// </summary>
	int length = 128;
	//int height = 60;
	/// <summary>
	/// The cube prefab.
	/// </summary>
	public Transform cubePrefab;
	/// <summary>
	/// The player.
	/// </summary>
	public Transform player;
	/// <summary>
	/// The can co routine.
	/// </summary>
	bool canCoRoutine = true;
	/// <summary>
	/// The teleport.
	/// </summary>
	public GUITexture teleport;
	/// <summary>
	/// My mesh.
	/// </summary>
	CreateMesh myMesh;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		//Stopwatch stopWatch = new Stopwatch();
		//stopWatch.Start();
		myMesh = new CreateMesh(length);
		if(!StaticObjects.pnTBuilt){
			PNHeightMap myHM = new PNHeightMap(length);
			myHM.perlHghtMap(0.05f,0.05f);
			StaticObjects.pnTerrain = myHM.arr2D; //copy heightmap array to static variable so it isn't destroyed between scene transitions
			StaticObjects.pnTBuilt = true;
		}
		setup();
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}

	/// <summary>
	/// Setup this instance.
	/// </summary>
	void setup() {
		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {					
				Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, StaticObjects.pnTerrain[x,z]*1.5f, z*1.5f), Quaternion.identity) as Transform;							
				int m = myMesh.getMesh(x,z);						
				cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
			}	
		}
		Instantiate(player);
		audio.Play();
	}

	/// <summary>
	/// Update is run every frame. If "T" is pressed a coroutine is started to wait until the teleport sound has finished playing before transitioning to the next level.
	/// </summary>
	void Update(){
		if (Input.GetKeyDown(KeyCode.T) && canCoRoutine) {
			StartCoroutine(waitForSound());
		}
		if (!canCoRoutine) {
			Instantiate(teleport); //create 2D teleport texture on screen
			teleport.transform.localScale += new Vector3(0.01f, 0.01f, 0); //zoom in each frame on texture to create teleport animation on screen
		}
	}

	/// <summary>
	/// Waits for the length of the teleport sound before transitioning to the next level. Resets the teleport 2D texture to normal size.
	/// </summary>
	IEnumerator waitForSound() {
		canCoRoutine = false;

		yield return new WaitForSeconds(3.0f);

		Application.LoadLevel(2); // loads the next level/scene
		//Application.LoadLevel(4);
		teleport.transform.localScale = new Vector3(2, 2, 1);
	}

}
