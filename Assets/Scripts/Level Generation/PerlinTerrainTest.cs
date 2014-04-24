using UnityEngine;
using System.Collections;

public class PerlinTerrainTest : MonoBehaviour {
	PNHeightMap myHM;
	public Transform cubePrefab;
	CreateMesh myMesh;

	// Use this for initialization
	void Start () {
		myHM = new PNHeightMap(128);
		myHM.perlHghtMap(0.06f,0.06f);
		myMesh = new CreateMesh(128);

		for(int x = 0; x < 128; x++) {				
			for( int z = 0; z < 128; z++) {					
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, myHM.arr2D[x,z]*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z);						
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			
			

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
