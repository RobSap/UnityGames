using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {



	public GameObject shot;
	public GameObject shot2;
	public Transform shotSpawn;
	public Transform missleSpawn;
	public float fireRate;
	public float delay;
	public GameObject shot3;
	public GameObject shot4;
	public Transform shotSpawn3;
	public Transform shotSpawn4;


	private AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play ();
	}

}


