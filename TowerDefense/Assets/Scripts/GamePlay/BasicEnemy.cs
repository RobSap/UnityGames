using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {

	public float Health;
	public AudioClip expSound;
	public GameObject explosion;
	private float diff;



	// Use this for initialization
	void Start () {
		diff = TowerUpgrader.GetDifficulty () - 1.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Bullet") {
			Health = Health - TowerUpgrader.GetGunBulletDmg() - diff;
			Destroy (collision.collider.gameObject);

		}
		else if (collision.collider.tag == "GunBullet") {
			Health = Health - TowerUpgrader.GetGunBulletDmg()- diff;
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "Mortar") {
			Health = Health - TowerUpgrader.GetMortarDmg()- diff;
			//Don't destory the explosion
			Destroy (collision.collider.gameObject);
		}

		else if (collision.collider.tag == "LazerBullet") {
			Health = Health - TowerUpgrader.GetLazerDmg()- diff;
			Destroy (collision.collider.gameObject);
		}

		else if (collision.collider.tag == "MachineGunBullet") {
			Health = Health -TowerUpgrader.GetMgBulletDmg()- diff;
			Destroy (collision.collider.gameObject);
		}

		else if (collision.collider.tag == "SlowBullet") {
			Health = Health - TowerUpgrader.GetSlowDownBulletDmg() -diff;
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "ExplosiveDmg") {
			Health = Health - TowerUpgrader.GetExplosiveDmg()- diff;
			//Destroy (collision.collider.gameObject)();
		}



		if (Health <= 0) {
			GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
			//Instantiate(explosion);

			//Add sound for explosion
			AudioSource.PlayClipAtPoint(expSound, explosion.transform.position);
		
		
			Destroy (clone,2.0f);
			//Destroy (collision.collider.gameObject);
			Destroy (gameObject);
		}

	}
	void OnTriggerEnter(Collider other) {
			if (other.tag == "ExplosiveDmg") {
			Health = Health - TowerUpgrader.GetExplosiveDmg()- diff;
				//Destroy (collision.collider.gameObject)();
											}
		 
			if (Health <= 0) {

			if(explosion != null){
				GameObject clone = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
				//Instantiate(explosion);
				
				//Add sound for explosion
				AudioSource.PlayClipAtPoint(expSound, explosion.transform.position);


				Destroy (clone, 0.5f);
			}
				Destroy (gameObject);
			}
		}

	/*void OnDestroy()
	{
		GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
		Destroy (clone,2.0f);
	}*/

}
