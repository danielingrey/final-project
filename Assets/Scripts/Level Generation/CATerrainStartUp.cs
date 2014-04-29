using UnityEngine;
using System.Collections;


public class CATerrainStartUp : MonoBehaviour {
	int length = 128;
	int height = 60;
	int strtLev;
	int roofLev;
	int floorLev;
	CreateMesh myMesh;
	public Transform cubePrefab;
	string[] textrs;
	//public static int[,,] terrain;
	//public static bool built = false;

	void Start() {
		Debug.Log (StaticObjects.terrainBuilt);
		myMesh = new CreateMesh(length);
		if(!StaticObjects.terrainBuilt){
			Debug.Log (StaticObjects.terrainBuilt);
			strtLev = 20;//20
			roofLev = 30;//26
			floorLev = 13;//16
			CA3D myCA = new CA3D(strtLev, roofLev, floorLev, length, height);

			/*textrs = new string[4];
			for (int i = 0; i < 4; i++) {
				textrs[i] = "texture" + (i+1);
			}*/
			myCA.seed("random");
			myCA.fillNextGen("cave", 5, strtLev);
			myCA.border();
			myCA.buildWalls();
			myCA.buildRoof();
			myCA.optimiseCells();
			//optimise floor here?
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
		Debug.Log (StaticObjects.terrainBuilt);
		setup();
	}
	
	void setup() {

		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {
				for(int y = 20; y < height; y++) {
					//if(myCA.caveArr[x,z,y]==1 || y == 20) {
					if(StaticObjects.terrain[x,z,y]==1 || y == 20) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, (y-20)*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z,y);
						int rand = Random.Range(0,4);
						//cube.renderer.material = GameObject.FindGameObjectWithTag(textrs[rand]).renderer.material;
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			}
			
		}
		
		
	}
	

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) Application.LoadLevel("CaveCA");
	}
}
