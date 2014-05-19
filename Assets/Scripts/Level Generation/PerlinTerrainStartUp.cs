using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

public class PerlinTerrainStartUp : MonoBehaviour {
	int length = 128;
	//int height = 60;
	public Transform cubePrefab;
	public Transform player;
	bool canCoRoutine = true;
	public GUITexture teleport;

	CreateMesh myMesh;

	// Use this for initialization
	void Start () {
		Stopwatch stopWatch = new Stopwatch();
		stopWatch.Start();
		myMesh = new CreateMesh(128);
		if(!StaticObjects.pnTBuilt){
			PNHeightMap myHM = new PNHeightMap(128);
			myHM.perlHghtMap(0.05f,0.05f);
			StaticObjects.pnTerrain = myHM.arr2D;
			StaticObjects.pnTBuilt = true;
		}
		setup();
		stopWatch.Stop();
		TimeSpan ts = stopWatch.Elapsed;
		print ( ts.Seconds + "." + ts.Milliseconds); 
	}

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

		Application.LoadLevel(2);
		//Application.LoadLevel(4);
		teleport.transform.localScale = new Vector3(2, 2, 1);
	}

}
