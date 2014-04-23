using UnityEngine;
using System.Collections;
using System.IO;
using System;


public class AdHocStartupTest : MonoBehaviour {
	int length;

	StreamReader file;
	string line;
	string[] lines = new string[8];
	//char[] nums;
	int[,,] my3DArr = new int[8,8,16];
	int[,,] levelArr = new int[64, 64, 16];
	CreateMesh myMesh;
	public Transform cubePrefab;
	string path = Directory.GetCurrentDirectory();

	void Start () {
		length = 64;
		myMesh = new CreateMesh(length);
		placeCorners();
		placeWalls();
		placeInteriors();



		for(int x = 0; x < 64; x++) {				
			for( int z = 0; z < 64; z++) {
				for(int y = 0; y < 16; y++) {
					if(levelArr[x,z,y]==1) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, y*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z,y);
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			}
			
		}
	}

	void placeSection(int i, int j) {

		for(int x = 0; x < 8; x++) {				
			for( int z = 0; z < 8; z++) {
				for(int y = 0; y < 16; y++) {
					levelArr[x+(i*8),z+(j*8),y] = my3DArr[x,z,y]; 
				}
			}

		}
	}

	void getSection(string s) {
		for (int k = 0; k < 16; k++) {
			//
			//file = new StreamReader(@"C:\Users\Dan\Documents\Unity\Final Project\Assets\Level Files\Corners\corner" + k + ".txt");
			
			file = new StreamReader (s + k + ".txt");
			//file = new StreamReader(@"C:\Users\Dan\Documents\Uni\Year Three\Final Project\Unity\Final Project\Assets\Level Files\Walls\wall" + k + ".txt");
			/*while((line = file.ReadLine()) != null)
			{
				print(line);
				counter++;
			}*/
			for (int i = 0; i < 8; i++) {
				line = file.ReadLine ();
				for (int j = 0; j < 8; j++) {
					for (int num = 0; num < 8; num++) {
						lines [num] = Convert.ToString (line [j]);
					}
					my3DArr [i, j, k] = Convert.ToInt32 (lines [j]);
					
					//print (i + " " + j);
					
					//if(counter < 7) counter++;
				}
			}
			for (int i = 0; i < 8; i++) {
				//print (myArr[i,0] + " " + myArr[i,1] + " " + myArr[i,2] + " "  + myArr[i,3] + " "  + myArr[i,4] + " "  + myArr[i,5] + " "  + myArr[i,6] + " "  + myArr[i,7]);
			}
			file.Close ();
		}
	}

	void placeCorners() {
		//Top left
		getSection (path + @"\Assets\Level Files\Corners\CornersTL\corner0\cornerTL");
		placeSection(0,0);
		//Top right
		getSection (path + @"\Assets\Level Files\Corners\CornersTR\corner0\cornerTR");
		placeSection(0,7);
		//Bottom left
		getSection (path + @"\Assets\Level Files\Corners\CornersBL\corner0\cornerBL");
		placeSection(7,0);
		//Bottom right
		getSection (path + @"\Assets\Level Files\Corners\CornersBR\corner0\cornerBR");
		placeSection(7,7);
	}

	void placeWalls() {
		//top
		getSection (path + @"\Assets\Level Files\Walls\WallsT\wall0\wallT");
		for (int i = 1; i < 7; i++) {
			placeSection(0,i);
		}
		//right
		getSection (path + @"\Assets\Level Files\Walls\WallsR\wall0\wallR");
		for (int i = 1; i < 7; i++) {
			placeSection(i,7);
		}
		//bottom
		getSection (path + @"\Assets\Level Files\Walls\WallsB\wall0\wallB");
		for (int i = 1; i < 7; i++) {
			placeSection(7,i);
		}
		//left
		getSection (path + @"\Assets\Level Files\Walls\WallsL\wall0\wallL");
		for (int i = 1; i < 7; i++) {
			placeSection(i,0);
		}
	}

	void placeInteriors() {
		for (int i = 1; i < 7; i++) {
			for (int j = 1; j < 7; j++) {
				int rand = UnityEngine.Random.Range(0,5);
				getSection (path + @"\Assets\Level Files\Interiors\interior" + rand + @"\interior");
				placeSection(i,j);
			}
		}
	}

}
