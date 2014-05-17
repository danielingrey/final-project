using UnityEngine;
using System.Collections;

public class OnScreenInfo : MonoBehaviour {
	string contrls = "\tH - Info/Controls\tT - Proceed to next level";
	// Use this for initialization
	void Start () {
		if(Application.loadedLevel == 1) {
			guiText.text = "<i>Game One: Level One</i>" + contrls;
		} else if(Application.loadedLevel == 2) {
			guiText.text = "<i>Game One: Level Two</i>" + contrls;
		} else if(Application.loadedLevel == 3) {
			guiText.text = "<i>Game Two: Level One</i>" + contrls;
		} else if(Application.loadedLevel == 4){
			guiText.text = "<i>Game Two: Level Two</i>\tH - Info/Controls\tT - Proceed to end";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
