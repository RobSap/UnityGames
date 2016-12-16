using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;

	//Private start location 
	private Vector3 startPosition;

	void Start () 
	{
		//Start it at our transform at start
		startPosition = transform.position;
	}

	void Update ()
	{
		//Mathf.reapeat repeats thebackground
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		//Sets the position - with some type of start position and move forward
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}
