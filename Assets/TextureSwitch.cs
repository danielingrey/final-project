using UnityEngine;
using System.Collections;

public class TextureSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.H)) {
			guiTexture.enabled = !guiTexture.enabled;
		}
	}
}
