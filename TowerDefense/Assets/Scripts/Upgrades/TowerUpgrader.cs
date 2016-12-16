using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TowerUpgrader : MonoBehaviour {


		public Text FireRate;
		public Text Dmg;
		public Text Range;
		public Text TowerSelected;
		//public GameObject[] TowerImage;
		public Text TowerLevel;
		public Text Cash;
		public Text UpgradeCost;
		public RawImage[] images;



		private int towerNum;

		// Use this for initialization
		void Start () {

		//GameObject go = (GameObject)Instantiate( images[1], Spawn.transform.position, Quaternion.identity );
		//go.transform.localScale += new Vector3(10.1F, 10.1F, 10.1F);

		towerNum = 1;

			TowerSelected.text = "";
			FireRate.text = "";
			Dmg.text = "";
			Range.text = "";
			Cash.text = "";
			UpgradeCost.text = "";
		}

	void SetToFalse()
	{
		int i;
		int temp = images.Length;
		for (i =0 ; i < temp; i++) {
			images [i].gameObject.SetActive (false);
		}
	}
		// Update is called once per frame
		void Update () {

		Cash.text = "Cash: " + GetCash ();

		if (towerNum == 1) {
			SetToFalse ();
			images [0].gameObject.SetActive (true);

			TowerSelected.text = "Cannon: Range";

			if (GetGunFR () > 0.1) {
				FireRate.text = "Fire Rate: " + GetGunFR () + "  -0.005";
			}
			else
				FireRate.text = "Fire Rate: " + GetGunFR () + "  -0.0";

			Dmg.text = "Damage: " + GetGunBulletDmg () + "  +0.5";
			Range.text = "Range: " + System.Math.Round(GetGunRange (),2) + "  +0.3";
			TowerLevel.text = "Tower Level: " + GetGunLevel () + "  +1";


			UpgradeCost.text = "Upgrade Cost: " + (100 * GetGunLevel ()).ToString();

			//	GameObject go = Instantiate( images[1], Spawn.transform.position, Spawn.transform.rotation );
			//	go.transform.parent = transform.parent;
			//Destroy( gameObject );

		} else if (towerNum == 2) {
			SetToFalse ();
			images [1].gameObject.SetActive (true);

			TowerSelected.text = "Mortar: Splash Damage";

			if (GetMortarFR () > 0.1) {
				FireRate.text = "Fire Rate: " + GetMortarFR () + "  -0.1";
			}
			else
				FireRate.text = "Fire Rate: " + GetMortarFR () + "  -0.0";
				
			Dmg.text = "Damage: " + GetMortarDmg () + "  +0.5";
			Range.text = "Range: " + System.Math.Round(GetMortarRange (),2)+ "  +0.2";
			TowerLevel.text = "Tower Level: " + GetMortarLevel ()+ "  +1";


			UpgradeCost.text = "Upgrade Cost: " + (100 * GetMortarLevel ()).ToString();
		} else if (towerNum == 3) {
			SetToFalse ();
			images [2].gameObject.SetActive (true);
			TowerSelected.text = "Slow: Slow Enemies";

			if (GetSlowFR () > 0.1) {
				FireRate.text = "Fire Rate: " + GetSlowFR () + "  -0.01";
			}
			else
				FireRate.text = "Fire Rate: " + GetSlowFR () + "  -0.0";
				
			Dmg.text = "Damage: " + GetSlowDownBulletDmg ()+ "  +0.25";
			Range.text = "Range: " + System.Math.Round(GetSlowRange (),2) + "  +0.2";
			TowerLevel.text = "Tower Level: " + GetSlowLevel () + "  +1";


			UpgradeCost.text = "Upgrade Cost: " + (100 * GetSlowLevel ()).ToString();
		} else if (towerNum == 4) {
			SetToFalse ();
			images [3].gameObject.SetActive (true);
			TowerSelected.text = "Machine Gun: Fire Fast";

			if (GetMgFR () > 0.04) {
				FireRate.text = "Fire Rate: " + GetMgFR () + "  -0.01";
			}
			else
				FireRate.text = "Fire Rate: " + GetMgFR () + "  -0.0";
				

			Dmg.text = "Damage: " + GetMgBulletDmg ()+ "  +0.15";

			Range.text = "Range: " + System.Math.Round(GetMgRange (),2)+ "  +0.1";
			TowerLevel.text = "Tower Level: " + GetMgLevel ()+ "  +1";


			UpgradeCost.text = "Upgrade Cost: " + (100 * GetMgLevel ()).ToString();
		} else if (towerNum == 5) {
			SetToFalse ();
			images [4].gameObject.SetActive (true);
			TowerSelected.text = "Lazer: Heavy Damage";

			if(GetLazerFR () >0.02)
			{
				FireRate.text = "Fire Rate: " + GetLazerFR ()+ "  -0.01";
			}
			else
				FireRate.text = "Fire Rate: " + GetLazerFR ()+ "  -0.00";
				

			Dmg.text = "Damage: " + GetLazerDmg ()+ "  +0.5";
			Range.text = "Range: " + System.Math.Round(GetLazerRange (),2)+ "  +0.1";
			TowerLevel.text = "Tower Level: " + GetLazerLevel ()+ "  +1" ;


			UpgradeCost.text = "Upgrade Cost: " + (100 * GetLazerLevel ()).ToString();

		} else {
			TowerSelected.text = "Error";
			FireRate.text = "Error";
			Dmg.text = "Error";
			Range.text = "Error";
		}
	}

	public void ButtonMenu(Button button)
	{
		if (button.name == "Tower1") {
			towerNum = 1;
		}
		if (button.name == "Tower2") {
			towerNum = 2;
		}
		if (button.name == "Tower3") {
			towerNum = 3;
		}
		if (button.name == "Tower4") {
			towerNum = 4;
		}
		if (button.name == "Tower5") {
			towerNum = 5;
		}
		if (button.name == "MainMenu") {
			SceneManager.LoadScene ("mainMenu");
		}

		if (button.name == "Continue") {
			float temp = TowerUpgrader.GetLevel();

			if(temp==1.0)
				SceneManager.LoadScene ("level1");
			else if(temp==2.0)
				SceneManager.LoadScene ("level2");
			else if(temp==3.0)
				SceneManager.LoadScene ("level3");
			else if(temp==4.0)
				SceneManager.LoadScene ("level4");
			else if(temp==5.0)
				SceneManager.LoadScene ("level5");
			else
				SceneManager.LoadScene ("mainMenu");
		}


		if (button.name == "Upgrade") {
			if (towerNum == 1) {

				if ((GetCash ()) >= 100 * GetGunLevel ()) {
					SetCash (GetCash () - (100 * GetGunLevel ()));
					SetGunLevel (GetGunLevel () + 1);
					SetGunBulletDmg (GetGunBulletDmg () + 0.5f);

					if(GetGunFR () > 0.1f)
						SetGunFR (GetGunFR () - 0.005f);

					SetGunRange (GetGunRange () + 0.3f);

				}
			}
			if (towerNum == 2) {
				if ((GetCash ()) >= 100 * GetMortarLevel ()) {
					SetCash (GetCash () - (100* GetMortarLevel ()));
					SetMortarLevel (GetMortarLevel () + 1);

					SetMortarDmg (GetMortarDmg () + 0.5f);

					SetExplosiveDmg (GetExplosiveDmg () + 0.5f);

					SetExplosiveDmg(GetExplosiveDmg() + 0.5f);

					if(GetMortarFR () > 0.1f)
						SetMortarFR (GetMortarFR () - 0.01f);
					
					SetMortarRange (GetMortarRange () + .2f);

				}
			}
			if (towerNum == 3) {
				if  ((GetCash ()) >= 100 * GetSlowLevel ()) {
					SetCash (GetCash () - (100 * GetSlowLevel ()));
					SetSlowLevel (GetSlowLevel () + 1);
					SetSlowDownBulletDmg (GetSlowDownBulletDmg () + 0.25f);

					if(GetSlowFR () >= 0.1f)
						SetSlowFR (GetSlowFR () - 0.01f);
					
					SetSlowRange (GetSlowRange () + 0.2f);

				}
			}
			if (towerNum == 4) {
				if  ((GetCash ())  >= 100 * GetMgLevel ()) {
					SetCash (GetCash () - (100 * GetMgLevel ()));
					SetMgLevel (GetMgLevel () + 1);

					SetMgBulletDmg (GetMgBulletDmg () + 0.15f);

					if(GetMgFR () > 0.04f)
						SetMgFR (GetMgFR () - 0.01f);

					SetMgRange (GetMgRange () + 0.1f);

				}
			}
			if (towerNum == 5) {
				if  ((GetCash ())  >= 100 * GetLazerLevel ()) {
					SetCash (GetCash () - (100 * GetLazerLevel ()));
					SetLazerLevel (GetLazerLevel () + 1);

					SetLazerDmg (GetLazerDmg () + 0.5f);

					if(GetLazerFR () > 0.02f)
						SetLazerFR (GetLazerFR () - 0.01f); //Keep the same
					
					SetLazerRange (GetLazerRange () + .1f);

				}
			}
		}
	}


	public static float GetHighScore()
	{
		return PlayerPrefs.GetFloat("highscore");
	}

	public static void SetHighScore()
	{
		if( GetHighScore() <GetScore())
			PlayerPrefs.SetFloat("highscore",  GetScore());
	}




	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat("Difficulty");
	}

	public static void SetDifficulty(float level)
	{
		PlayerPrefs.SetFloat("Difficulty",  level);
	}

	public static float GetLevel()
	{
		return PlayerPrefs.GetFloat("level");
	}

	public static void SetLevel(float level)
	{
		PlayerPrefs.SetFloat("level",  level);
	}



	public static float GetScore()
	{
		return PlayerPrefs.GetFloat("score");
	}
		
	public  void SetScore(float score)
	{
		PlayerPrefs.SetFloat("score",  score);
	}



	public static float GetCash()
	{
		return PlayerPrefs.GetFloat("cash");
	}

	public  void SetCash(float cash)
	{
		PlayerPrefs.SetFloat("cash",  cash);
	}


	// Bullet Damage Getters/Setters
	public static float GetGunBulletDmg(){
		return PlayerPrefs.GetFloat("gunBulletDmg");
	}
	public static float GetMgBulletDmg(){
		return PlayerPrefs.GetFloat("mgBulletDmg");
	}
	public static float GetMortarDmg(){
		return PlayerPrefs.GetFloat("mortarDmg");
	}
	public static float GetSlowDownBulletDmg(){
		return PlayerPrefs.GetFloat("slowDownBulletDmg");
	}
	public static float GetLazerDmg(){
		return PlayerPrefs.GetFloat("lazerDmg");
	}
	public static float GetExplosiveDmg(){
		return PlayerPrefs.GetFloat("exploDMG");
	}

	public static void SetGunBulletDmg(float gunBulletDmg){
		PlayerPrefs.SetFloat("gunBulletDmg",  gunBulletDmg);
	}
	public static void SetMgBulletDmg(float mgBulletDmg){
		PlayerPrefs.SetFloat("mgBulletDmg", mgBulletDmg);
	}
	public static void SetMortarDmg(float mortarDmg){
		PlayerPrefs.SetFloat("mortarDmg",  mortarDmg);
	}
	public static void SetSlowDownBulletDmg(float slowDownBulletDmg){
		PlayerPrefs.SetFloat("slowDownBulletDmg", slowDownBulletDmg);
	}
	public static void SetLazerDmg(float lazerDmg){
		PlayerPrefs.SetFloat("lazerDmg",lazerDmg);
	}
	public static void SetExplosiveDmg(float exploDMG){
		PlayerPrefs.SetFloat("exploDMG",exploDMG);
	}

	// Bullet Fire Rate Getters/Setters
	public float GetGunFR(){
		return PlayerPrefs.GetFloat("gunFR");
	}
	public float GetMgFR(){
		return PlayerPrefs.GetFloat("mgFR");
	}
	public float GetMortarFR(){
		return PlayerPrefs.GetFloat("mortarFR");
	}
	public  float GetSlowFR(){
		return PlayerPrefs.GetFloat("slowFR");
	}
	public float GetLazerFR(){
		return PlayerPrefs.GetFloat("lazerFR");
	}

	public void SetGunFR(float gunFR){
		PlayerPrefs.SetFloat("gunFR",  gunFR);
	}
	public void SetMgFR(float mgFR){
		PlayerPrefs.SetFloat("mgFR",  mgFR);
	}
	public void SetMortarFR(float mortarFR){
		PlayerPrefs.SetFloat("mortarFR",  mortarFR);
	}
	public void SetSlowFR(float slowFR){
		PlayerPrefs.SetFloat("slowFR",  slowFR);
	}
	public void SetLazerFR(float lazerFR){
		PlayerPrefs.SetFloat("lazerFR",lazerFR);
	}

	// Bullet Range Getters/Setters
	public float GetGunRange(){
		return PlayerPrefs.GetFloat("gunRange");
	}
	public float GetMgRange(){
		return PlayerPrefs.GetFloat("mgRange");
	}
	public float GetMortarRange(){
		return PlayerPrefs.GetFloat("mortarRange");
	}
	public float GetSlowRange(){
		return PlayerPrefs.GetFloat("slowRange");
	}
	public float GetLazerRange(){
		return PlayerPrefs.GetFloat("lazerRange");
	}

	public void SetGunRange(float gunRange){
		PlayerPrefs.SetFloat("gunRange",gunRange);
	}
	public void SetMgRange(float mgRange){
		PlayerPrefs.SetFloat("mgRange", mgRange);
	}
	public void SetMortarRange(float mortarRange){
		PlayerPrefs.SetFloat("mortarRange", mortarRange);
	}
	public void SetSlowRange(float slowRange){
		PlayerPrefs.SetFloat("slowRange", slowRange);
	}
	public void SetLazerRange(float lazerRange){
		PlayerPrefs.SetFloat("lazerRange",  lazerRange);
	}


	public int GetGunLevel(){
		return PlayerPrefs.GetInt ("gunLevel");
	}
	public int GetMgLevel(){
		return PlayerPrefs.GetInt ("mgLevel");
	}
	public int GetMortarLevel(){
		return PlayerPrefs.GetInt ("mortarLevel");
	}
	public int GetSlowLevel(){
		return PlayerPrefs.GetInt ("slowLevel");
	}
	public int GetLazerLevel(){
		return PlayerPrefs.GetInt ("lazerLevel");
	}


	public void SetGunLevel(int temp){
		PlayerPrefs.SetInt("gunLevel",temp);
	}
	public void SetMgLevel(int temp){
		PlayerPrefs.SetInt("mgLevel",temp);
	}
	public void SetMortarLevel(int temp){
		PlayerPrefs.SetInt("mortarLevel",temp);
	}
	public void SetSlowLevel(int temp){
		PlayerPrefs.SetInt("slowLevel",temp);
	}
	public void SetLazerLevel(int temp){
		PlayerPrefs.SetInt("lazerLevel",temp);
	}
}
