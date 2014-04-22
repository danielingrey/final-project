﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class dataStartup : MonoBehaviour {
	int counter = 0;
	StreamReader file;
	string line;
	string[] lines = new string[8];
	char[] nums;
	int[,] myArr = new int[8,8];
	int[,,] my3DArr = new int[8,8,16];
	int[,,] levelArr = new int[64, 64, 16];
	int[] ij = {0,0};
	public Transform cubePrefab;
	// Use this for initialization

	void Start () {
		getSection (@"C:\Users\Dan\Documents\Unity\Final Project\Assets\Level Files\Interiors\interior0\interior");
			/*for (int k = 0; k < 16; k++) {
					//
					//file = new StreamReader(@"C:\Users\Dan\Documents\Unity\Final Project\Assets\Level Files\Corners\corner" + k + ".txt");

					file = new StreamReader (@"C:\Users\Dan\Documents\Unity\Final Project\Assets\Level Files\Interiors\interior0\interior" + k + ".txt");
					//file = new StreamReader(@"C:\Users\Dan\Documents\Uni\Year Three\Final Project\Unity\Final Project\Assets\Level Files\Walls\wall" + k + ".txt");
					//while((line = file.ReadLine()) != null)
			{
				print(line);
				counter++;
			}
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
		}*/
		for (int i = 1; i < 7; i++) {
			for (int j = 1; j < 7; j++) {
				placeSection(i,j);
			}
		}

		getSection (@"C:\Users\Dan\Documents\Unity\Final Project\Assets\Level Files\Corners\corner0\corner");

	    placeSection(0,0);
		//placeSection(0,7);
		//placeSection(7,0);
		//placeSection(7,7);

		for(int x = 0; x < 64; x++) {				
			for( int z = 0; z < 64; z++) {
				for(int y = 0; y < 16; y++) {
					if(levelArr[x,z,y]==1) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, y*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						/*int m = myMesh.getMesh(x,z,y);
						int rand = Random.Range(0,4);
						cube.renderer.material = GameObject.FindGameObjectWithTag(textrs[rand]).renderer.material;
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;*/
					}	
				}
			}
			
		}
	}

	// Update is called once per frame
	void Update () {
	
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
}
