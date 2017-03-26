using UnityEngine;
using System.Collections;

public class buttonAboutScript : MonoBehaviour {

    public Texture2D normalTexture;
    public Texture2D hoverTexture;
    public GUITexture startButton;
    public GUITexture howToPlayButton;
    public GUITexture leaderboardsButton;
    public GUIText titleText;
    public UnityEngine.UI.Text copyrightText;
    public GUITexture aboutScreen;
    public GUITexture backToMainButton;

    // Use this for initialization
    void Start()
    {
        aboutScreen.enabled = false;
        backToMainButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //this.GetComponent<GUITexture>().texture = hoverTexture;
        this.GetComponent<GUITexture>().texture = normalTexture;
        startButton.enabled = false;
        howToPlayButton.enabled = false;
        leaderboardsButton.enabled = false;
        titleText.enabled = false;
        copyrightText.enabled = false;
        this.GetComponent<GUITexture>().enabled = false;
        aboutScreen.enabled = true;
        backToMainButton.enabled = true;
        //Application.LoadLevel("Main");
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
