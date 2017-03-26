using UnityEngine;
using System.Collections;

public class buttonResumeScript : MonoBehaviour {

	public GUITexture quitButton;
	public GUITexture pauseImage;
	public Texture2D hoverTexture;
	public Texture2D normalTexture;
	public GUITexture pauseButtonObject;
	public GUITexture bearAlertIcon;
	public GUITexture leftFoot;
	public GUITexture rightFoot;
	public GUITexture alertBar;
	public GUITexture alertBarFilling;
	public GUITexture alertBarFull;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		//this.GetComponent<GUITexture>().texture = hoverTexture;
        this.GetComponent<GUITexture>().texture = normalTexture;
		//Debug.Log ("RESUMEPRESS");

		//this.enabled = false;
	}

	void OnMouseEnter()
	{
		this.GetComponent<GUITexture>().texture = hoverTexture;
	}
	void OnMouseExit()
	{
		this.GetComponent<GUITexture>().texture = normalTexture;
	}
	
	void OnMouseUp()
	{
		//this.guiTexture.enabled = true;
		this.GetComponent<GUITexture>().texture = normalTexture;
		this.GetComponent<GUITexture>().enabled = false;
		pauseImage.enabled = false;
		quitButton.enabled = false;
		pauseButtonObject.enabled = true;
		bearAlertIcon.enabled = true;
		leftFoot.enabled = true;
		rightFoot.enabled = true;
		alertBar.enabled = true;
		alertBarFilling.enabled = true;
		alertBarFull.enabled = true;
		Time.timeScale = 1.0f;
		pauseButtonObject.GetComponent<pauseButton>().isPaused = false;
	}
}
