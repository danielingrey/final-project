using UnityEngine;
using System.Collections;

/// <summary>
/// CA3D. Used to create 3D indoor caves and 3D outdoor terrain using stacks of 2D cellular automata held within a 3D array of 1s and 0s.
/// </summary>
public class CA3D {
	/// <summary>
	/// The current generation.
	/// </summary>
	CAGens generation;
	/// <summary>
	/// The level array.
	/// </summary>
	/// <value>The level array.</value>
	public int[,,] caveArr{get;set;}
	/// <summary>
	/// The y coordinate of the level for seeding the initial generation.
	/// </summary>
	private int seedLevel;
	/// <summary>
	/// The y coordinate of the level array to begin running the create roof CA.
	/// </summary>
	private int startRoof;
	/// <summary>
	/// The y coordinate of the level array to begin running the create floor CA.
	/// </summary>
	private int startFloor;
	/// <summary>
	/// The next generation.
	/// </summary>
	private int nextGen;
	/// <summary>
	/// The length and depth of the level array.
	/// </summary>
	private int length;
	/// <summary>
	/// The height of the level array.
	/// </summary>
	private int height;
	/// <summary>
	/// The border size.
	/// </summary>
	private int bord;

	/// <summary>
	/// Initializes a new instance of the <see cref="CA3D"/> class.
	/// </summary>
	/// <param name="sl">Sets the seedLevel.</param>
	/// <param name="sr">Sets startRoof.</param>
	/// <param name="sf">Sets startFloor.</param>
	/// <param name="l">The length and depth of the level array.</param>
	/// <param name="h">The height of the level array.</param>
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

	/// <summary>
	/// Creates a seed generation.
	/// </summary>
	/// <param name="s">Type of seed.</param>
	public void seed(string s) {
		generation.seedCA(s,0.45f);
	}

	/// <summary>
	/// Fills the next generation in the array.
	/// </summary>
	/// <param name="s">Specifies CA rule.</param>
	/// <param name="it">Number of iterations to apply rule to current 2D generation.</param>
	/// <param name="ng">Level in array to place result.</param>
	public void fillNextGen(string s, int it, int ng) {
		string rule = s;
		int iterateNum = it;
		nextGen = ng;
		for(int i = 0; i < iterateNum; i++) {
			generation.nextGeneration(rule);
		}
		fillArray();
	}

	/// <summary>
	/// Builds the walls.
	/// </summary>
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

		for(int i = nextGen; i >= 0; i--, nextGen--) {
			fillNextGen ("roof", 1, nextGen);
		}
	}

	/// <summary>
	/// Performs a bit flip operation.
	/// </summary>
	/// <returns>The flipped bit.</returns>
	/// <param name="bf">Bit to flip.</param>
	public int bitFlip(int bf) {
		int b = bf;
		if((b&1) == 1) {
			b = 0;
		} else {
			b = 1;
		}
		return b;
	}

	/// <summary>
	/// Builds the roof.
	/// </summary>
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

	/// <summary>
	/// Border the current 2D generation.
	/// </summary>
	public void border() {
		generation.createBorder();
		fillArray();
	}

	/// <summary>
	/// Copies the current 2D generation in to the 3D array at position nextGen.
	/// </summary>
	public void fillArray() {
		for(int x = 0; x < length; x++){
			for(int z = 0; z < length; z++) {
				if(generation.currentGen[x,z] == 1) caveArr[x,z,nextGen] = 1;
				if(generation.currentGen[x,z] == 0) caveArr[x,z,nextGen] = 0;
			}
		}
	}

	/// <summary>
	/// Builds a floor when the algorithm is used for exterior sections to fill in gaps as instantiation of cubes starts mid array, not from the bottom.
	/// </summary>
	public void buildFloor() {
		for(int x = 0; x < length; x++) {
			for(int z = 0; z < length; z++) {
				int count = 0;
				for(int y = 0; y < height; y++) {
					if(caveArr[x,z,y] == 1) count++; // check each (x,z) coordinate along the y axis for any 1's
				}
				if(count == 0) caveArr[x,z,20] = 1; // if no 1's are found there is a gap so fill it in at the floor layer
			}
		}
	}

	/// <summary>
	/// Optimises the 3D cell array before instatiating cubes to cut down on load time/memory use.
	/// </summary>
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
					if((y==0) || (y==height-1)) { //kill cells at the top and bottom of the array as these can't be seen by the player after instantiation of cubes
						optArr[x,z,y] = 0;
					}
					else if((caveArr[x,z,y] == 1) && (neighbours == 8) && (caveArr[x,z,y+1] != 0) && (caveArr[x,z,y-1] != 0)) { //if a cell has 8 neighbours and cells above and below it then kill it
						optArr[x,z,y] = 0;					
					} else {
						optArr[x,z,y] = caveArr[x,z,y];
					}
				}
			}
		}
		caveArr = optArr; 			
		trimCells();
	}

	/// <summary>
	/// Kills the cells along the edges of the array as the player can't see these after instantiating the cubes.
	/// </summary>
	public void trimCells() {
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
