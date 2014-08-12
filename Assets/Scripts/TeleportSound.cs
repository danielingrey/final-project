using UnityEngine;
using System.Collections;

/// <summary>
/// Script to play the teleport sound when transitioning levels.
/// </summary>
public class TeleportSound : MonoBehaviour {
	/// <summary>
	/// The teleport sound.
	/// </summary>
	public AudioClip teleport;
		
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		if(Input.GetKeyDown(KeyCode.T)) { //play teleport sound if player presses 't' to transition between levels
			audio.PlayOneShot(teleport);
		}
	}
}
