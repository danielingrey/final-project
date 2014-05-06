using UnityEngine;
using System.Collections;

public class PlayerParticleEffect : MonoBehaviour {


	CharacterController controller;
	float curX;
	float curZ;
	bool start = false;

	// Use this for initialization


	IEnumerator Start () {
		print (start);
		curX = transform.parent.position.x;
		curZ = transform.parent.position.z;
		controller = transform.parent.GetComponent<CharacterController>();
		print (start);

		yield return new WaitForSeconds(1);

		start = true;
		print (start);
		particleSystem.enableEmission = false;
		particleSystem.Play();
		//CharacterMotor motorScript = transform.parent.GetComponent<CharacterMotor>();

	}

	// Update is called once per frame
	void Update () {
		if(start) {
			//float y = transform.position.y;
			float x = transform.parent.position.x;
			float z = transform.parent.position.z;
			//bool stop  = y > maxY;

			if (controller.isGrounded && x == curX && z == curZ) {
				particleSystem.enableEmission = false;
			} else {
				particleSystem.enableEmission = true;
			
			}

			/*else if (Input.GetKey("space") && controller.velocity.y > 0.0f) {
				//Debug.Log (controller.velocity.y);
				particleSystem.enableEmission = true;
			} else if (Input.GetKeyUp("space")) {
				particleSystem.enableEmission = false;
			} else {
				particleSystem.enableEmission = false;
			}*/
			curX = transform.parent.position.x;
			curZ = transform.parent.position.z;	
			print (particleSystem.enableEmission);
			print(transform.parent.position.x);
		}
	}
}
