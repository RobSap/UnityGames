using UnityEngine;
using System.Collections;

public class MortarAI : MonoBehaviour {

	private AudioSource expSound;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		expSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		//When collide - might need to readjust 
		//Qu.idy -- means 000 all around


		GameObject clone = (GameObject)	Instantiate(explosion, transform.position, transform.rotation);
		//Instantiate(explosion);


		//Caused an Error
		expSound.Play ();
		Destroy(clone, 2.0f);

		//Destroy (explosion,2.0f);

	}



}











