using UnityEngine;
using System.Collections;

public class RestoreSpeed : MonoBehaviour {

	public float originalSpeed;
	public float time;


	void Start()
	{
		Invoke ("RestoreSpeedFunction", time);
	}



	void RestoreSpeedFunction()
	{
		PathThroughObjects scriptInstance = gameObject.transform.parent.GetComponent<PathThroughObjects>();
		scriptInstance.speed = originalSpeed;
		Destroy (gameObject);


	}

}
