using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;


public class CATerrainStartUp : MonoBehaviour {
	int length = 128;
	int height = 60;
	int strtLev;
	int roofLev;
	int floorLev;
	CreateMesh myMesh;
	bool canCoRoutine = true;
	public Transform cubePrefab;
	public Transform player;
	public GUITexture teleport;

	void Start() {
		//Stopwatch stopWatch = new Stopwatch();
		//stopWatch.Start();

		myMesh = new CreateMesh(length);
		if(!StaticObjects.terrainBuilt){
			strtLev = 20;//20
			roofLev = 30;//26
			floorLev = 13;//16
			CA3D myCA = new CA3D(strtLev, roofLev, floorLev, length, height);

		
			myCA.seed("random");
			myCA.fillNextGen("cave", 5, strtLev);
			myCA.border();
			myCA.buildWalls();
			myCA.buildRoof();
			myCA.optimiseCells();

			StaticObjects.terrain = myCA.caveArr;
			//StaticObjects.terrain = (int[,,])myCA.caveArr.Clone();
			//System.Array.Copy(myCA.caveArr,StaticObjects.terrain, 128*128*60);
			/*for(int x = 0; x < length; x++) {
				for(int z = 0; z < length; z++) {
					for(int y = 0; y < height; y++) {
						StaticObjects.terrain[x,z,y] = myCA.caveArr[x,z,y];
					}
				}
			}*/

			StaticObjects.terrainBuilt = true;
		}
		//Debug.Log (StaticObjects.terrainBuilt);
		setup();
		//stopWatch.Stop();
		//TimeSpan ts = stopWatch.Elapsed;
		//print ( ts.Seconds + "." + ts.Milliseconds); 
	}
	
	void setup() {

		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {
				for(int y = 20; y < height; y++) {
					//if(myCA.caveArr[x,z,y]==1 || y == 20) {
					if(StaticObjects.terrain[x,z,y]==1 || y == 20) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, (y-20)*1.5f, z*1.5f), Quaternion.identity) as Transform;							
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
		if (!canCoRoutine) {
			Instantiate(teleport);
			teleport.transform.localScale += new Vector3(0.01f, 0.01f, 0);
		}
	}
	
	IEnumerator waitForSound() {

		canCoRoutine = false;
		yield return new WaitForSeconds(3.0f);

		//Application.LoadLevel("CaveCA");
		Application.LoadLevel(4);
		//Application.LoadLevel(2);
		teleport.transform.localScale = new Vector3(2, 2, 1);
	}
}
