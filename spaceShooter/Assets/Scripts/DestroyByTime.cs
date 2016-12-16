using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	public float lifetime;
	public GameObject playerExplosion;
	private DestoryByContact contact;

	private GameController gameController;

	IEnumerator Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}


		if (gameObject.CompareTag ("Missle")) {
		
			yield return new WaitForSeconds (lifetime);
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject go in gos) {
				
				gameController.AddScore (10);
				//gameController.AddScore (scoreValue);
				Destroy (go);
			}	
			Instantiate (playerExplosion, transform.position, transform.rotation);
			//Instantiate(playerExplosion, transform.position, transform.rotation);
			Destroy (gameObject);

		} else {
			Destroy (gameObject, lifetime);
		}
	
	}
}

