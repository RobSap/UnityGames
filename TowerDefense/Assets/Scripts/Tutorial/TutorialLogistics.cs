using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialLogistics : MonoBehaviour {
	public Text txt;
	public GameObject current;
	public GameObject next;

	int counter = 1;

	void Start () {

		txt.text = "On the top of the screen is where you can keep track of your current " +
			"level, wave, score, and cash.";
	}

	public void LogisticsInnerProgression(){
		if (counter == 1) {
			txt.text = "There are 5 levels, each with 3 waves, and a boss at the end. Your score increases by killing enemies.";
		}

		if (counter == 2) {
			txt.text = "You need cash in order to buy towers and upgrades. Depending on your difficulty level, which can be changed in " +
			"the options menu can be accessed through the main menu will determine your start money.";
		}
		if (counter == 3) {
			txt.text = "IMPORT: Cash you saved in the previous level is added to your start mone for the next level! The money you saved can go towards " +
			"upgrades for towers or having a higher starting cash amount for more towers early on in " +
			"the next level. Use your cash smart or you won't be able to beat the next level.";
		}
		if (counter == 4) {
			current.SetActive (false);
			next.SetActive (true);

		}

		counter++;
	}

}
