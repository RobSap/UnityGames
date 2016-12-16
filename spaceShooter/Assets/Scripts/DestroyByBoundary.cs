using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	//Destorys stuff when it leaves the trigger area
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}

}
