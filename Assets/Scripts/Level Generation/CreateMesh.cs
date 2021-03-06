﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Used to get coordinates of cubes within sections of the level to be combined later as meshes.
/// </summary>
public class CreateMesh {

	/// <summary>
	/// The number of meshes.
	/// </summary>
	int meshNum = 64;
	/// <summary>
	/// Gets or sets the mesh tag string array.
	/// </summary>
	/// <value>The mesh tags.</value>
	public string[] meshTags{get;set;}
	/// <summary>
	/// level length/widths must be multiples of 8. This holds the level length/width divided by 8.
	/// </summary>
	int eighth;

	/// <summary>
	/// Initializes a new instance of the <see cref="CreateMesh"/> class.
	/// </summary>
	/// <param name="n">length/width of the level.</param>
	public CreateMesh(int n) {
		eighth = n/8;
		meshTags = new string[meshNum];
		for (int i = 0; i < meshNum; i++) { // add mesh tag names to the string array to correspond with the tag names in the unity editor.
			meshTags[i] = "mesh" + (i+1);
		}
	}

	/// <summary>
	/// Gets the mesh tag's array index to be applied to the current cube. Used by the 3D arrays.
	/// </summary>
	/// <returns>The mesh tag index.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public int getMesh(int x, int z,int y) {
		
		if((x < eighth) && (z < eighth)) return 0;			 
		if((x < eighth) && (z < 2*eighth)) return 1;
		if((x < eighth) && (z < 3*eighth)) return 2;
		if((x < eighth) && (z < 4*eighth)) return 3;
		if((x < eighth) && (z < 5*eighth)) return 4;
		if((x < eighth) && (z < 6*eighth)) return 5;
		if((x < eighth) && (z < 7*eighth)) return 6;
		if((x < eighth) && (z < 8*eighth)) return 7;
		if((x < 2*eighth) && (z < eighth)) return 8;		
		if((x < 2*eighth) && (z < 2*eighth)) return 9;
		if((x < 2*eighth) && (z < 3*eighth)) return 10;
		if((x < 2*eighth) && (z < 4*eighth)) return 11;
		if((x < 2*eighth) && (z < 5*eighth)) return 12;
		if((x < 2*eighth) && (z < 6*eighth)) return 13;
		if((x < 2*eighth) && (z < 7*eighth)) return 14;
		if((x < 2*eighth) && (z < 8*eighth)) return 15;
		if((x < 3*eighth) && (z < eighth)) return 16;		
		if((x < 3*eighth) && (z < 2*eighth)) return 17;
		if((x < 3*eighth) && (z < 3*eighth)) return 18;
		if((x < 3*eighth) && (z < 4*eighth)) return 19;
		if((x < 3*eighth) && (z < 5*eighth)) return 20;
		if((x < 3*eighth) && (z < 6*eighth)) return 21;
		if((x < 3*eighth) && (z < 7*eighth)) return 22;
		if((x < 3*eighth) && (z < 8*eighth)) return 23;
		if((x < 4*eighth) && (z < eighth)) return 24;		
		if((x < 4*eighth) && (z < 2*eighth)) return 25;
		if((x < 4*eighth) && (z < 3*eighth)) return 26;
		if((x < 4*eighth) && (z < 4*eighth)) return 27;
		if((x < 4*eighth) && (z < 5*eighth)) return 28;
		if((x < 4*eighth) && (z < 6*eighth)) return 29;
		if((x < 4*eighth) && (z < 7*eighth)) return 30;
		if((x < 4*eighth) && (z < 8*eighth)) return 31;
		if((x < 5*eighth) && (z < eighth)) return 32;
		if((x < 5*eighth) && (z < 2*eighth)) return 33;
		if((x < 5*eighth) && (z < 3*eighth)) return 34;
		if((x < 5*eighth) && (z < 4*eighth)) return 35;
		if((x < 5*eighth) && (z < 5*eighth)) return 36;
		if((x < 5*eighth) && (z < 6*eighth)) return 37;
		if((x < 5*eighth) && (z < 7*eighth)) return 38;
		if((x < 5*eighth) && (z < 8*eighth)) return 39;
		if((x < 6*eighth) && (z < eighth)) return 40;
		if((x < 6*eighth) && (z < 2*eighth)) return 41;
		if((x < 6*eighth) && (z < 3*eighth)) return 42;
		if((x < 6*eighth) && (z < 4*eighth)) return 43;
		if((x < 6*eighth) && (z < 5*eighth)) return 44;
		if((x < 6*eighth) && (z < 6*eighth)) return 45;
		if((x < 6*eighth) && (z < 7*eighth)) return 46;
		if((x < 6*eighth) && (z < 8*eighth)) return 47;
		if((x < 7*eighth) && (z < eighth)) return 48;
		if((x < 7*eighth) && (z < 2*eighth)) return 49;
		if((x < 7*eighth) && (z < 3*eighth)) return 50;
		if((x < 7*eighth) && (z < 4*eighth)) return 51;
		if((x < 7*eighth) && (z < 5*eighth)) return 52;
		if((x < 7*eighth) && (z < 6*eighth)) return 53;
		if((x < 7*eighth) && (z < 7*eighth)) return 54;
		if((x < 7*eighth) && (z < 8*eighth)) return 55;
		if((x < 8*eighth) && (z < eighth)) return 56;
		if((x < 8*eighth) && (z < 2*eighth)) return 57;
		if((x < 8*eighth) && (z < 3*eighth)) return 58;
		if((x < 8*eighth) && (z < 4*eighth)) return 59;
		if((x < 8*eighth) && (z < 5*eighth)) return 60;
		if((x < 8*eighth) && (z < 6*eighth)) return 61;
		if((x < 8*eighth) && (z < 7*eighth)) return 62;
		if((x < 8*eighth) && (z < 8*eighth)) return 63;
		
		return 0;
	}

	/// <summary>
	/// Gets the mesh tag's array index to be applied to the current cube. Used by the 2D Perlin Noise array.
	/// </summary>
	/// <returns>The mesh tag index.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	public int getMesh(int x, int z) {
		
		if((x < eighth) && (z < eighth)) return 0;			 
		if((x < eighth) && (z < 2*eighth)) return 1;
		if((x < eighth) && (z < 3*eighth)) return 2;
		if((x < eighth) && (z < 4*eighth)) return 3;
		if((x < eighth) && (z < 5*eighth)) return 4;
		if((x < eighth) && (z < 6*eighth)) return 5;
		if((x < eighth) && (z < 7*eighth)) return 6;
		if((x < eighth) && (z < 8*eighth)) return 7;
		if((x < 2*eighth) && (z < eighth)) return 8;		
		if((x < 2*eighth) && (z < 2*eighth)) return 9;
		if((x < 2*eighth) && (z < 3*eighth)) return 10;
		if((x < 2*eighth) && (z < 4*eighth)) return 11;
		if((x < 2*eighth) && (z < 5*eighth)) return 12;
		if((x < 2*eighth) && (z < 6*eighth)) return 13;
		if((x < 2*eighth) && (z < 7*eighth)) return 14;
		if((x < 2*eighth) && (z < 8*eighth)) return 15;
		if((x < 3*eighth) && (z < eighth)) return 16;		
		if((x < 3*eighth) && (z < 2*eighth)) return 17;
		if((x < 3*eighth) && (z < 3*eighth)) return 18;
		if((x < 3*eighth) && (z < 4*eighth)) return 19;
		if((x < 3*eighth) && (z < 5*eighth)) return 20;
		if((x < 3*eighth) && (z < 6*eighth)) return 21;
		if((x < 3*eighth) && (z < 7*eighth)) return 22;
		if((x < 3*eighth) && (z < 8*eighth)) return 23;
		if((x < 4*eighth) && (z < eighth)) return 24;		
		if((x < 4*eighth) && (z < 2*eighth)) return 25;
		if((x < 4*eighth) && (z < 3*eighth)) return 26;
		if((x < 4*eighth) && (z < 4*eighth)) return 27;
		if((x < 4*eighth) && (z < 5*eighth)) return 28;
		if((x < 4*eighth) && (z < 6*eighth)) return 29;
		if((x < 4*eighth) && (z < 7*eighth)) return 30;
		if((x < 4*eighth) && (z < 8*eighth)) return 31;
		if((x < 5*eighth) && (z < eighth)) return 32;
		if((x < 5*eighth) && (z < 2*eighth)) return 33;
		if((x < 5*eighth) && (z < 3*eighth)) return 34;
		if((x < 5*eighth) && (z < 4*eighth)) return 35;
		if((x < 5*eighth) && (z < 5*eighth)) return 36;
		if((x < 5*eighth) && (z < 6*eighth)) return 37;
		if((x < 5*eighth) && (z < 7*eighth)) return 38;
		if((x < 5*eighth) && (z < 8*eighth)) return 39;
		if((x < 6*eighth) && (z < eighth)) return 40;
		if((x < 6*eighth) && (z < 2*eighth)) return 41;
		if((x < 6*eighth) && (z < 3*eighth)) return 42;
		if((x < 6*eighth) && (z < 4*eighth)) return 43;
		if((x < 6*eighth) && (z < 5*eighth)) return 44;
		if((x < 6*eighth) && (z < 6*eighth)) return 45;
		if((x < 6*eighth) && (z < 7*eighth)) return 46;
		if((x < 6*eighth) && (z < 8*eighth)) return 47;
		if((x < 7*eighth) && (z < eighth)) return 48;
		if((x < 7*eighth) && (z < 2*eighth)) return 49;
		if((x < 7*eighth) && (z < 3*eighth)) return 50;
		if((x < 7*eighth) && (z < 4*eighth)) return 51;
		if((x < 7*eighth) && (z < 5*eighth)) return 52;
		if((x < 7*eighth) && (z < 6*eighth)) return 53;
		if((x < 7*eighth) && (z < 7*eighth)) return 54;
		if((x < 7*eighth) && (z < 8*eighth)) return 55;
		if((x < 8*eighth) && (z < eighth)) return 56;
		if((x < 8*eighth) && (z < 2*eighth)) return 57;
		if((x < 8*eighth) && (z < 3*eighth)) return 58;
		if((x < 8*eighth) && (z < 4*eighth)) return 59;
		if((x < 8*eighth) && (z < 5*eighth)) return 60;
		if((x < 8*eighth) && (z < 6*eighth)) return 61;
		if((x < 8*eighth) && (z < 7*eighth)) return 62;
		if((x < 8*eighth) && (z < 8*eighth)) return 63;
		
		return 0;
	}
}
