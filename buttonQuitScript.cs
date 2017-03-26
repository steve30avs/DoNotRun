using UnityEngine;
using System.Collections;

public class buttonQuitScript : MonoBehaviour {
	
	public Texture2D hoverTexture;
	public Texture2D normalTexture;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
        this.GetComponent<GUITexture>().texture = normalTexture;
        //this.GetComponent<GUITexture>().texture = hoverTexture;
	}
	
	void OnMouseUp()
	{
		this.GetComponent<GUITexture>().texture = normalTexture;

		// Timescale gets passed to other scenes for some reason
		Time.timeScale = 1.0f;
		Application.LoadLevel("Startup");
	}
	
	void OnMouseEnter()
	{
		this.GetComponent<GUITexture>().texture = hoverTexture;
	}
	void OnMouseExit()
	{
		this.GetComponent<GUITexture>().texture = normalTexture;
	}
}
