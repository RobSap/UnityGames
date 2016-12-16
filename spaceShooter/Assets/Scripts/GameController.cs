using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//Need hazards and to be able to spawn in waves
	public GameObject[] hazards;
	public Vector3 spawnValues;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float roundWait;

	public GUIText scoreText;

	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText highScoreText;
	public GUIText missleText;

	public GUIText roundLevel;

	private bool gameOver;
	private bool restart;

	private int score;
	private int tempScore;
	private bool start;




	//Function to spawn waves each time
	//Unity calls start on very first frame the game object is enabled
	//and start will call spawn waves

	void Start ()
	{
		//Used to reset highscore
		//PlayerPrefs.SetInt("highscore", 0);
		GameObject thePlayer = GameObject.Find("Player");
		PlayerController playerScript = thePlayer.GetComponent<PlayerController>();


		start = true;
		gameOver = false;
		restart = false;
		highScoreText.text = "";
		highScoreText.text = "";
		restartText.text = "";
		gameOverText.text = "";
		roundLevel.text = "";
		StartCoroutine (SpawnWaves ());

		if (Application.loadedLevelName == "assignment3") {
			score = 0;
			playerScript.missleCount = 2;
		} 
		else if (Application.loadedLevelName == "assignment32") {
			score = PlayerPrefs.GetInt ("score");
			playerScript.missleCount = PlayerPrefs.GetInt("missles");
		} 
		else if (Application.loadedLevelName == "assignment33") {
			score = PlayerPrefs.GetInt ("score");
			playerScript.missleCount = PlayerPrefs.GetInt("missles");
		}

		missleText.text = "Missles: " + playerScript.missleCount;




		UpdateScore ();
	}

	void Update()
	{
		if (GameObject.Find ("Player") != null) {
			GameObject thePlayer = GameObject.Find ("Player");
			PlayerController playerScript = thePlayer.GetComponent<PlayerController> ();
			missleText.text = "Missles: " + playerScript.missleCount;
		}

		PlayerPrefs.Save (); 

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				if (Application.loadedLevelName == "assignment3") {
					Application.LoadLevel ("assignment3");
				} 
				else if (Application.loadedLevelName == "assignment32") {
					score = PlayerPrefs.GetInt ("score");
					gameOverText.text = "Reloading Level 2";
					Application.LoadLevel ("assignment32");

				} 
				else if (Application.loadedLevelName == "assignment33") {
					score = PlayerPrefs.GetInt ("score");
					gameOverText.text = "Reloading Level 3";
					Application.LoadLevel ("assignment33");
				}
			}	
		}
	}
	//Need a function to be called for most duration of game.
	IEnumerator SpawnWaves ()
	{
		GameObject thePlayer = GameObject.Find("Player");
		PlayerController playerScript = thePlayer.GetComponent<PlayerController>();


		int max;
		int min; 
		int max2;
		int min2; 
		if (Application.loadedLevelName == "assignment3") {
			
			 max = 2;
			 min = 0;
			max2 = 2;
			min2 = 0;

			
		} else if (Application.loadedLevelName == "assignment32" &&  (!gameOver)) {
			roundLevel.text = "Level 2, Round 1";
			yield return new WaitForSeconds (roundWait);
			roundLevel.text = "";
			max = 12;
			min = 0;
			max2 = 8;
			min2 = 6;

		} else  
			{
			if (!gameOver) {
				roundLevel.text = "Level 3, Round 1 ";
				yield return new WaitForSeconds (roundWait);
				roundLevel.text = "";
				}
			max = 15;
			min = 3;
			max2 = 15;
			min2 = 11;
			
			}

		if(tempScore == 0  && (Application.loadedLevelName == "assignment3") ){
			roundLevel.text = "Level 1, Round 1 ";
			highScoreText.text = "HighScore: " + PlayerPrefs.GetInt ("highscore");
			yield return new WaitForSeconds (startWait);
		}

		roundLevel.text = "";
		highScoreText.text = "";
		while (start)
		{ tempScore = tempScore + 1;
			for (int i = 0; i < hazardCount; i++)
			{
				

				//((hazards.Length)/temp)
				GameObject hazard = hazards [Random.Range (min, max+1)];
				GameObject hazard2 = hazards [Random.Range (min2, max2+1)];

				//Perameters of spawns
				//
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Vector3 spawnPosition2 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

				//Set z in game for spacific distance back, but don't set x, it needs to be random
				//So in game set x to 6 and note that  Spawn values gives a random range between these values

				Quaternion spawnRotation = Quaternion.identity;
			
				//Need to instantiate the hazards at a spawn position and with a rotation
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (waveWait);
				Instantiate (hazard2, spawnPosition2, spawnRotation);

				yield return new WaitForSeconds (spawnWait);

				if (gameOver)
				{
					restartText.text = "Press 'R' for" + " Restart";
					restart = true;
					break;
				}
			}

			//This waits before starting new wave
			//Wavewait is amount of time to wait for new wave
			yield return new WaitForSeconds (waveWait);




			//I have 6 astroids and 12 ships for a total of 18 .. 18/3 = 6

			if (tempScore == 6 ) 
			{
				if (!gameOver) {
					yield return new WaitForSeconds (startWait);
					determineLevel ();
				}
			}
			else if (tempScore == 3 )
			{
				if (Application.loadedLevelName == "assignment3" &&  (!gameOver)) {

					yield return new WaitForSeconds (waveWait);
					roundLevel.text = "Level 1, Round 2";
					max = 5;
					min = 0;
					max2 = 5;
					min2 = 3;
					playerScript.missleCount = playerScript.missleCount+1;
					yield return new WaitForSeconds (roundWait);
					roundLevel.text = "";
				}
				else if (Application.loadedLevelName == "assignment32" &&  (!gameOver) )
				{
					yield return new WaitForSeconds (waveWait);
					roundLevel.text = "Level 2, Round 2";
					playerScript.missleCount = playerScript.missleCount+1;
					yield return new WaitForSeconds (roundWait);
					roundLevel.text = "";
					max = 15;
					min = 3;
					max2 = 15;
					min2 = 11;

				}
				else if (Application.loadedLevelName == "assignment33" &&  (!gameOver))
				{
					yield return new WaitForSeconds (waveWait);
					roundLevel.text = "Level 3, Round 2";
					playerScript.missleCount = playerScript.missleCount+1;
					yield return new WaitForSeconds (roundWait);
					roundLevel.text = "";
					max = 21;
					min = 18;
					max2 = 21;
					min2 = 18;

				}

			}
		

				yield return new WaitForSeconds (waveWait);
			}


		}


	

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		if (!gameOver) {
			UpdateScore ();
		}
	}
		


	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;

	}

	public void GameOver()
	{
			gameOverText.text = "Game over!";
			gameOverText.GetComponent<AudioSource> ().Play ();;
			StoreHighScore (score);
			highScoreText.text = "HighScore: " + PlayerPrefs.GetInt ("highscore");
			gameOver = true;

	}

	void StoreHighScore(int highScore){
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(highScore > oldHighscore)
		{

			PlayerPrefs.SetInt("highscore", highScore);
			highScore = score;
			PlayerPrefs.Save(); 

			//highScoreText.text = "HighScore: " + PlayerPrefs.GetInt ("highscore");
			//yield return new WaitForSeconds (waveWait);
			//highScoreText.text = "";

		}
	}


		
	IEnumerator LoadAfterDelay(string levelName){
		yield return new WaitForSeconds (startWait); // wait 1 seconds
		PlayerPrefs.SetInt("score", score);
		PlayerPrefs.Save(); 
		Application.LoadLevel (levelName);
	}

	void determineLevel()
	{
		GameObject thePlayer = GameObject.Find("Player");
		PlayerController playerScript = thePlayer.GetComponent<PlayerController>();

		start = false;
		if (Application.loadedLevelName == "assignment3") {
			gameOverText.text = "Loading Level 2";
			PlayerPrefs.SetInt("missles", playerScript.missleCount);
			PlayerPrefs.Save(); 
			StartCoroutine (LoadAfterDelay ("assignment32"));
		} 
		else if (Application.loadedLevelName == "assignment32")
		{
			gameOverText.text = "Loading Level 3";
			PlayerPrefs.SetInt("missles", playerScript.missleCount);
			PlayerPrefs.Save(); 
			StartCoroutine (LoadAfterDelay ("assignment33"));

		} 
		else if (Application.loadedLevelName == "assignment33") {
			gameOverText.text = "!!!! You Won !!!!";
			StoreHighScore (score);
			StartCoroutine (LoadAfterDelay ("assignment3"));

		}
			
	}
}