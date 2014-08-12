using UnityEngine;
using System.Collections;

/// <summary>
/// Accepts input to quit the game and also hides the mouse cursor from the player.
/// </summary>
public class Quit : MonoBehaviour {

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		Screen.showCursor = false;
	}
	
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
