using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class AdHoc {
	public int[,,] levelArr {get;set;}
	int length; //section length
	int height; //section height
	int sectNum; //number of sections
	StreamReader file;
	string line;
	string[] lines = new string[8];
	string path;
	int[,,] my3DArr;



	public AdHoc(int l, int h, int sn) {
		length = l;
		height = h;
		sectNum = sn;
		lines = new string[length];
		my3DArr = new int[length,length,height];
		levelArr = new int[sectNum,sectNum,height];
		path = Directory.GetCurrentDirectory();
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
			file = new StreamReader (s + k + ".txt");
			for (int i = 0; i < 8; i++) {
				line = file.ReadLine ();
				for (int j = 0; j < 8; j++) {
					for (int num = 0; num < 8; num++) {
						lines [num] = Convert.ToString (line [j]);
					}
					my3DArr [i, j, k] = Convert.ToInt32 (lines [j]);					

				}
			}
			file.Close ();
		}
	}

	void randomiseSection(string s) {
		float prob;
		string section = s;
		if(section == "wall") {
			prob = 0.45f;
		} else if (section == "interior") {
			prob = 0.33f;
		} else {
			prob = 0;
		}
		int rand = UnityEngine.Random.Range(0,3);
		//for(int i = 0; i < rand; i++) {
		//for(int y = 0; y < 16; y++) {	
			for(int x = 0; x < 8; x++) {				
				for( int z = 0; z < 8; z++) {
					for(int y = 0; y < 16; y++) {
					if(y-1 >= 0 && y < 4)  {
							if (UnityEngine.Random.value < prob){								
									if (my3DArr[x,z,y-1] == 1) my3DArr[x,z,y] = 1;								
							}
					} else if(y+1 <= 15 && y >= 8) {
						if (UnityEngine.Random.value < prob){								
							if (my3DArr[x,z,y+1] == 1) my3DArr[x,z,y] = 1;								
						}
					}

					} 
				}
				
			}
		//}
	}
	
	public void placeCorners() {
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
	
	public void placeWalls() {
		string section = "wall";
		//top
		getSection (path + @"\Assets\Level Files\Walls\WallsT\wall0\wallT");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(0,i);
		}
		//right
		getSection (path + @"\Assets\Level Files\Walls\WallsR\wall0\wallR");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(i,7);
		}
		//bottom
		getSection (path + @"\Assets\Level Files\Walls\WallsB\wall0\wallB");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(7,i);
		}
		//left
		getSection (path + @"\Assets\Level Files\Walls\WallsL\wall0\wallL");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(i,0);
		}
	}
	
	public void placeInteriors() {
		string section = "interior";
		for (int i = 1; i < 7; i++) {
			for (int j = 1; j < 7; j++) {
				int rand = UnityEngine.Random.Range(0,5);
				getSection (path + @"\Assets\Level Files\Interiors\interior" + rand + @"\interior");
				randomiseSection(section);
				placeSection(i,j);
			}
		}
	}

}
