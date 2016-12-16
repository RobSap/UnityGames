using UnityEngine;
using System.Collections;

public class DestoryOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter(Collision collision)
	{
	//	print( "Collision");
		if (collision.collider.tag == "GunBullet") {
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "Bullet") {
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "LazerBullet") {
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "MachineGunBullet") {
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "SlowBullet") {
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "Mortar") {
			Destroy (collision.collider.gameObject);
		}
		else if (collision.collider.tag == "Enemy") {
			Destroy (collision.collider.gameObject);
		}

	}

	void OnTriggerEnter(){

		if (gameObject.name == "GunBullet") {
			Destroy (gameObject);
		}
		else if (gameObject.name == "Bullet") {
			Destroy (gameObject);
		}
		else if (gameObject.name == "LazerBullet") {
			Destroy (gameObject);
		}
		else if (gameObject.name == "MachineGunBullet") {
			Destroy (gameObject);
		}
		else if (gameObject.name == "SlowBullet") {
			Destroy (gameObject);
		}
		else if (gameObject.name == "Mortar") {
			Destroy (gameObject);
		}
		else if (gameObject.name == "Enemy") {
			Destroy (gameObject);
		}

	}

}
