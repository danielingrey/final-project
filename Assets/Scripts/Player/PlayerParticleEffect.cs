using UnityEngine;
using System.Collections;

/// <summary>
/// Player particle effect. Controls trail behaviour.
/// </summary>
public class PlayerParticleEffect : MonoBehaviour {

	/// <summary>
	/// The controller.
	/// </summary>
	CharacterController controller;
	/// <summary>
	/// For holding the player's current position along the x axis
	/// </summary>
	float curX;
	/// <summary>
	/// For holding the player's current position along the z axis.
	/// </summary>
	float curZ;
	bool start = false;

	/// <summary>
	/// Start this instance. Waits 1 second before allowing particles to be emitted while the player is being placed by the system to avoid trail bugs.
	/// </summary>
	IEnumerator Start () {

		curX = transform.parent.position.x;
		curZ = transform.parent.position.z;
		controller = transform.parent.GetComponent<CharacterController>();

		yield return new WaitForSeconds(1);

		start = true;
		particleSystem.enableEmission = false;
		particleSystem.Play();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		if(start) {
			float x = transform.parent.position.x; //get player's x coordinate
			float z = transform.parent.position.z; //get player's z coordinate

			if (controller.isGrounded && x == curX && z == curZ) { //stop emitting particles if the player is on the ground and not moving
				particleSystem.enableEmission = false;
			} else {
				particleSystem.enableEmission = true;
			
			}

			//update the player's current position variables
			curX = transform.parent.position.x; 
			curZ = transform.parent.position.z;	
		}
	}
}
