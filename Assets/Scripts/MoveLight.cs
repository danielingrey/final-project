using UnityEngine;
using System.Collections;

/// <summary>
/// Controls background texture of title screen. The background image is a texture baked on to a spotlight source, this light source is moved from right to left for animation of the image. 
/// </summary>
public class MoveLight : MonoBehaviour {
	/// <summary>
	/// Countdown to be used as a timer between movement of the lightsource
	/// </summary>
	float countdown = 0.03f;
		
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		countdown -= Time.deltaTime; //Time.deltaTime is the time in seconds it took to complete the last frame
		if(countdown < 0.0f) {
			transform.Rotate(Vector3.up * 0.02f); //rotate light source from right to left in steps
			countdown = 0.03f; //reset countdown
		}
	}
}