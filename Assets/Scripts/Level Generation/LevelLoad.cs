using UnityEngine;
using System.Collections;

/// <summary>
/// Level load.
/// </summary>
public class LevelLoad : MonoBehaviour {
	/// <summary>
	/// This variable holds the cube prefab. It is assigned from Unity's editor.
	/// </summary>
	public Transform cubePrefab;
	/// <summary>
	/// This variable holds the player prefab. It is assigned from Unity's editor.
	/// </summary>
	public Transform player;
	/// <summary>
	/// Texture used to animate teleportation between levels. It is assigned from Unity's editor.
	/// </summary>
	public GUITexture teleport;
	/// <summary>
	/// An instance of the CreateMesh class.
	/// </summary>
	CreateMesh myMesh;
	/// <summary>
	/// Boolean to check if a coroutine can be started.
	/// </summary>
	bool canCoRoutine = true;
	/// <summary>
	/// The next level to be loaded.
	/// </summary>
	int nextLevel;

	/// <summary>
	/// Setup the specified length, height, level array, next level and start on the y axis (y axis is different for exterior CA terrain levels) to begin level creation from 3D arrays.
	/// </summary>
	/// <param name="l">The length</param>
	/// <param name="h">The height.</param>
	/// <param name="lev">The level array.</param>
	/// <param name="nl">The next level to be loaded after this one.</param>
	/// <param name="sy">Where to start along the y axis within the 3D array.</param>
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
						//place cube in level based on array coordinates, multiply by 1.5 as cubes are size 1.5 not 1							
						Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, (y-startY)*1.5f, z*1.5f), Quaternion.identity) as Transform; 
						int m = myMesh.getMesh(x,z,y); //get mesh number based on position of cube
						//make cube child object of tagged mesh object that corresponds to its position by accessing meshTags string array
						cube.transform.parent = GameObject.FindGameObjectWithTag(myMesh.meshTags[m]).transform; //mesh objects already exist in scene and are tagged from "mesh1" to "mesh64"
					}	
				}
			}
			
		}
		Instantiate(player); //place player in scene
		audio.Play(); //play level's ambient background sound
	}

	/// <summary>
	/// Setup the specified length and next level. This overloaded method is used by the Perlin Noise terrain as it uses a specific 2D array.
	/// </summary>
	/// <param name="l">The length</param>
	/// <param name="nl">The next level to be loaded after this one.</param>
	public void setup(int l, int nl) {
		int length = l;
		nextLevel = nl;
		myMesh = new CreateMesh(length);
		for(int x = 0; x < length; x++) {				
			for( int z = 0; z < length; z++) {					
				Transform cube = Instantiate(cubePrefab, new Vector3(x*1.5f, StaticObjects.pnTerrain[x,z]*1.5f, z*1.5f), Quaternion.identity) as Transform;							
				int m = myMesh.getMesh(x,z); //uses overloaded getMesh function for 2D arrays						
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
