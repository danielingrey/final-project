using UnityEngine;
using System.Collections;
using System;

public class Texture3 : MonoBehaviour {
	
	static int width = 256;
	static int height = 256;
	int[,] cells = new int[width+1,height+1];
	int[,] chaoticRules = { {0,1,1,1,1,0,0,0}, {0,1,0,1,1,0,1,0}, {0,0,1,1,0,0,0,0}, {0,1,0,1,0,0,0,0} }; //rules 30, 90, 12, 10 respectively
	//int[,] chaoticRules = { {0,0,0,1,1,1,1,0}, {0,1,0,1,1,0,1,0}, {0,0,0,0,1,1,0,0}, {0,0,0,0,1,0,1,0} }; //rules 30, 90, 12, 10 respectively
	//int[,] complexRules = { {0,0,1,1,0,1,1,0}, {0,1,1,0,1,1,1,0}, {0,1,1,0,1,1,0,0}, {0,0,0,1,0,1,0,0} }; //rules 54, 110, 108, 20 respectively
	int[,] complexRules = { {0,1,1,0,1,1,0,0}, {0,1,1,1,0,1,1,0}, {0,0,1,1,0,1,1,0}, {0,0,1,0,1,0,0,0} }; //rules 54, 110, 108, 20 respectively
	int[] ruleset = new int[8];
	
	
	
	// Use this for initialization
	void Awake () {
		int rand = UnityEngine.Random.Range(0,4);
		for(int i = 0; i < 8; i++) {
				
				
				ruleset[i] = chaoticRules[0,i];
				
			}
		
		int[,] text = CA ();
		Texture2D texture = new Texture2D(width, height);
		renderer.material.mainTexture = texture;
		int y = 0;
		
		while (y < texture.height) {
			int x = 0;
			while (x < texture.width) {
				Color color;
				if(x !=0 || y!=0){
					if (text[y,x]==1) color = Color.black;
					else color = Color.white;
					texture.SetPixel(x, y, color);
				}
				++x;
			}
			++y;
		}
		
		/*while (y < texture.height) {
			int x = 0;
			while (x < texture.width) {
				Color color;
				if (((x & 1)==0) && ((y & 1)==0)) color = Color.white;
				else if (!((x & 1)==0) && !((y & 1)==0)) color = Color.white;
				else color = Color.black;
				texture.SetPixel(x, y, color);
				++x;
			}
			++y;
		}*/
		
		
		texture.filterMode = FilterMode.Trilinear;
		texture.Apply();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	int[,] CA() {

		for(int i = 0; i < width; i++) {
			int rand = UnityEngine.Random.Range(0,3);
			if( rand == 1) cells[0,i] = 1;
		}

		for(int gen =1; gen < width+1; gen++) {

			int[] nextgen = new int[width+1];
			for (int i = 1; i < height-1;i++) {
				int left = cells[gen-1,i-1];
				int me = cells[gen-1,i];
				int right = cells[gen-1,i+1];
				nextgen[i] = rules(left,me,right);
			}
			for(int i = 0; i < width-1;i++) {
				cells[gen,i]=nextgen[i];
			}
		}
		return cells;
	}
	
	
	int rules(int a, int b, int c) {
		string s = "" + a + b + c;

		int index = Convert.ToInt32(s,2);
		//print (index);
		return ruleset[index];
	}
}
