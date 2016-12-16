
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	


	public TowerUpgrader gameController;
	public GameObject warningPanel;
	public Text CurrentDiff;
	public Text HighScore;


	void Start ()
	{
		
		GameObject gameControllerObject = GameObject.FindWithTag ("TowerUpgrader");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <TowerUpgrader>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
		





	public void Update(){
		//Debug.Log (temp.ToString ());
		float temp = TowerUpgrader.GetDifficulty();

		if (temp == 1.5f) {
			CurrentDiff.text = "Current Difficulty: SuperEasy";
		}

		else if (temp == 1.2f) {
			CurrentDiff.text = "Current Difficulty: Easy";

		}

		else if (temp == 1.0f) {
			CurrentDiff.text = "Current Difficulty: Medium";

		}

		else if (temp == 0.8f) {
			CurrentDiff.text = "Current Difficulty: Hard";

		}

		else if (temp == 0.5f) {
			CurrentDiff.text = "Current Difficulty: Impossible";

		}
		else if (temp ==0.0f || temp == 0)
			CurrentDiff.text = "Current Difficulty: SuperEasy";
		else
			CurrentDiff.text = "Default Difficulty: SuperEasy";
			
		

		if(TowerUpgrader.GetHighScore() == 0)
			HighScore.text = "HighScore: 0"  ;
		else
			HighScore.text = "HighScore: " + TowerUpgrader.GetHighScore().ToString() ;
	
	}

	public void ButtonMenu(Button button)
	{

		if (button.name == "NewGame") {

			/*
			 //This is now all set in ghe warning.cs file. This is for the tutorial

			if(TowerUpgrader.GetDifficulty() ==0 || TowerUpgrader.GetDifficulty()==null)
			{
				TowerUpgrader.SetDifficulty(1.0f);
			}


			TowerUpgrader.SetLevel (1.0f);

			gameController.SetScore (0);

			//Due to extra cash at start of each level
			gameController.SetCash(0);

			// With no cash at start of each level
			//gameController.SetCash(0);

			TowerUpgrader.SetGunBulletDmg (1.0f);
			gameController.SetGunFR (0.5f);
			gameController.SetGunRange (10.0f);

			TowerUpgrader.SetMgBulletDmg (0.70f);
			gameController.SetMgFR (0.18f);
			gameController.SetMgRange (5.0f);


			TowerUpgrader.SetMortarDmg (2.0f);
			TowerUpgrader.SetExplosiveDmg (3.0f);
			gameController.SetMortarFR(2.5f);
			gameController.SetMortarRange(10.0f);


			TowerUpgrader.SetSlowDownBulletDmg (1.0f);
			gameController.SetSlowFR(2.0f);
			gameController.SetSlowRange(5.0f);


			TowerUpgrader.SetLazerDmg (4.0f);
			gameController.SetLazerFR(0.8f);
			gameController.SetLazerRange(5.0f);


			gameController.SetGunLevel (1);
			gameController.SetMgLevel (1);
			gameController.SetMortarLevel (1);
			gameController.SetSlowLevel (1);
			gameController.SetLazerLevel (1);

		

			//SceneManager.LoadScene ("tutorial");

		*/
			warningPanel.SetActive (true);

		}

		if (button.name == "Continue") {
			float temp = TowerUpgrader.GetLevel();

			if (temp <= 0 || temp <= 0.0f || TowerUpgrader.GetCash() < 0.0f || TowerUpgrader.GetScore()<0.0f) {
				if(TowerUpgrader.GetDifficulty() <=0 || TowerUpgrader.GetDifficulty() <=0.0f)
				{
					//Default super easy
					TowerUpgrader.SetDifficulty(1.5f);
				}


				TowerUpgrader.SetLevel (1.0f);

				gameController.SetScore (0);

				//Due to extra cash at start of each level
				gameController.SetCash(0);


				TowerUpgrader.SetGunBulletDmg (1.0f);
				gameController.SetGunFR (0.5f);
				gameController.SetGunRange (10.0f);

				TowerUpgrader.SetMgBulletDmg (0.70f);
				gameController.SetMgFR (0.18f);
				gameController.SetMgRange (5.0f);


				TowerUpgrader.SetMortarDmg (2.0f);
				TowerUpgrader.SetExplosiveDmg (3.0f);
				gameController.SetMortarFR(2.5f);
				gameController.SetMortarRange(10.0f);


				TowerUpgrader.SetSlowDownBulletDmg (1.0f);
				gameController.SetSlowFR(2.0f);
				gameController.SetSlowRange(5.0f);


				TowerUpgrader.SetLazerDmg (4.0f);
				gameController.SetLazerFR(0.8f);
				gameController.SetLazerRange(5.0f);


				gameController.SetGunLevel (1);
				gameController.SetMgLevel (1);
				gameController.SetMortarLevel (1);
				gameController.SetSlowLevel (1);
				gameController.SetLazerLevel (1);

				SceneManager.LoadScene ("level1");


			}
			else if(temp==1.0)
				SceneManager.LoadScene ("level1");
			else if(temp==2.0)
				SceneManager.LoadScene ("level2");
			else if(temp==3.0)
				SceneManager.LoadScene ("level3");
			else if(temp==4.0)
				SceneManager.LoadScene ("level4");
			else if(temp==5.0)
				SceneManager.LoadScene ("level5");
		
		}
		if (button.name == "Upgrades") {
			//print ("Upgrades");
			SceneManager.LoadScene ("Upgrades");
		}
		if (button.name == "Options") {
			SceneManager.LoadScene("Options");
		}
		if (button.name == "Exit") {
			print ("Exit");
			Application.Quit();
		}


	}
}