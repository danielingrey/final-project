using UnityEngine;
using System.Collections;

/// <summary>
/// Displays or removes the texture behind the information/controls display for player within a level.
/// </summary>
public class TextureSwitch : MonoBehaviour {

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		if(Input.GetKeyDown(KeyCode.H)) {
			guiTexture.enabled = !guiTexture.enabled;
		}
	}
}
