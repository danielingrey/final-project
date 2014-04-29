using UnityEngine;
using System.Collections;
using System;

public class InformationSheet : MonoBehaviour {

	public Texture2D infoSheet1;
	public Texture2D infoSheet2;
	public Texture2D infoSheet3;


	public Vector2 scrollPosition = Vector2.zero;
	public bool accept;
	public bool decline;
	public int dim;
	int height = Screen.height;
	int width = Screen.width;

	void OnGUI() {
		dim = 600; //dimension of textures
	
		GUI.BeginGroup (new Rect (width / 2 - 400, height / 2 - 400, 800, 800));
		// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
		
		// We'll make a box so you can see where the group is on-screen.
		GUI.Box (new Rect (0,0,800,800),"");


		scrollPosition = GUI.BeginScrollView(new Rect(0, 0, 800, 797), scrollPosition, new Rect(0, 3, 700, 2000),false,true);
		GUI.skin.button.fontSize = 30;
		accept = GUI.Button(new Rect(150, dim*3+20, 200, 100), "Accept");
		decline = GUI.Button(new Rect(450, dim*3+20, 200, 100), "Decline");
		GUI.Label(new Rect(100,10,dim,dim), infoSheet1);		
		GUI.Label(new Rect(100,dim,dim,dim), infoSheet2);
		GUI.Label(new Rect(100,dim*2-10,dim,dim), infoSheet3);


		GUI.EndScrollView();
		
		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
	}

	void Update() {
		if(accept) Application.LoadLevel("CaveCA");
		if(decline) Application.Quit();
	}

}
