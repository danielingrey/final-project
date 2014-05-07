using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string next = "next level";
		string controls = "Controls:\nMouse - Look around\nWSAD - movement\nSpace - Jump (hold to jump further)\nT - Teleport to " + next + "\nH - Begin Game/Display these instructions" +
			"\nEsc - Quit";
		if(Application.loadedLevel == 1) {
			guiText.text = "Game One\nLevel One\n\n" + controls;
		} else if(Application.loadedLevel == 2) {
			guiText.text = "Game One\nLevel Two\n\n" + controls;
		} else if(Application.loadedLevel == 3) {
			guiText.text = "Game Two\nLevel One\n\n" + controls;
		} else if(Application.loadedLevel == 4){
			next = "end of game";
			controls = "Controls:\nMouse - Look around\nWSAD - movement\nSpace - Jump (hold to jump further)\nT - Teleport to " + next + "\nH - Begin Game/Display these instructions" +
				"\nEsc - Quit";
			guiText.text = "Game Two\nLevel Two\n\n" + controls;
		} else if(Application.loadedLevel == 5) {
			guiText.text = "Thank you for playing.\n\nPress escape to exit.";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevel != 5) {
		   if(Input.GetKeyDown(KeyCode.H)) {
			guiText.enabled = !guiText.enabled;
			}		
		}
	}
}
