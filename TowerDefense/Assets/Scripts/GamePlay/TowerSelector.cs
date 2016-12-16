using UnityEngine;
using System.Collections;

public class TowerSelector : MonoBehaviour {



	//Load previous score here
	//	public float initial = 0;
	public GameObject nameDisplay;
	public GameObject rangeDisplay;
	public GameObject fireRateDisplay;
	public GameObject damageDisplay;
	public GameObject costDisplay;


	public TowerUpgrader gameController;

	public GameObject[] towerIcones;
	public GameObject[] towers;
	public int[] towerCosts; 

	public float towerIconRotateRate = 1.0f;

	//only have 1 tower selected or in the game atm
	//Static means every instances shares this variable
	private int selectedTower = 0;

	// Use this for initialization
	void Start () {



		GameObject gameControllerObject = GameObject.FindWithTag ("TowerUpgrader");


		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <TowerUpgrader>();
		}
		if (gameController == null)
		{

			//This can occure when not a bug too, which is ok.
			Debug.Log ("Cannot find 'GameController' script");
		}

	}
	
	// Update is called once per frame
	void Update () {




		if (selectedTower == 0) {
			nameDisplay.GetComponent<TextMesh> ().text = "Cannon";
			rangeDisplay.GetComponent<TextMesh> ().text = "RG:" + System.Math.Round(gameController.GetGunRange(),2);
			fireRateDisplay.GetComponent<TextMesh> ().text = "FR:" + System.Math.Round(gameController.GetGunFR(),3);
			damageDisplay.GetComponent<TextMesh> ().text = "DMG:" + System.Math.Round(TowerUpgrader.GetGunBulletDmg(),2);
			costDisplay.GetComponent<TextMesh> ().text = "$" + GetSelectedTowerCost();
		} 
		else if (selectedTower == 1) {
			nameDisplay.GetComponent<TextMesh> ().text = "Mortar";
			rangeDisplay.GetComponent<TextMesh> ().text = "RG:" + System.Math.Round(gameController.GetMortarRange(),2);
			fireRateDisplay.GetComponent<TextMesh> ().text = "FR:" + System.Math.Round(gameController.GetMortarFR(),2);
			damageDisplay.GetComponent<TextMesh> ().text = "DMG:" + System.Math.Round(TowerUpgrader.GetMortarDmg(),2);
			costDisplay.GetComponent<TextMesh> ().text = "$" +GetSelectedTowerCost();
		} 
		else if (selectedTower == 2) {
			nameDisplay.GetComponent<TextMesh> ().text = "Slow";
			rangeDisplay.GetComponent<TextMesh> ().text = "RG:" + System.Math.Round(gameController.GetSlowRange(),2);
			fireRateDisplay.GetComponent<TextMesh> ().text = "FR:" + System.Math.Round(gameController.GetSlowFR(),2);
			damageDisplay.GetComponent<TextMesh> ().text = "DMG:" + System.Math.Round(TowerUpgrader.GetSlowDownBulletDmg(),2);
			costDisplay.GetComponent<TextMesh> ().text = "$" + GetSelectedTowerCost();
		}
		else if (selectedTower == 3) {
			nameDisplay.GetComponent<TextMesh> ().text = "MG";
			rangeDisplay.GetComponent<TextMesh> ().text = "RG: " + System.Math.Round(gameController.GetMgRange(),2);
			fireRateDisplay.GetComponent<TextMesh> ().text = "FR: " + System.Math.Round(gameController.GetMgFR(),2);
			damageDisplay.GetComponent<TextMesh> ().text = "DMG:" + System.Math.Round(TowerUpgrader.GetMgBulletDmg(),2);
			costDisplay.GetComponent<TextMesh> ().text = "$" + GetSelectedTowerCost();
		}
		else if (selectedTower == 4) {
			nameDisplay.GetComponent<TextMesh> ().text = "Lazer";
			rangeDisplay.GetComponent<TextMesh> ().text = "RG:" + System.Math.Round(gameController.GetLazerRange(),2);
			fireRateDisplay.GetComponent<TextMesh> ().text = "FR:" + System.Math.Round(gameController.GetLazerFR(),3);
			damageDisplay.GetComponent<TextMesh> ().text = "DMG:" + System.Math.Round(TowerUpgrader.GetLazerDmg(),2);
			costDisplay.GetComponent<TextMesh> ().text = "$" + GetSelectedTowerCost();
		}
	
		if (gameObject.tag != "DontRotate") {
		towerIcones [selectedTower].transform.Rotate (Vector3.up, towerIconRotateRate * Time.deltaTime);
		}
	}

	public GameObject GetSelectedTower()
	{
		//returns info of what tower we are gonna place
		return towers [selectedTower];
	}

	void SetSelectedTower(GameObject inputTower)
	{
		int index =0;
		foreach (GameObject towerIcon in towerIcones) {
			if (inputTower == towerIcon) {
				selectedTower = index;
			}
			index++;
				
		}
	}
	public int GetSelectedTowerCost()
	{
		return towerCosts [selectedTower];
	}


}
