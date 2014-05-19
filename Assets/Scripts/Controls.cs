using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string next = "next level";
		string controls = "<size=27>Notes/Reminder before you begin:</size>" +
			"\n- There are no typical game-like goals in this interactive environment" +
			"\nother than the exploration of each section (level), and progression to the next" +
			"\n- The interactive environment is split in to two games, <i>Game One</i> and <i>Game Two</i>" +
				"\n- Each game contains two levels, an exterior, <i>Level One</i>, and an interior, <i>Level Two</i>" +
			"\n- Take as much time as you would like in each level to explore and examine" +
			"\nthe aesthetics and structure of your surroundings" +
			"\n\n<size=27>Controls:</size>" +
			"\nMouse - Look around" +
			"\nW - Move forwards" +
			"\nS - Move backwards" +
			"\nA - Move left" +
			"\nD - Move right" +
			"\nSpace - Jump (hold to jump further)\n" +
			"T - Teleport to " + next + "" +
			"\nH - Begin playing/Display these instructions";
		if(Application.loadedLevel == 1) {
			guiText.text = "<size=29><i>Game One\nLevel One</i></size>\n\n" + controls;
		} else if(Application.loadedLevel == 2) {
			guiText.text = "<size=29><i>Game One\nLevel Two</i></size>\n\n" + controls;
		} else if(Application.loadedLevel == 3) {
			guiText.text = "<size=29><i>Game Two\nLevel One</i></size>\n\n" + controls;
		} else if(Application.loadedLevel == 4){
			next = "end of game";
			//controls = "<size=27>Controls:</size>\n\nMouse - Look around\nWSAD - movement\nSpace - Jump (hold to jump further)\nT - Teleport to " + next + "\nH - Begin playing/Display these instructions";
			controls = "<size=27>Notes/Reminder before you begin:</size>" +
				"\n- There are no typical game-like goals in this interactive environment" +
					"\nother than the exploration of each section (level), and progression to the next" +
					"\n- The interactive environment is split in to two games, <i>Game One</i> and <i>Game Two</i>" +
					"\n- Each game contains two levels, an exterior, <i>Level One</i>, and an interior, <i>Level Two</i>" +
					"\n- Take as much time as you would like in each level to explore and examine" +
					"\nthe aesthetics and structure of your surroundings" +
					"\n\n<size=27>Controls:</size>" +
					"\nMouse - Look around" +
					"\nW - Move forwards" +
					"\nS - Move backwards" +
					"\nA - Move left" +
					"\nD - Move right" +
					"\nSpace - Jump (hold to jump further)\n" +
					"T - Teleport to " + next + "" +
					"\nH - Begin playing/Display these instructions";		
			//"\nEsc - Quit";

			guiText.text = "<size=29><i>Game Two\nLevel Two</i></size>\n\n" + controls;
		} else if(Application.loadedLevelName == "EndOfGame") {
			//guiText.text = "Thank you for playing.\n\nPress escape to exit.";
			guiText.text = "Thank you for playing\n\nClick next to proceed to questionnaire";
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
