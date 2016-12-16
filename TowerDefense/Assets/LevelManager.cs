using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	//Load previous score here
	public float initialLevel = 0;
	public GameObject levelDisplay;

	public static float level;

	// Use this for initialization
	void Start () {

		level = TowerUpgrader.GetLevel();
	}

	// Update is called once per frame
	void Update () {
		levelDisplay.GetComponent<TextMesh> ().text = "Level: " + level.ToString ();
	}
}
