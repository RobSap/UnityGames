using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Warning : MonoBehaviour {
	public TowerUpgrader gameController;
	public GameObject panel;

	public void startTutorial()
	{
		if(TowerUpgrader.GetDifficulty() ==0 || TowerUpgrader.GetDifficulty()==0.0f)
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


		SceneManager.LoadScene ("tutorial");
	}

	public void noNewGame()
	{
		panel.SetActive (false);
	}
}
