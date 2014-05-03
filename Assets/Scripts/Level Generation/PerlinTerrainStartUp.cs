using UnityEngine;
using System.Collections;

public class PerlinTerrainStartUp : MonoBehaviour {
	int length = 128;
//	int height = 60;
	public Transform cubePrefab;
	public Transform player;
	CreateMesh myMesh;

	// Use this for initialization
	void Start () {
		myMesh = new CreateMesh(128);
		if(!StaticObjects.pnTBuilt){
			PNHeightMap myHM = new PNHeightMap(128);
			myHM.perlHghtMap(0.06f,0.06f);
			StaticObjects.pnTerrain = myHM.arr2D;
			StaticObjects.pnTBuilt = true;
		}
		setup();
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
	}

	void Update(){
		if (Input.GetKey(KeyCode.T)) Application.LoadLevel("CaveAdHoc");
	}
}
