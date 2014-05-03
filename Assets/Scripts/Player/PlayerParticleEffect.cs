using UnityEngine;
using System.Collections;

public class PlayerParticleEffect : MonoBehaviour {

	float maxY;

	// Use this for initialization
	void Start () {
		particleSystem.enableEmission = false;
		CharacterMotor motorScript = transform.parent.GetComponent<CharacterMotor>();
	}

	// Update is called once per frame
	void Update () {
		float y = transform.position.y;
		//bool stop  = y > maxY;
		CharacterController controller = transform.parent.GetComponent<CharacterController>();
		if (controller.isGrounded) {
			particleSystem.enableEmission = false;
		} else if (Input.GetKey("space") && controller.velocity.y > 0.0f) {
			//Debug.Log (controller.velocity.y);
			particleSystem.enableEmission = true;
		} else if (Input.GetKeyUp("space")) {
			particleSystem.enableEmission = false;
		} else {
			particleSystem.enableEmission = false;
		}
			
	}
}
