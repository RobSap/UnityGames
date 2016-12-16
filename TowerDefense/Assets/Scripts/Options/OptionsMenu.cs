using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	public GameObject options;
	public Text diff;

	void Start () {
		diff.text = " ";
	
	}

	void Update()
	{
		
		float temp = TowerUpgrader.GetDifficulty();


		//Debug.Log (temp.ToString ());

		if (temp == 1.5f) {
			diff.text = "Current Difficulty: SuperEasy";
		}

		else if (temp == 1.2f) {
			diff.text = "Current Difficulty: Easy";

		}

		else if (temp == 1.0f) {
			diff.text = "Current Difficulty: Medium";

		}

		else if (temp == 0.8f) {
			diff.text = "Current Difficulty: Hard";

		}

		else if (temp == 0.5f) {
			diff.text = "Current Difficulty: Impossible";

		}
		else
			diff.text = "Error";
		
	}
	public void ButtonMenu(Button button)
	{
		/*
		if (button.name == "Apply") {
			print ("Apply");


			SceneManager.LoadScene("MainMenu");
		}

		*/
		if (button.name == "MainMenu") {
//			print ("Main");
			SceneManager.LoadScene ("MainMenu");
		}

		if (button.name == "SuperEasy") {
			TowerUpgrader.SetDifficulty (1.5f);
		}

		if (button.name == "Easy") {
			TowerUpgrader.SetDifficulty (1.2f);
		}

		if (button.name == "Med") {
			
			TowerUpgrader.SetDifficulty (1.0f);
		}

		if (button.name == "Hard") {
			TowerUpgrader.SetDifficulty (0.8f);
		}

		if (button.name == "SuperHard") {
			TowerUpgrader.SetDifficulty (0.5f);
		}
	}

}