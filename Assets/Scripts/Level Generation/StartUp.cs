using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour {
	public int length;
	public int height;
	int strtLev;
	int roofLev;
	int floorLev;
	CA3D myCA;
	CreateMesh myMesh;
	public Transform cubePrefab;
	public int[,] mapArray;
	public string[] textrs;

	void Start() {
		length = 12*(8);
		height = 60;
		strtLev = 20;//20
		roofLev = 30;//26
		floorLev = 13;//16
		myCA = new CA3D(strtLev, roofLev, floorLev, length, height);
		myMesh = new CreateMesh(length);
		mapArray = new int[length,length];
		textrs = new string[4];
		for (int i = 0; i < 4; i++) {
			textrs[i] = "texture" + (i+1);
		}
		setup();
	}

	void setup() {
		myCA.seed("random");
		myCA.fillNextGen("cave", 5, strtLev);
		myCA.border();
		for(int i = 0; i < length; i++){
			for(int j = 0; j < length; j++) {
				mapArray[i,j] = myCA.caveArr[i,j,strtLev]; 
			}
		}
		//myCA.buildWalls();
		//myCA.buildRoof();
		//myCA.optimiseCells();

		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {
				for(int y = 0; y < height; y++) {
					if(myCA.caveArr[x,z,y]==1) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, y*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z,y);
						int rand = Random.Range(0,4);
						cube.renderer.material = GameObject.FindGameObjectWithTag(textrs[rand]).renderer.material;
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			}
			
		}


	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
