using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	AudioSource sound;

	void OnTriggerEnter(){

		sound.Play ();
		
	}
}
