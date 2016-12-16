using UnityEngine;
using System.Collections;

public class SlowBullet : MonoBehaviour {

	public float slowPercentage = 0.50f;
	public float slowTime;
	public GameObject restoreSpeedObject;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Enemy") {


			if (!collision.collider.GetComponentInChildren<RestoreSpeed> ()) {
				

				PathThroughObjects scriptInstance = collision.collider.GetComponent<PathThroughObjects> ();


				GameObject restoreSpeedInstance = Instantiate (restoreSpeedObject, collision.collider.transform.position, Quaternion.identity) as GameObject;

				restoreSpeedInstance.transform.parent = collision.collider.transform;

				RestoreSpeed scriptInstance2 = restoreSpeedInstance.GetComponent<RestoreSpeed> ();


				scriptInstance2.time = slowTime; 
				scriptInstance2.originalSpeed = scriptInstance.speed;

				scriptInstance.speed *= slowPercentage;
			} 


				



		}

	}
}
