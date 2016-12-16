using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateTowerOnClicked : MonoBehaviour
{
	public TowerSelector towerSelector;


	public MeshCollider planeMesh;
	public GameObject rangeObject;
	public RectTransform ParentPanel;
	public GameObject cancel;
	public GameObject confirm;

	//This gives a warning bug , Unity is aware of it. Its a contraction, if you fix the warning
	// it causes another 1, that is considered worse.
	//http://forum.unity3d.com/threads/warning-generated-at-build-but-not-at-compilation-impossible-warning-photon-producing-warning.342104/
	public new Camera camera;


	void Start() {
		//camera = GetComponent<Camera>();
	}
	//Gives exact position of item that was clicked
	public void Clicked(Vector3 towerPosition)
	{
		//Check if you got energy to buy
		if (EnergyManager.energy >= towerSelector.GetSelectedTowerCost ()) 
		{
			GameObject tower = towerSelector.GetSelectedTower ();


			//Instantiate Tower
			GameObject t = Instantiate (tower, towerPosition + Vector3.up * 0.5f, tower.transform.rotation) as GameObject;

			//SetActive (false);
			string Tag = tower.tag;
			float temp = 0;
		
			//Find Fire Radius
			if (Tag == "MortarTower") {
				t.GetComponent<MortarTower> ().enabled = false;
				temp = tower.GetComponent <MortarTower> ().fireRadius;
			} else if (Tag == "machinegun1") {
				t.GetComponent<machinegunTower>().enabled = false;
				temp = tower.GetComponent <machinegunTower> ().fireRadius;
			} else if (Tag == "lazer1") {
				t.GetComponent<lazerTower>().enabled = false;
				temp = tower.GetComponent <lazerTower> ().fireRadius;
			} else if (Tag == "gun1") {
				t.GetComponent<gunTower>().enabled = false;
				temp = tower.GetComponent <gunTower> ().fireRadius;
			} else if (Tag == "gunslow") {
				t.GetComponent<gunSlowTower>().enabled = false;
				temp = tower.GetComponent <gunSlowTower> ().fireRadius;
			}

			//Create Range Object
			GameObject range = Instantiate (rangeObject, towerPosition + Vector3.up * 0.5f, tower.transform.rotation) as GameObject;
			temp = temp * 1.875f; // New Scale
			range.transform.localScale += new Vector3(temp,temp,temp);//Set Size of range



			//Set Location for Cancel Button
			Vector3 screenPos = camera.WorldToScreenPoint(towerPosition);
			if (Application.platform == RuntimePlatform.Android)
				screenPos.x -=  140;
			
			else if (Application.platform == RuntimePlatform.OSXWebPlayer)
				screenPos.x -=  70;
			
			else if (Application.platform == RuntimePlatform.WindowsWebPlayer )
				screenPos.x -=  70;
			else 
				screenPos.x -=  60;
				
			//Cancel Button
			GameObject cancelButton = (GameObject)Instantiate(cancel);
			cancelButton.transform.SetParent(ParentPanel, false);
			cancelButton.transform.position = screenPos;
			Button tempButton1 = cancelButton.GetComponent<Button>();


			//Set Location for Confirm Button

			if (Application.platform == RuntimePlatform.Android)
				screenPos.x += 280;
			else if (Application.platform == RuntimePlatform.OSXWebPlayer )
				screenPos.x += 140;
			else if (Application.platform == RuntimePlatform.WindowsWebPlayer)
				screenPos.x += 140;
			else 
				screenPos.x += 120;


			
			//Confirm Button
			GameObject confirmButton = (GameObject)Instantiate(confirm);
			confirmButton.transform.SetParent(ParentPanel, false);
			confirmButton.transform.position = screenPos;
			Button tempButton2 = confirmButton.GetComponent<Button>();

			//Add Listener to buttons
			tempButton1.onClick.AddListener(() => CancelTower(range, cancelButton, confirmButton, t ));
			tempButton2.onClick.AddListener(() => ConfirmTower(range, cancelButton, confirmButton, t));


			//Turn off placing towers until yes or no
			planeMesh.enabled = false;
		}
	}

	void CancelTower(GameObject r, GameObject b1, GameObject b2, GameObject t){
		Destroy (t);
		endProcess (r, b1, b2);
	}
	void ConfirmTower(GameObject r, GameObject b1, GameObject b2, GameObject t){
		EnergyManager.energy -= towerSelector.GetSelectedTowerCost ();

		GameObject tower = towerSelector.GetSelectedTower ();
		string Tag = tower.tag;

		//Find Fire Radius
		if (Tag == "MortarTower") {
			t.GetComponent<MortarTower> ().enabled = true;
		
		} else if (Tag == "machinegun1") {
			t.GetComponent<machinegunTower>().enabled = true;
		} else if (Tag == "lazer1") {
			t.GetComponent<lazerTower>().enabled = true;
		} else if (Tag == "gun1") {
			t.GetComponent<gunTower>().enabled = true;
		} else if (Tag == "gunslow") {
			t.GetComponent<gunSlowTower>().enabled = true;
		}

		endProcess (r, b1, b2);
	}

	void endProcess(GameObject r, GameObject b1, GameObject b2){
		//Destroy range
		Destroy(b1);
		Destroy (b2);
		planeMesh.enabled = true;
		Destroy (r);

	}
}
