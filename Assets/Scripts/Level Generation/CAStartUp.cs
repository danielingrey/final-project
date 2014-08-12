using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

/// <summary>
/// CA start up.
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
	/// The strt lev.
	/// </summary>
	int strtLev;
	/// <summary>
	/// The roof lev.
	/// </summary>
	int roofLev;
	/// <summary>
	/// The floor lev.
	/// </summary>
	int floorLev;
	/// <summary>
	/// My mesh.
	/// </summary>
	CreateMesh myMesh;
	/// <summary>
	/// The can co routine.
	/// </summary>
	bool canCoRoutine = true;
	/// <summary>
	/// The cube prefab.
	/// </summary>
	public Transform cubePrefab;
	/// <summary>
	/// The player.
	/// </summary>
	public Transform player;
	/// <summary>
	/// The teleport.
	/// </summary>
	public GUITexture teleport;
	//string[] textrs;
	//public static int[,,] cave;
	//public static bool built = false;

	void Start() {
		//Stopwatch stopWatch = new Stopwatch();
		//stopWatch.Start();
		myMesh = new CreateMesh(length);
		if(!StaticObjects.caveBuilt){

			strtLev = 20;//20
			roofLev = 26;//26
			floorLev = 16;//16
			CA3D myCA = new CA3D(strtLev, roofLev, floorLev, length, height);

			/*textrs = new string[4];
			for (int i = 0; i < 4; i++) {
				textrs[i] = "texture" + (i+1);
			}*/
			myCA.seed("random");
			myCA.fillNextGen("cave", 6, strtLev);
			myCA.border();
			myCA.buildWalls();
			myCA.buildRoof();
			myCA.optimiseCells();
			StaticObjects.cave = myCA.caveArr;
			StaticObjects.caveBuilt = true;
		}
		setup();
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}

	void setup() {
		/*myCA.seed("random");
		myCA.fillNextGen("cave", 5, strtLev);
		myCA.border();
		myCA.buildWalls();
		myCA.buildRoof();
		myCA.optimiseCells();*/

		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {
				for(int y = 0; y < height; y++) {
					if(StaticObjects.cave[x,z,y]==1) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, y*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z,y);
						//int rand = Random.Range(0,4);
						//cube.renderer.material = GameObject.FindGameObjectWithTag(textrs[rand]).renderer.material;
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			}
			
		}

		Instantiate(player);
		audio.Play();
	}

	
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown(KeyCode.T) && canCoRoutine) {
			StartCoroutine(waitForSound());
		}
		if(Input.GetKeyDown(KeyCode.P)) {
			StaticObjects.caveBuilt = !StaticObjects.caveBuilt;
			Application.LoadLevel(Application.loadedLevel);
		}
		if (!canCoRoutine) {
			Instantiate(teleport);
			teleport.transform.localScale += new Vector3(0.01f, 0.01f, 0);
		}
	}
	
	IEnumerator waitForSound() {

		canCoRoutine = false;
		yield return new WaitForSeconds(3.0f);
		;
		//teleport.transform.localScale = new Vector3(1, 1, 1);
		//Application.LoadLevel("EndOfGame");
		Application.LoadLevel(5);
		//Application.LoadLevel(3);
		teleport.transform.localScale = new Vector3(2, 2, 1);
	}
}
