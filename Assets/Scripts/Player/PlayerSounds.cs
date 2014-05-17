using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {

	public AudioClip[] blasts = new AudioClip[3];
	public AudioClip thrust;
	public AudioClip release;
	bool replay = false;
	//float velocity = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//float endPlay = 0;
		CharacterController controller = transform.GetComponent<CharacterController>();
		Debug.Log (controller.velocity.y);
		if (Input.GetKeyDown("space") && controller.isGrounded) {
			int rand = Random.Range(0,3);
			audio.PlayOneShot(blasts[rand]);
			audio.loop = true;
			audio.clip = thrust;
			audio.PlayDelayed(blasts[rand].length);
			replay = true;
		}else if ((Input.GetKeyUp("space") && replay && !controller.isGrounded) || (controller.velocity.y < 0 && replay)) {
			audio.Stop();
			audio.loop = false;
			audio.PlayOneShot(release);
			replay = false;
		}
			
	}
}

