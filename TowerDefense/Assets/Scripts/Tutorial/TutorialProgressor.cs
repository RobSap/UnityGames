using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialProgressor : MonoBehaviour {

	// Use this for initialization
	public GameObject tutorialObject;
	public GameObject welcome;
	public GameObject towers;
	public GameObject logistics;
	public GameObject hints;

	void Start () {
		welcome.SetActive(true);
	}

	public void skipTutorial(){
		SceneManager.LoadScene ("level1");
	}
		
}
