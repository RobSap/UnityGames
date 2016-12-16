using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {


	public float speed;				
	public Text countText;			
	public Text winText;
	public Text nextLevel;


	private Rigidbody2D rb2d;		
	private int count;
	public ParticleSystem emitter;
	public ParticleSystem emitter2;

	private int counter;



	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();

		count = 0;
		counter = 0;
		winText.text = "";
		nextLevel.text = "";
		SetCountText ();

		countText.GetComponent<AudioSource> ().Play ();

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit();

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			if(count < 12)
			{
				count = count + 1;
				SetCountText ();
			}
			

			//GetComponent<AudioSource>().Play ();
			ParticleSystem newSystem = Instantiate (emitter, other.gameObject.transform.position, Quaternion.identity) as ParticleSystem; 
			newSystem.Play (); //Start object

			//Audio for the type of particles the object has
			newSystem.GetComponent<AudioSource> ().Play ();
			//Destorys the object based on thet its told to exist
			Destroy (newSystem.gameObject, newSystem.duration);

		} else if (other.gameObject.CompareTag ("BadPickUp")) {
			other.gameObject.SetActive (false);
			count = count - 1;
			counter = counter + 1;
			SetCountText ();

			if (counter >= 2) {
				winText.text = "You Lost!";
				countText.GetComponent<AudioSource> ().Stop ();
				nextLevel.text = "Reloading Level";
				counter = -10;
				count = 0;
				determineLevel2 ();

			}


			//GetComponent<AudioSource>().Play ();
			ParticleSystem newSystem2 = Instantiate (emitter2, other.gameObject.transform.position, Quaternion.identity) as ParticleSystem; 
			newSystem2.Play (); //Start object

			//Audio for the type of particles the object has
			newSystem2.GetComponent<AudioSource> ().Play ();
			//Destorys the object based on thet its told to exist
			Destroy (newSystem2.gameObject, newSystem2.duration);

		}

		/*if (other.gameObject.CompareTag ("Bumper")) {
			
			GetComponent<AudioSource> ().Play ();
		}*/
	}

	void OnCollisionEnter2D(Collision2D coll) {
			if (coll.gameObject.CompareTag ("Bumper")) {

			coll.gameObject.GetComponent<AudioSource> ().Play ();
			}
		}




	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			
			if (counter >= 2) {
				winText.text = "You Lost!";
				countText.GetComponent<AudioSource> ().Stop ();
				nextLevel.text = "Reloading Level";
				counter = -10;
				count = 0;
				determineLevel2 ();

			}
			winText.text = "You win!";
			counter = -20;
			determineLevel ();

		}
		

	}



	IEnumerator LoadAfterDelay(string levelName){
		yield return new WaitForSeconds (7); // wait 1 seconds
		Application.LoadLevel (levelName);
	}

	void determineLevel()
	{
		if (Application.loadedLevelName == "assignment2" ) {
			nextLevel.text = "Loading Level 2, enabled negative points";
			StartCoroutine(LoadAfterDelay("assignment22"));
		}
		else if (Application.loadedLevelName == "assignment22" )
		{
			nextLevel.text = "Loading Level 3, enabled boucing";
			StartCoroutine(LoadAfterDelay("assignment23"));

		}
		else if (Application.loadedLevelName == "assignment23" ) {
			nextLevel.text = "Loading Level 4, increased difficulty";
			StartCoroutine(LoadAfterDelay("assignment24"));
		}
		else if (Application.loadedLevelName == "assignment24" )
		{
			nextLevel.text = "Loading Final Zone, increased difficulty";
			StartCoroutine(LoadAfterDelay("assignment25"));

		}
		else if (Application.loadedLevelName == "assignment25" )
		{
			nextLevel.text = "You Win the game! Starting over...";
			StartCoroutine(LoadAfterDelay("assignment2"));

		}
			
		countText.GetComponent<AudioSource> ().Stop ();
		winText.GetComponent<AudioSource> ().Play ();

	}

	void determineLevel2()
	{
		if (Application.loadedLevelName == "assignment2" ) {
			nextLevel.text = "Reloading Level 1";
			StartCoroutine(LoadAfterDelay("assignment2"));
		}
		else if (Application.loadedLevelName == "assignment22" )
		{
			nextLevel.text = "Reloading Level 2";
			StartCoroutine(LoadAfterDelay("assignment22"));

		}
		else if (Application.loadedLevelName == "assignment23" ) {
			nextLevel.text = "Reloading Level 3";
			StartCoroutine(LoadAfterDelay("assignment23"));
		}
		else if (Application.loadedLevelName == "assignment24" )
		{
			nextLevel.text = "Reloading Level 4";
			StartCoroutine(LoadAfterDelay("assignment24"));

		}
		else if (Application.loadedLevelName == "assignment25" )
		{
			nextLevel.text = "Reloading Level 5";
			StartCoroutine(LoadAfterDelay("assignment25"));

		}

	}



}
