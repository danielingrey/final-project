using UnityEngine;
using System.Collections;

public class StartGameTest : MonoBehaviour {
	string[] levels;
	// Use this for initialization
	void Start () {
		levels = new string[] {"CaveCA", "CaveAdHoc"};
		int rand = Random.Range(0,2);
		Application.LoadLevel(levels[rand]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
