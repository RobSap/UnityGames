using UnityEngine;
using System.Collections;

public class PathThroughObjects : MonoBehaviour
{
	public GameObject[] pathPoints;
	public float speed = 1.0f;
	//public float goalSize = 0.1f;


	public GameObject graphicalPathObject;
	
	private int currentPathIndex = 0;
	private Vector3 movementDirection;



	
	void Start()
	{
		movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;	

		//Facewhere moving
		transform.rotation = Quaternion.LookRotation(movementDirection);

	}



	// Update is called once per frame
	void Update ()
	{	
		//movement code
		transform.position += movementDirection*speed*Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == pathPoints[currentPathIndex].name)
		{
			

			currentPathIndex++;
			if(currentPathIndex >= pathPoints.Length)
			{
				//ADD LOGIC HERE TO DEDUCT HEALTH FROM PLAYER/BASE

				//Display thing for base


				//
				Destroy(gameObject);




			}
			else
			{
				movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;

				//Facewhere moving
				transform.rotation = Quaternion.LookRotation(movementDirection);
			}
		}
	}

	void SetPathPoints(GameObject[] inputPathPoints)
	{
		pathPoints = inputPathPoints;
	}
}
