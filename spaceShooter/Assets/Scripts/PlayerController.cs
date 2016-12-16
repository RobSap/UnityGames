using UnityEngine;
using System.Collections;



//Make a thing in unity to set the limit of each 
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {


	public float speed;
	public float tilt;
	private int bonus;

	public Boundary boundary;

	public GameObject shot;
	public GameObject shot2;
	public GameObject shot3;
	public GameObject shot4;


	//Unity can find and use it if you declare the type as transform
	public Transform shotSpawn; //This avoids shotspawn.transform.position
	public Transform shotSpawn2; //This avoids shotspawn.transform.position
	public Transform shotSpawn3; //This avoids shotspawn.transform.position
	public Transform shotSpawn4; //This avoids shotspawn.transform.position

	public float fireRate;
	public float fireRate2;

	private float nextFire;
	private float nextFire2;
	public int missleCount;

	private GameController gameController;





	void Start()
	{
		bonus = 0;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}


	}

	//Update goes before fixed update
	void Update ()
	{
		//Fire
		if ( ( Input.GetKey("space") || (Input.GetButton("Fire1") ) ) && Time.time > nextFire)
		{
			if (getBonus() < 1) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
			} else if (getBonus() == 1){
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				Instantiate (shot3, shotSpawn3.position, shotSpawn3.rotation);
				Instantiate (shot4, shotSpawn4.position, shotSpawn4.rotation);
				GetComponent<AudioSource> ().Play ();

			}
		}
		if ( ( Input.GetKey("b") ) && Time.time > nextFire2 && missleCount >0)
		{
			nextFire2 = Time.time + fireRate2;
			Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
			missleCount = missleCount - 1;

		
		}
	}


	//Fixed update is used to update physics
	//called automatically before each physics step
	void FixedUpdate()
	{
		//Get player movements from arrow keys
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//Allow player to control vector movement
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement*speed;
	
		//Movement limited on screen
		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		//To make the component tilt
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Bonus"))
		{
			
			gameController.AddScore(50);
			setWeapons ();
			other.gameObject.GetComponent<AudioSource>().Play ();
			other.gameObject.GetComponent<MeshRenderer>().enabled = false;
			yield return new WaitForSeconds (1);
			//other.gameObject.SetActive (false);
			//Destroy (other.gameObject);

		}
		else if (other.gameObject.CompareTag ("Bonus2")&& (other.gameObject.CompareTag ("Bonus2") !=null))
		{
			gameController.AddScore(50);
			missleCount = missleCount + 1;

			other.gameObject.GetComponent<AudioSource>().Play ();
			other.gameObject.GetComponent<MeshRenderer>().enabled = false;
			yield return new WaitForSeconds (1);
			//other.gameObject.SetActive (false);
			//Destroy (other.gameObject);



		}

	}

	public void setWeapons ()
	{
		bonus = 1;
	}

	public void unsetWeapons()
	{
		bonus = 0;
	}
	public int getBonus()
	{
		return bonus;
	}
}

