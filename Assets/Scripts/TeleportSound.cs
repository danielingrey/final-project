using UnityEngine;
using System.Collections;

public class TeleportSound : MonoBehaviour {

	public AudioClip teleport;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T)) {
			audio.PlayOneShot(teleport);
		}
	}
}
