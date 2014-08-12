using UnityEngine;
using System.Collections;

/// <summary>
/// Fade in from white when loading title screen. Uses a countdown to alter rendered ambient light/brightness down from pure white in steps.
/// </summary>
public class FadeIn : MonoBehaviour {
	/// <summary>
	/// Countdown to be used as a counter before a step is executed.
	/// </summary>
	float countdown = 2.0f;
	/// <summary>
	/// The ammount to alter brightness at each step.
	/// </summary>
	float ammount = 0.008f;
	/// <summary>
	/// Count to be used for number of steps.
	/// </summary>
	int count = 0;
	/// <summary>
	/// Color holds colour data in a 1D array of 0 to 2. 0 represents red value; 1 green; 2 blue
	/// </summary>
	public Color c;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {	
		for(int i = 0; i <3; i++){
			c[i] = 1f; //set each RGB of Color c to be 1 (255) i.e. red = 1 = 255, green = 1 = 255, blue = 1 = 255
		}

	}

	/// <summary>
	/// Update is run once a frame.
	/// </summary>
	void Update() {
		countdown -= Time.deltaTime; //Time.deltaTime is the time in seconds it took to complete the last frame
		if(countdown <= 0.0f && count < 250) { //maximum 250 steps down in brightness
			RenderSettings.ambientLight = c; //update rendered brightness 
			for(int i = 0; i <3; i++){
				c[i] -= ammount; //minus each RGB value by the same amount to alter brightness
			}
			count++;
			countdown = 0.08f; //change countdown to speed up rate of change of brightness
		}

	}
}
