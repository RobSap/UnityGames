using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public  Texture2D fadeInTexture;
	public  Texture2D fadeWinTexture;
	public static float fadeSpeed = 0.8f;

	public static int win;

	private  int drawDepth = -1000;
	private  float alpha = 1.0f;
	private static int fadeDir = -1;


	void Start(){
		win = 0;
	}
	public static void ChangeToWin(int value){
		win = value;
	}

	void OnGUI(){
		if (win == 0) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);

			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeInTexture);
		}
		if (win == 1) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);

			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeWinTexture);
		}
	}

	public static float BeginFade(int direction){
		fadeDir = direction;
		return(fadeSpeed);
	}
	
	void OnLevelWasLoaded()
	{
		BeginFade (-1);
	}
		
}
