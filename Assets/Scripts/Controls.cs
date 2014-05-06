using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = "Controls:\nWSAD - movement\nSpace - Jump (hold to jump further)\nT - Teleport to next level\nH - Display/Remove these instructions" +
			"\nEsc - Quit";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.H)) {
			guiText.enabled = !guiText.enabled;
		}
	}
}
