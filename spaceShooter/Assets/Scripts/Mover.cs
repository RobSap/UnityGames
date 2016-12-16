using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {


	//Want lazer to have onwn velocity

	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;

		//GetComponent<Rigidbody>().AddForce(transform.forward * speed);
	}

}
