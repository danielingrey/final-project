using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {

	public Transform cubePrefab;
	public Transform player;
	public GUITexture teleport;
	CreateMesh myMesh;
	bool canCoRoutine = true;
	int nextLevel;

	// Use this for initialization
	void Start () {
	
	}

	public void setup(int l, int h, int[,,] lev, int nl, int sy) {
		int length = l;
		int height = h;
		nextLevel = nl;
		int startY = sy;
		myMesh = new CreateMesh(length);
		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {
				for(int y = startY; y < height; y++) {
					if(lev[x,z,y]==1) {
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, (y-startY)*1.5f, z*1.5f), Quaternion.identity) as Transform;							
						int m = myMesh.getMesh(x,z,y);
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
					}	
				}
			}
			
		}
		Instantiate(player);
		audio.Play();
	}

	public void setup(int l, int nl) {
		int length = l;
		nextLevel = nl;
		myMesh = new CreateMesh(length);
		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {					
				Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, StaticObjects.pnTerrain[x,z]*1.5f, z*1.5f), Quaternion.identity) as Transform;							
				int m = myMesh.getMesh(x,z);						
				cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform;
			}	
		}
		Instantiate(player);
		audio.Play();
	}

	/// <summary>
	/// Update is run every frame. If "T" is pressed a coroutine is started to wait until the teleport sound has finished playing before transitioning to the next level.
	/// </summary>
	void Update () {
		if (Input.GetKeyDown(KeyCode.T) && canCoRoutine) {
			StartCoroutine(waitForSound());
		}
		if (!canCoRoutine) {
			Instantiate(teleport); //create 2D teleport texture on screen
			teleport.transform.localScale += new Vector3(0.01f, 0.01f, 0); //zoom in each frame on texture to create teleport animation on screen
		}
	}

	/// <summary>
	/// Waits for the length of the teleport sound before transitioning to the next level. Resets the teleport 2D texture to normal size.
	/// </summary>
	IEnumerator waitForSound() {
		canCoRoutine = false;
		
		yield return new WaitForSeconds(3.0f);
		
		Application.LoadLevel(nextLevel); // loads the next level/scene
		//Application.LoadLevel(4);
		teleport.transform.localScale = new Vector3(2, 2, 1);
	}
}
