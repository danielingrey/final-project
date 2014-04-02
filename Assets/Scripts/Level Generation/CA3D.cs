using UnityEngine;
using System.Collections;

public class CA3D {
	CAGens generation;
	public int[,,] caveArr{get;set;}
	int seedLevel; // the y coordinate of the level for seeding the initial generation
	int startRoof; // the y coordinate of the level to begin running the roof create CA
	int startFloor;
	int nextGen;
	int length;
	int height;
	int bord; //border size

	public CA3D(int sl, int sr, int sf, int l, int h) {
		length = l;
		height = h;
		bord = 0;
		caveArr = new int[length,length,height];
		for(int x = 0; x < length; x++){
			for(int z = 0; z < length; z++) {
				for(int y = 0; y < height; y++) {
					caveArr[x,z,y] =  0;
				}
			}
		}
		seedLevel = sl;
		startRoof = sr;
		startFloor = sf;
		nextGen = seedLevel;
		generation = new CAGens(length, bord);
	}

	public void seed(string s) {
		generation.seedCA(s,0.45f);
		/*for(int x = 0; x < length; x++){
			for(int z = 0; z < length; z++) {
				caveArr[x,z,2] = generation.currentGen[x,z];
			}
		}*/
	}

	/* accepts string to specify CA rule, how many iterations to apply that rule to the selected 2d grid and which
	 * row to put it in to in the 3d array
	 */
	public void fillNextGen(string s, int it, int ng) {
		string rule = s;
		int iterateNum = it;
		nextGen = ng;
		for(int i = 0; i < iterateNum; i++) {
			generation.nextGeneration(rule);
		}
		fillArray();
	}

	public void buildWalls() {
		string[] ruleArr = {"two","three"};
		int b = 1;
		nextGen = seedLevel+1;
		//build walls upwards starting from seed level
		for(int i = nextGen; i < seedLevel+startRoof+1; i++, nextGen++) {
			if(b==1){
				fillNextGen (ruleArr[b], 1, nextGen);
			}else {
				fillNextGen ("roof", 1, nextGen);
			}
			b = bitFlip(b);
		}

		nextGen = seedLevel-1;
		for(int x = 0; x < length; x++){
			for(int z = 0; z < length; z++) {
				generation.currentGen[x,z] = caveArr[x,z,seedLevel]; // reset current generation to original seed generation
			}
		}
		b = bitFlip(b); 
		//build walls downwards starting from seed level
		for(int i = nextGen; i >= seedLevel-startFloor; i--, nextGen--) {
			if(b==1){
				fillNextGen (ruleArr[b], 1, nextGen);
			}else {
				fillNextGen ("roof", 1, nextGen);
			}
			b = bitFlip(b);
		}
		//nextGen = 17;
		for(int i = nextGen; i >= 0; i--, nextGen--) {
			fillNextGen ("roof", 1, nextGen);
		}
	}

	public int bitFlip(int bf) {
		int b = bf;
		if((b&1) == 1) {
			b = 0;
		} else {
			b = 1;
		}
		return b;
	}

	public void buildRoof() {
		nextGen = startRoof;
		for(int x = 0; x < length; x++){
			for(int z = 0; z < length; z++) {
				generation.currentGen[x,z] = caveArr[x,z,nextGen]; // reset current generation to original roof generation
			}
		}
		for(int i = nextGen; i < height; i++, nextGen++) {
			fillNextGen ("roof", 1, nextGen);
		}

	}

	public void border() {
		generation.createBorder();
		fillArray();
	}

	public void fillArray() {
		for(int x = 0; x < length; x++){
			for(int z = 0; z < length; z++) {
				if(generation.currentGen[x,z] == 1) caveArr[x,z,nextGen] = 1;
				if(generation.currentGen[x,z] == 0) caveArr[x,z,nextGen] = 0;
			}
		}
	}

	public void optimiseCells() {


		nextGen = 0;
		int[,,] optArr = new int[length,length,height];

		for(int y = 0; y < height; y++) {
			for(int x = 1; x < length-1; x++) {
				for(int z = 1; z < length-1; z++) {
					int neighbours = 0;				
					for (int i = -1;i <= 1; i++) {
						for(int j = -1; j <= 1; j++) {
							neighbours += caveArr[x+i,z+j,y];
						}
					}
					
					neighbours -= caveArr[x,z,y];
					if((y==0) || (y==height-1)) {
						optArr[x,z,y] = 0;
					}
					else if((caveArr[x,z,y] == 1) && (neighbours == 8) && (caveArr[x,z,y+1] != 0) && (caveArr[x,z,y-1] != 0)) {
						optArr[x,z,y] = 0;
						//if(y == 0) optArr[x,z,y] = 0;
						//if((y > 0) && (caveArr[x,z,y-1] != 0)) optArr[x,z,y] = 0; //this makes sure cells that make up the roof aren't removed
					
					} else {
						optArr[x,z,y] = caveArr[x,z,y];
					}
				}
			}
		}

		caveArr = optArr; 			
		trimCells();

	}

	/*
	 * trims the edges of the level
	 */
	public void trimCells() {
		/*int cut = c;
		int xNum = 0;
		int zNum = 0;
		int xStNum = 0;
		int zStNum = 0;

		for (int i = 0; i < 4; i++) {
			if(i==0) {
				xNum = cut;
				zNum = length;
			} else if (i==1) {
				xNum = length;
				zNum = cut;
			} else if (i==2) {
				xStNum = length - cut;
				xNum = length;
				zNum = length;
			} else if (i==3) {
				zStNum = length - cut;
				xNum = length;
				zNum = length;
			}
			
			for(int y = 0; y < height; y++) {
				for(int x = xStNum; x < xNum; x++) {
					for(int z = zStNum; z < zNum; z++) {
						if(caveArr[x,z,y] == 1) caveArr[x,z,y] = 0;
					}
				}
			}
		}*/
		int endCut = length-1;
		for(int y = 1; y < height; y++) {
			for(int i = 1; i < length; i++) {
				caveArr[i,1,y] = 0;
				caveArr[1,i,y] = 0;
				caveArr[endCut-i,endCut-1,y] = 0;
				caveArr[endCut-1,endCut-i,y] = 0;
			}
		}
	}

}
