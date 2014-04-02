using UnityEngine;
using System.Collections;
using System;

public class MapTexture : MonoBehaviour {


	/*public GameObject strtUpObj;
	public StartUp startScript;

	// Use this for initialization
	void Start () {

		startScript = GameObject.Find("StartUpObject").GetComponent<StartUp>();
		Texture2D mapTexture = new Texture2D(startScript.length,startScript.length);
		renderer.material.mainTexture = mapTexture;
		for(int i = 0; i < startScript.length; i++) {
			for(int j = 0; j < startScript.length; j++) {
				Color colour;
			
				if(startScript.mapArray[i,j] == 1) {
					colour = Color.black;
					mapTexture.SetPixel(i,j,colour);
				} else if(startScript.mapArray[i,j] == 0) {
					colour = Color.white;
					mapTexture.SetPixel(i,j,colour);
				}

			}
		}
		mapTexture.filterMode = FilterMode.Point;
		mapTexture.Apply();
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
