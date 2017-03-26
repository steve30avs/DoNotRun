using UnityEngine;
using System.Collections;

public class walkLeftButton : MonoBehaviour {

	public static bool isPressed = false;
	public GameObject player;
	public Texture2D leftButtonActiveImage;
	public Texture2D leftButtonInactiveImage;
	public Texture2D leftButtonPressedImage;
	
	// Use this for initialization
	void Start () {
		this.GetComponent<GUITexture>().texture = leftButtonInactiveImage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown()
	{
		if (this.GetComponent<GUITexture>().texture == leftButtonActiveImage)
		{
			this.GetComponent<GUITexture>().texture = leftButtonPressedImage;
		}
		//this.guiTexture.enabled = false;

		//player.GetComponent<mobileMovement> ().inputHandler ("left");
	}
	
	void OnMouseUp()
	{
		if (this.GetComponent<GUITexture>().texture == leftButtonActiveImage)
		{
			this.GetComponent<GUITexture>().texture = leftButtonPressedImage;
		}
		//this.guiTexture.enabled = false;
		
		player.GetComponent<mobileMovement> ().inputHandler ("left");
		//this.guiTexture.enabled = true;
		//leftButtonPressedImage.enabled = false;
		//this.guiTexture.texture = leftButtonInactiveImage;
	}
}
