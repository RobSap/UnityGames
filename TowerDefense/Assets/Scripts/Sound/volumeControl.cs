using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class volumeControl : MonoBehaviour {

	public AudioMixer masterMixer;
	public Slider MusicSlider;
	public Slider SFX;

	void Start(){

		SFX.value= PlayerPrefs.GetFloat("sfxVol");
		MusicSlider.value=PlayerPrefs.GetFloat("musicVol");

		SetSfxLvl (PlayerPrefs.GetFloat ("sfxVol"));
		SetMusicLvl (PlayerPrefs.GetFloat("musicVol"));

	}


	void Update()
	{
		SFX.value= PlayerPrefs.GetFloat("sfxVol");
		MusicSlider.value=PlayerPrefs.GetFloat("musicVol");

		SetSfxLvl (PlayerPrefs.GetFloat ("sfxVol"));
		SetMusicLvl (PlayerPrefs.GetFloat("musicVol"));

	}


	public void SetSfxLvl(float sfxLvl)
	{
		masterMixer.SetFloat ("sfxVol",sfxLvl);
		PlayerPrefs.SetFloat("sfxVol", sfxLvl);
	}

	public void SetMusicLvl (float musicLvl)
	{
		masterMixer.SetFloat ("musicVol", musicLvl);
		PlayerPrefs.SetFloat("musicVol", musicLvl);
	}



}


