using UnityEngine;
using System.Collections;

public class CAStartUp : MonoBehaviour {
	int length = 64;
	int height = 60;
	int strtLev;
	int roofLev;
	int floorLev;
	CreateMesh myMesh;
	public Transform cubePrefab;
	public Transform player;
	//string[] textrs;
	//public static int[,,] cave;
	//public static bool built = false;

	void Start() {
		myMesh = new CreateMesh(length);
		if(!StaticObjects.caveBuilt){

			strtLev = 20;//20
			roofLev = 30;//26
			floorLev = 13;//16
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

	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.T)) Application.LoadLevel("startSceneTest");

		//if (Input.GetMouseButtonDown(0)) Application.LoadLevel("TerrainCA");
	}

}
