using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class welcomeProgression : MonoBehaviour {
	public Text txt;
	public GameObject current;
	public GameObject next;
	// Use this for initialization
	int counter = 1;

	public void welcomeInnerProgression(){
		if (counter == 1) {
			txt.text = "You can skip the tutorial at anytime by hitting the skip button.";
		}

		if (counter == 2) {
			txt.text = "This quick tutorial will go over the basics of the game and help you understand" +
				"the tradeoffs of spending money now or saving it.";
		}
		if (counter == 3) {
			current.SetActive (false);
			next.SetActive (true);
		
		}

		counter++;
	}

}
