using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TutorialSpawner : MonoBehaviour {

	public GameObject[] pathPoints;
	public GameObject graphicalPathObject;

	public int waveCount;

	private int spawnIndex=0;
	private float waves;
	private int maxWaves;

	public GameObject[] spawnList; //List of enemies that spawn

	public float spawnTime; //time between enemies that spawn
	public float delayInitial;

	public TowerUpgrader gameController;
	//public EnergyManager energyManager;
	//public ScoreManager scoreManager;
	//public GameObject explosionBuilding;

	// Use this for initialization
	void Start () {



		GameObject gameControllerObject = GameObject.FindWithTag ("TowerUpgrader");


		//energyManager = energyManager.GetComponent <EnergyManager>();
		//scoreManager = scoreManager.GetComponent <ScoreManager>();


		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <TowerUpgrader>();
		}
		if (gameController == null)
		{

			//This can occure when not a bug too, which is ok.
			Debug.Log ("Cannot find 'GameController' script");
		}
		//	for (int i = 0; i < waves; i++) {
		//First spawn time is initial spawn time, and second one is eash spawn after
		InvokeRepeating ("Spawn", delayInitial, spawnTime);

		CreatGraphicalPathObjects ();
		//}

		//Initialize Waves
		waves = 1.0f;
		WaveManager.wave = waves;
		maxWaves = waveCount;
		//gameController.SetWave (waves);
	}


	IEnumerator Wait() {

		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}


	IEnumerator Wait2() {

		//Debug.Log ("Before 2");
		yield return new WaitForSeconds (3);

		//Debug.Log ("After 2");
		SceneManager.LoadScene ("Upgrades");
		//Debug.Log ("Failed Load");

	}
	// Update is called once per frame
	void Update () {

		//Check to see if level Ended (main base blown up)
		GameObject Building = GameObject.FindWithTag ("MainBuilding");
		GameObject Building2 = GameObject.FindWithTag ("MainBuilding2");

		if (Building == null || Building2 == null )
		{

			if (  TowerUpgrader.GetLevel()   == 5  || Building == null) {

				//Start the countdown to reload
				StartCoroutine (Wait ());

				//Possible reload display message.

				//If we want to destory enemies when level ends
				/*	GameObject[] enemiesDestory = GameObject.FindGameObjectsWithTag("Enemy");

			for (int i = 0; i < enemiesDestory.Length; i++) {
				Destroy (enemiesDestory [i]);
			}

*/
				//Blow up buildings when level ends




				GameObject[] buildingsDestory = GameObject.FindGameObjectsWithTag ("Building");
				for (int i = 0; i < buildingsDestory.Length; i++) {

					GameObject temp = buildingsDestory [i];

					BuildingHealth sn = temp.gameObject.GetComponent<BuildingHealth> ();

					if(sn!=null)
						sn.goDestroy();

					//Destroy (buildingsDestory [i]);

				}

			}


		}





		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		int enemiesLeft = enemies.Length;
		if (enemiesLeft == 0)
		{ //print ("Triggered");



			if (waveCount <= 0 && gameController != null)
			{


				FadeIn.ChangeToWin (1);
				FadeIn.BeginFade (1);

				//FadeIn.ChangeToWin (0);

				if (SceneManager.GetActiveScene().name == "level1") {

					gameController.SetScore (ScoreManager.score);
					gameController.SetCash(EnergyManager.energy );
					TowerUpgrader.SetLevel (2);
					StartCoroutine (Wait2 ());
					//SceneManager.LoadScene("Upgrades");

				} 
				else if (SceneManager.GetActiveScene().name ==  "level2") {

					gameController.SetScore (ScoreManager.score);
					gameController.SetCash(EnergyManager.energy  );
					TowerUpgrader.SetLevel (3);
					StartCoroutine (Wait2 ());

					//SceneManager.LoadScene("Upgrades");

				} 
				else if (SceneManager.GetActiveScene().name == "level3") {

					gameController.SetScore (ScoreManager.score);
					gameController.SetCash(EnergyManager.energy );
					TowerUpgrader.SetLevel (4);
					StartCoroutine (Wait2 ());

					//SceneManager.LoadScene("Upgrades");

				}
				else if (SceneManager.GetActiveScene().name == "level4") {

					gameController.SetScore (ScoreManager.score);
					gameController.SetCash(EnergyManager.energy  );
					TowerUpgrader.SetLevel (5);
					StartCoroutine (Wait2 ());
					//SceneManager.LoadScene("Upgrades");

				} 
				else if (SceneManager.GetActiveScene().name == "level5") {

					gameController.SetScore (ScoreManager.score);
					gameController.SetCash(EnergyManager.energy  );
					TowerUpgrader.SetLevel (1);
					StartCoroutine (Wait2 ());

					//SceneManager.LoadScene("Upgrades");

				}


			}

			// do something
		}
	}

	void Spawn()
	{


		//Spawn (instantiate) next enemy in spawnlist
		//Transform and quaterinan gives us an enemy where spawner is

		if (spawnIndex > spawnList.Length) {


			//			gameController2.displayText (waveCount);
			waveCount = waveCount - 1;

			waves = waves + 1.0f;
			//gameController.SetWave (waves);
			if (waves <= maxWaves) {
				WaveManager.wave = waves;
			}


			if (waveCount <= 0) {
				CancelInvoke ();
			} 
			else {
				spawnIndex = 0;
			}

		}
		GameObject reference = null;
		if (waveCount > 0 && spawnList [spawnIndex] !=null){
			reference = Instantiate (spawnList [spawnIndex], transform.position, Quaternion.identity) as GameObject;
		} 

		spawnIndex++;

		if (spawnIndex >= spawnList.Length) {
			//			gameController2.displayText (waveCount);

			waveCount = waveCount - 1;
			waves = waves + 1.0f;
			//gameController.SetWave (waves);

			if (waves <= maxWaves) {
				WaveManager.wave = waves;
			}


			if (waveCount <= 0) {
				CancelInvoke ();

			}
			else {
				spawnIndex = 0;
			}
			//CancelInvoke ();

		}


		//Set enemy path information
		if(reference!=null)
			reference.SendMessage ("SetPathPoints", pathPoints);

		//Add delay between waves here


	}

	void CreatGraphicalPathObjects ()
	{

		//Create object between transform.position and first waypoint
		Vector3 pathObjectPosition = ((pathPoints[0].transform.position - transform.position)*0.5f) + transform.position;
		Quaternion pathObjectOrientation = Quaternion.LookRotation(pathPoints[0].transform.position - transform.position);
		GameObject pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
		Vector3 newScale = Vector3.one;
		newScale.z = (pathPoints[0].transform.position - transform.position).magnitude;
		pathObject.transform.localScale = newScale;

		Vector2 newTextureScale = Vector2.one;
		newTextureScale.y = (pathPoints[0].transform.position - transform.position).magnitude;
		pathObject.GetComponent<Renderer>().material.mainTextureScale = newTextureScale;

		for(int i = 1; i < pathPoints.Length; i++)
		{
			pathObjectPosition = ((pathPoints[i].transform.position - pathPoints[i-1].transform.position)*0.5f) + pathPoints[i-1].transform.position;
			pathObjectOrientation = Quaternion.LookRotation(pathPoints[i].transform.position - pathPoints[i-1].transform.position);
			pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
			newScale = Vector3.one;
			newScale.z = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
			pathObject.transform.localScale = newScale;

			newTextureScale = Vector2.one;
			newTextureScale.y = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
			pathObject.GetComponent<Renderer>().material.mainTextureScale = newTextureScale;
		}

	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine (transform.position, pathPoints [0].transform.position);

		for (int i = 1; i < pathPoints.Length; i++) {

			Gizmos.DrawLine (pathPoints[i-1].transform.position, pathPoints[i].transform.position);

		}
	}
}
