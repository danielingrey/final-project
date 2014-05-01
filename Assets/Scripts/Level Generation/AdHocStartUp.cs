using UnityEngine;
using System.Collections;

public class AdHocStartUp : MonoBehaviour {
	int sectLen; //section length
	int caveLen  = 64; //cave length
	int height = 16; //cave height
	int sectNum = 64; //number of sections
	AdHoc myAdHoc;
	CreateMesh myMesh; 
	public Transform cubePrefab;
	public Transform player;

	// Use this for initialization
	void Start () {
		myMesh = new CreateMesh(sectNum);
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
		setup();
	}
	
	void setup() {


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
	}

	void Update(){
		if (Input.GetKey(KeyCode.T)) Application.LoadLevel("TerrainCA");
	}
}
