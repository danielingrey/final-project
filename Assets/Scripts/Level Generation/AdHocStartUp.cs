using UnityEngine;
using System.Collections;

public class AdHocStartUp : MonoBehaviour {
	int sectLen; //section length
	int caveLen; //cave length
	int height; //cave height
	int sectNum; //number of sections
	AdHoc myAdHoc;
	CreateMesh myMesh; 
	public Transform cubePrefab;

	// Use this for initialization
	void Start () {
		sectLen = 8;
		caveLen = 64;
		height = 16;
		sectNum = 64;
		myAdHoc = new AdHoc(sectLen, height, sectNum);
		myMesh = new CreateMesh(sectNum);
		//textures
		setup();
	}
	
	void setup() {
		myAdHoc.placeCorners();
		myAdHoc.placeWalls();
		myAdHoc.placeInteriors();

		for(int x = 0; x < caveLen; x++) {				
			for( int z = 0; z < caveLen; z++) {
				for(int y = 0; y < height; y++) {
					if(myAdHoc.levelArr[x,z,y]==1) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, y*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z,y);
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			}
			
		}
	}
}
