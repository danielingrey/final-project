using UnityEngine;
using System.Collections;

public class TextBehaviour : MonoBehaviour {

	float countdown = 13.0f;
	int title = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if(countdown < 0.0f && title == 1) {
			guiText.text = "A study in procededural\ngeneration by Daniel Ingrey";
			countdown = 4.0f;
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
