using UnityEngine;
using System.Collections;

public class MoveLight : MonoBehaviour {
	float countdown = 0.03f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if(countdown < 0.0f) {
			transform.Rotate(Vector3.up * 0.02f);
			countdown = 0.03f;
		}
	}
}