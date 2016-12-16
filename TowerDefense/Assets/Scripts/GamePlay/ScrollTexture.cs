using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour {

	public float xScrollRate = 1.0f;
	public float yScrollRate = 1.0f;

	// Use this for initialization
	void Start () {

		GetComponent<Renderer>().material.mainTextureOffset = Vector2.zero;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newOffset = GetComponent<Renderer>().material.mainTextureOffset;
		newOffset.x += xScrollRate * Time.deltaTime;
		newOffset.y += yScrollRate * Time.deltaTime;
		GetComponent<Renderer>().material.mainTextureOffset = newOffset;
	
	}
}
