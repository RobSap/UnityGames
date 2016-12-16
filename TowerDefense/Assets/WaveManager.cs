using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	//Load previous score here
	public float initialwave = 0;
	public GameObject waveDisplay;

	public static float wave;

	// Use this for initialization
	void Start () {
		wave = 1;

	}

	//Need to fix this call .. slows down the game
	// Update is called once per frame
	void Update () {
		waveDisplay.GetComponent<TextMesh> ().text = "Wave: " + wave;
	}
}
