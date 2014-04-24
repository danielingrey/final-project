using UnityEngine;
using System.Collections;
using System;


public class PNHeightMap {
	public int[,] arr2D {get;set;}
	int length;

	public PNHeightMap(int l) {
		length = l;
		arr2D = new int[l,l];
	}

	public void perlHghtMap(float xo, float yo){
	float xoff = xo;
	float yoff = yo;
	float x = 0.0f;
	float y = 0.0f;
	float hm;
		//Debug.Log ("this works");
		for(int i = 0; i < length; i++){
			//Debug.Log ("this works too" + i);
			y = 0.0f;
			for(int j = 0; j < length; j++) {
				hm = map(Mathf.PerlinNoise(x,y),0f,1f,0f,13f);
				arr2D[i,j] = Convert.ToInt32(Math.Floor(hm));
				//Debug.Log (arr2D[i,j]);
				y += yoff;
			}
			x += xoff;
		}

   }

	float map(float val, float from1, float to1, float from2, float to2) {
		
		return (val - from1) / (to1 - from1) * (to2 - from2) + from2;
		
	}
}
