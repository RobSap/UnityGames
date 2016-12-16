using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public GameObject currentTower;


	// Use this for initialization
	void Start () {
		string Tag = currentTower.tag;
//		print (Tag);
		float temp = 0;
		if(Tag == "MortarTower")
			temp = currentTower.GetComponent <MortarTower>().fireRadius;
		else if (Tag == "machinegun1" )
			temp = currentTower.GetComponent <machinegunTower>().fireRadius;
		else if (Tag == "lazer1")
			temp = currentTower.GetComponent <lazerTower>().fireRadius;
		else if (Tag == "gun1")
			temp = currentTower.GetComponent <gunTower>().fireRadius;
		else if (Tag == "gunslow")
			temp = currentTower.GetComponent <gunSlowTower>().fireRadius;
		
		//Scales
		temp = temp * 4.275f;//was 2.45f
		transform.localScale += new Vector3(temp,temp,temp);
		Object.Destroy(gameObject, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
