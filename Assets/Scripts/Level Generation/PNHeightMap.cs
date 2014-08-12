using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Creates a heightmap using Perlin Noise for use as exterior terrain.
/// </summary>
public class PNHeightMap {
	/// <summary>
	/// The arr2D property represents the heightmap.
	/// </summary>
	/// <value></value>
	public int[,] arr2D {get;set;}
	/// <summary>
	/// The length and width of the heightmap.
	/// </summary>
	int length;

	/// <summary>
	/// Initializes a new instance of the <see cref="PNHeightMap"/> class.
	/// </summary>
	/// <param name="l">The length/width of the heightmap.</param>
	public PNHeightMap(int l) {
		length = l;
		arr2D = new int[l,l];
	}

	/// <summary>
	/// Creates the Perlin Noise heightmap.
	/// </summary>
	/// <param name="xo">X offset to be used with the noise function.</param>
	/// <param name="yo">Y offset to be used with the noise function.</param>
	public void perlHghtMap(float xo, float yo){
	float xoff = xo;
	float yoff = yo;
	float x = UnityEngine.Random.value; //start with a random seed value for the perlin noise	
	float y = x;
	float hm;
		for(int i = 0; i < length; i++){
			y = 0.0f;
			for(int j = 0; j < length; j++) {
				hm = map(Mathf.PerlinNoise(x,y),0f,1f,0f,13f); //maps the PerlinNoise function's range of 0 to 1 to 0 to 13
				arr2D[i,j] = Convert.ToInt32(Math.Floor(hm)); //converts the mapped value to an integer and floors the integer as a failsafe against gaps being created in the terrain
				y += yoff;
			}
			x += xoff;
		}

   }

	/// <summary>
	/// Map the specified value from its current range to a target range. Created based on the map function found in processing due to no similar function in C# or Unity libraries.
	/// </summary>
	/// <param name="val">The incoming value.</param>
	/// <param name="from1">Lower bound of value's current range.</param>
	/// <param name="to1">Upper bound of value's current range.</param>
	/// <param name="from2">Lower bound of target range.</param>
	/// <param name="to2">Upper bound of target range.</param>
	float map(float value, float start1, float stop1, float start2, float stop2) {		
		return (value - start1) / (stop1 - start1) * (stop2 - start2) + stop2;		
	}
}
