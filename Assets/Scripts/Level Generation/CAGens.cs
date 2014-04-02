using UnityEngine;
using System.Collections;

public class CAGens {
	public int[,] currentGen{get;set;} // 2D representation of the current generation
	public int[,] nextGen; // 2D representation of the next generation 
	int border; // creates a border to give cells room to grow within the array
	int length;


	public CAGens(int l, int b) {
		length = l;
		currentGen = new int[length,length];
		nextGen = new int[length,length];
		border = b;
		for(int x = 0; x < length; x++) {
			for(int z = 0; z < length; z++) {
				currentGen[x,z] = 0;
			}
		}
	}

	// method to seed an initial starting point for the CA
	public void seedCA(string s, float f) {
		float seedVal = f;
		if(s == "random") {
			for(int x = border; x < length-border; x++){
				for(int z = border; z < length-border; z++){
					float rand = Random.value;
					if(rand < seedVal) {
						currentGen[x,z] = 1;
					} else {
						currentGen[x,z] = 0;
					}				
				}
			}
		} else {
			// another method for seeding (not implemented yet)
		}
		 
	}

	public void createBorder() { // after initial seeding border can be created to enclose the level
		int edge = 7; 
		for(int i = 0; i < 4; i++) {
			if (i > 1) edge = length-edge;
			for(int j = edge; j < length-edge; j++) {
				currentGen[j,edge] = 1;
				currentGen[j,length-edge] = 1;
				currentGen[edge,j] = 1;
				currentGen[length-edge,j] = 1;
			}
		}

		// randomly seed some cells within the border to create more natural outside walls
		float val = 0.3f;
		edge++;
		for(int i = 0; i < 4; i++) {
			if (i > 1) edge = length-edge;
			for(int j = edge; j < length-edge; j++) {										
				float rand = Random.value;
				if(rand < val) currentGen[j,edge] = 1;
				rand = Random.value;
				if(rand < val) currentGen[j,length-edge] = 1;
				rand = Random.value;
				if(rand < val) currentGen[edge,j] = 1;
				rand = Random.value;
				if(rand < val) currentGen[length-edge,j] = 1;				
			}
		}

	}

	public void nextGeneration(string r) {
		string rules = r;
		int[,] neighbours = countNeighbours();
		applyRule(rules, neighbours);
		currentGen = nextGen;
	}

	public int[,] countNeighbours() {
		int [,]neighbours = new int[length,length];			
		for(int x = 1; x < length-1; x++) {
			for(int z = 1; z < length-1; z++) {
				neighbours[x,z] = 0;
				for (int i = -1;i <= 1; i++) {
					for(int j = -1; j <= 1; j++) {
						neighbours[x,z] += currentGen[i+x,j+z];
					}
				}
				neighbours[x,z] -= currentGen[x,z];
			}
		}
		return neighbours;	
				
	}

	public void applyRule(string r, int[,] n) {
		int[,] neighbours = n;
		
		for(int x = 1; x < length-1; x++) {				
			for( int z = 1; z < length-1; z++) {
				if (r == "cave") { // rule to create cave like 2D grid
					if((currentGen[x,z] == 1) && (neighbours[x,z] >= 4)) {						
						nextGen[x,z] = currentGen[x,z];
					} else if ((currentGen[x,z] == 0) && (neighbours[x,z] >= 5)) {
						nextGen[x,z] = 1;
					} else {
						nextGen[x,z] = 0;
					}
				} else if( r == "two") { // cells are born if they have 2 neighbours otherwise they stay the same
					if((currentGen[x,z] == 0) && (neighbours[x,z] == 2)) {						
						nextGen[x,z] = 1;
					} else if ((currentGen[x,z] == 0) && (neighbours[x,z] >= 5)) {
						nextGen[x,z] = currentGen[x,z];
					}
				} else if( r == "three") { // cells are born if they have 3 neighbours otherwise they stay the same
					if((currentGen[x,z] == 0) && (neighbours[x,z] == 3)) {						
						nextGen[x,z] = 1;
					} else if ((currentGen[x,z] == 0) && (neighbours[x,z] >= 5)) {
						nextGen[x,z] = currentGen[x,z];
					}
				} else if(r == "roof") { // any dead cells with more than one neighbour this creates the roof of the cave
					if((currentGen[x,z] == 0) && (neighbours[x,z] > 1)) {						
						nextGen[x,z] = 1;
					} else {
						nextGen[x,z] = currentGen[x,z];
					}
				} 
			}
		}
	}
}
