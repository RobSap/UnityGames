using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialTower : MonoBehaviour {
	public Text txt;
	public GameObject current;
	public GameObject next;
	public GameObject towerSelector;
	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;
	public GameObject t5;


	int counter = 1;
	// Use this for initialization
	void Start () {
		txt.text = "There are five different towers in the game. All five can be upgraded. They all have four different attributes, range, fire rate (lower is better), " +
			"damage, and cost.";
	}

	public void TowerInnerProgression(){
		if (counter == 1) {
			txt.text = "First is the basic cannon tower. It has great range, decent fire rate and damage with a low cost.";
		}
		if (counter == 2) {
			setTower (t2);
			txt.text = "Second is the mortar. The mortar has splash damage which will damage enemies in an area. It has great range, a slow fire rate, good damage, medium cost.";
		}
		if (counter == 3) {
			setTower (t3);
			txt.text = "Third is the slow. The slow has an effect that will slow the targetted enemies speed. It has a short range, a slow fire rate, and decent damage with a low cost." +
			" The slow's stats might not look impressive but its effect can make this tower very useful if used strategically.";
		}
		if (counter == 4) {
			setTower (t4);
			txt.text = "Fourth is the Machine Gun. The MG has a short range, an extremely fast rate, low damage and medium cost.";
		}
		if (counter == 5) {
			setTower (t5);
			txt.text = "Fifth is the lazer. The lazer has a short range, medium fire rate and high damage that comes with high cost.";
		}
		if (counter == 6) {
			setTower (t1);
			current.SetActive (false);
			next.SetActive (true);
		}
		counter++;

	}

	void setTower(GameObject t){
		towerSelector.SendMessage ("SetSelectedTower", t);
	
	}
}
