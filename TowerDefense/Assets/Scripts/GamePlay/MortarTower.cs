using UnityEngine;
using System.Collections;
using System.Linq;

public class MortarTower : MonoBehaviour {
	public GameObject endOfBarrel;
	private AudioSource shotSound;
	public GameObject smoke;
	private GameObject instantiatedObj;

	public GameObject bullet;
	public float fireRate; //How fast a tower fires
	public float fireRadius; //radius that tower detects and fires at enemy
	public float lobAmount = 10.0f;

	public float bulletSpeed = 1.0f;

	public float damage = 1.0f; // Damage

	private Vector3 movementDirection;

	public TowerUpgrader gameController;

	// Use this for initialization
	void Start ()
	{
		fireRate = gameController.GetMortarFR();
		fireRadius = gameController.GetMortarRange();
		shotSound = GetComponent<AudioSource> ();
		InvokeRepeating("SpawnBullet",fireRate,fireRate);
	}

	void Update()
	{
		
		foreach (Collider col in Physics.OverlapSphere (transform.position, fireRadius))
		{

				
			if (col.tag == "Enemy") {
				movementDirection = (col.transform.position - transform.position).normalized;
				transform.rotation = Quaternion.LookRotation(movementDirection);
	

				break;
			}

		}
	}


	void SpawnBullet()

	{


		GameObject target = null;
		//Loop for each enemy in area - 
		foreach (Collider col in Physics.OverlapSphere (transform.position, fireRadius))
		{
			if (col.tag == "Enemy") {
				//target = col.gameObject;
				target = GameObject.FindGameObjectsWithTag("Enemy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1);
				break;
			}
		}

		//This is used to shoot first object anywhere
		//GameObject target = GameObject.FindGameObjectWithTag("Enemy");

		if (target != null) {

			//Make the bullet
			GameObject newBullet = Instantiate (bullet, transform.position, bullet.transform.rotation) as GameObject;
		
			Vector3 distance = (target.transform.position-transform.position);                        
		
			Vector3 launchForce = new Vector3(distance.x * bulletSpeed, lobAmount, distance.z * bulletSpeed);                        
			newBullet.GetComponent<Rigidbody>().AddForce(launchForce, ForceMode.VelocityChange);
		
			shotSound.Play ();
			instantiatedObj= (GameObject) Instantiate(smoke, endOfBarrel.transform.position, endOfBarrel.transform.rotation);

			newBullet.transform.LookAt (target.transform.position);
			Destroy (instantiatedObj,2.0f);

		}
	}


}
