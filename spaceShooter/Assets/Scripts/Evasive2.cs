using UnityEngine;
using System.Collections;

public class Evasive2 : MonoBehaviour {

	public float dodge;
	public float smoothing;
	public float tilt;
	private int turnRate;


	//Doing a range to randomize
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	public Boundary boundary;

	private float currentSpeed;
	private float targetManeuver;


	private Rigidbody rb;

	void Start ()
	{
		turnRate = Random.Range (0, 10);
		rb = GetComponent <Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade ());
	}

	IEnumerator Evade()
	{
		//This is our random range
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

		while (true)
		{
			//Ships evade player
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			}

			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate ()
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
			rb.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
			rb.position = new Vector3 (
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);

			transform.Rotate (Vector3.up * turnRate, Space.World);
		}
	}
}
