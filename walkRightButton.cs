using UnityEngine;
using System.Collections;

public class walkRightButton : MonoBehaviour {

	public static bool isPressed = false;
	public GameObject player;
	public Texture2D rightButtonActiveImage;
	public Texture2D rightButtonInactiveImage;
	public Texture2D rightButtonPressedImage;

	// Use this for initialization
	void Start () {
		//player.GetComponent<mobileMovement>().method
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if (this.GetComponent<GUITexture>().texture == rightButtonActiveImage) 
		{
			this.GetComponent<GUITexture>().texture = rightButtonPressedImage;
		}

		//player.GetComponent<mobileMovement> ().inputHandler ("right");
	}

	void OnMouseUp()
	{
		player.GetComponent<mobileMovement> ().inputHandler ("right");
		//this.guiTexture.enabled = true;
		//this.guiTexture.texture = rightButtonInactiveImage;
	}

//	void OnMouseEnter()
//	{
//		if (this.guiTexture.texture == rightButtonActiveImage)
//		{
//			this.guiTexture.texture = rightButtonPressedImage;
//		}
//	}
//	void OnMouseExit()
//	{
//		if (this.guiTexture.texture == rightButtonPressedImage)
//		{
//			this.guiTexture.texture = rightButtonActiveImage;
//		}
//	}

}
