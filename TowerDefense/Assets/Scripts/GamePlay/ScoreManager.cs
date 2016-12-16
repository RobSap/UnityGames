using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {


		//Load previous score here
		public float initialScore = 0;
		public GameObject scoreDisplay;

		public static float score;

		// Use this for initialization
		void Start () 
		{

		score = TowerUpgrader.GetScore();
			}

		// Update is called once per frame
		void Update () {


		scoreDisplay.GetComponent<TextMesh> ().text = "Score: " + score.ToString ();
	}

}
