using UnityEngine;
using System.Collections;

public class buttonStartScript : MonoBehaviour {

	public Texture2D normalTexture;
	public Texture2D hoverTexture;
    public GameObject googleGameObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		//this.GetComponent<GUITexture>().texture = hoverTexture;
        this.GetComponent<GUITexture>().texture = normalTexture;
        if (this.name == "buttonMainMenu")
        {
            Application.LoadLevel("Startup");
            
            // Kill the ad before going back to main menu the game
            googleGameObject.GetComponent<GoogleAds>().interstitial.Destroy();
        }
        else
        {
            // Kill the ad before starting the game
            googleGameObject.GetComponent<GoogleAds>().bannerView.Destroy();
            Application.LoadLevel("Main");
        }
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
