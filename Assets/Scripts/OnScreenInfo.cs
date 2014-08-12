using UnityEngine;
using System.Collections;

/// <summary>
/// Displays information on screen within a level.
/// </summary>
public class OnScreenInfo : MonoBehaviour {
	/// <summary>
	/// Controls to be displayed. Held in a string variable.
	/// </summary>
	string contrls = "\tH - Info/Controls\tT - Proceed to next level";

	/// <summary>
	/// Start this instance.
	/// </summary>
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
}
