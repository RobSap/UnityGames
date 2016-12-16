using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;


	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");


		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		
	
		//if (other.tag == "Boundary" || other.tag == "Enemy")
		if(other.CompareTag("Boundary") || other.CompareTag("Enemy")|| other.CompareTag("Bonus") || other.CompareTag("Bonus2"))
		{
			return;
		}


		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}
			
		if (other.tag == "Player")
		{
			//Want to instantiate our explosion
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver ();

			gameController.GameOver();
		}

		if (other.tag == "Missle") {
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject go in gos) {
				gameController.AddScore (scoreValue);
				Destroy (go);
			}
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				
		}



		gameController.AddScore(scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
