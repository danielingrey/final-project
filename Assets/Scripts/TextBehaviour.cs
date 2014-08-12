using UnityEngine;
using System.Collections;

/// <summary>
/// Text behaviour for the title screen.
/// </summary>
public class TextBehaviour : MonoBehaviour {
	/// <summary>
	/// The countdown between credits.
	/// </summary>
	float countdown = 13.0f;
	/// <summary>
	/// This number corresponds to the credit to display.
	/// </summary>
	int title = 1;

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		countdown -= Time.deltaTime; //Time.deltaTime is the time in seconds it took to complete the last frame

		if(countdown < 0.0f && title == 1) {
			guiText.text = "A study in procededural\ngeneration by Daniel Ingrey";
			countdown = 4.0f; //update countdown for time between credits
			title = 2;
		} else if(countdown < 0.0f && title == 2) {
			guiText.text = "Sound by Nathan Gallardo";
			countdown = 4.0f;
			title = 3;
		} else if(countdown < 0.0f && title == 3) {
			guiText.text = "Press Any Key To Begin";
		}
	}
}
