using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour {

	public float initialEnergy = 0;
	public GameObject energyDisplay;

	public static float energy;

	// Use this for initialization
	void Start () {

			energy = TowerUpgrader.GetCash()+TowerUpgrader.GetDifficulty()*600.0f;

	
	}
	
	// Update is called once per frame
	void Update () {
		
		energyDisplay.GetComponent<TextMesh>().text ="Cash: " + System.Math.Round (energy*1.0f, 0).ToString();
	
	}
}
