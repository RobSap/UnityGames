using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour {


	public void LevelButton(Button button)
	{
		if (button.name == "Back") {
			SceneManager.LoadScene ("mainMenu");
		}
	}
}
