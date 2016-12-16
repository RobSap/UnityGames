using UnityEngine;
using System.Collections;

public class EnemySpawner2 : MonoBehaviour {


		public GameObject[] pathPoints;
		public GameObject graphicalPathObject;

		public int waveCount;

		private int spawnIndex=0;

		public GameObject[] spawnList; //List of enemies that spawn

		public float spawnTime; //time between enemies that spawn
		public float delayInitial;

		// Use this for initialization
		void Start () {

			//	for (int i = 0; i < waves; i++) {
			//First spawn time is initial spawn time, and second one is eash spawn after
			InvokeRepeating ("Spawn", delayInitial, spawnTime);

			CreatGraphicalPathObjects ();
			//}

		}

		// Update is called once per frame
		void Update () {


		}

		void Spawn()
		{


			//Spawn (instantiate) next enemy in spawnlist
			//Transform and quaterinan gives us an enemy where spawner is

			if (spawnIndex > spawnList.Length) {

				waveCount = waveCount - 1;
			if (waveCount <= 0) {
				CancelInvoke ();
			} else {
				spawnIndex = 0;
			}

			}

			GameObject reference = Instantiate (spawnList [spawnIndex], transform.position, Quaternion.identity) as GameObject;

			spawnIndex++;

			if (spawnIndex >= spawnList.Length) {
			waveCount = waveCount - 1;
				//waveCount = waveCount - 1;
			if (waveCount <= 0) {
					
				CancelInvoke ();
			} else {
				spawnIndex = 0;
			}
				//CancelInvoke ();

			}


			//Set enemy path information
			reference.SendMessage ("SetPathPoints", pathPoints);

			//Add delay between waves here


		}

		void CreatGraphicalPathObjects ()
		{

			//Create object between transform.position and first waypoint
			Vector3 pathObjectPosition = ((pathPoints[0].transform.position - transform.position)*0.5f) + transform.position;
			Quaternion pathObjectOrientation = Quaternion.LookRotation(pathPoints[0].transform.position - transform.position);
			GameObject pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
			Vector3 newScale = Vector3.one;
			newScale.z = (pathPoints[0].transform.position - transform.position).magnitude;
			pathObject.transform.localScale = newScale;

			Vector2 newTextureScale = Vector2.one;
			newTextureScale.y = (pathPoints[0].transform.position - transform.position).magnitude;
			pathObject.GetComponent<Renderer>().material.mainTextureScale = newTextureScale;

			for(int i = 1; i < pathPoints.Length; i++)
			{
				pathObjectPosition = ((pathPoints[i].transform.position - pathPoints[i-1].transform.position)*0.5f) + pathPoints[i-1].transform.position;

					pathObjectOrientation = Quaternion.LookRotation(pathPoints[i].transform.position - pathPoints[i-1].transform.position);
				
				pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
				newScale = Vector3.one;
				newScale.z = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
				pathObject.transform.localScale = newScale;

				newTextureScale = Vector2.one;
				newTextureScale.y = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
				pathObject.GetComponent<Renderer>().material.mainTextureScale = newTextureScale;
			}

		}

		void OnDrawGizmos()
		{
			Gizmos.DrawLine (transform.position, pathPoints [0].transform.position);

			for (int i = 1; i < pathPoints.Length; i++) {

				Gizmos.DrawLine (pathPoints[i-1].transform.position, pathPoints[i].transform.position);

			}
		}
	}
