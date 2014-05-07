using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	float countdown = 2.0f;
	float ammount = 0.008f;
	int count = 0;
	public Color c;

	// Use this for initialization
	void Start () {	
		for(int i = 0; i <3; i++){
			c[i] = 1f;
		}

	}

	void Update() {
		countdown -= Time.deltaTime;
		if(countdown <= 0.0f && count < 250) {
			RenderSettings.ambientLight = c;
			for(int i = 0; i <3; i++){
				c[i] -= ammount;
			}
			count++;
			countdown = 0.08f;
		}

	}
}
