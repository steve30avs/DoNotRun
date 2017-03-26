using UnityEngine;
using System.Collections;

public class buttonBackToStartScript : MonoBehaviour {

    public Texture2D normalTexture;
    public Texture2D hoverTexture;
    public GUITexture startButton;
    public GUITexture aboutButton;
    public GUITexture leaderboardsButton;
    public GUIText titleText;
    public UnityEngine.UI.Text copyrightText;
    public GUITexture howToPlayScreen;
    public GUITexture howToPlayButton;
    public GUITexture aboutScreen;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //this.GetComponent<GUITexture>().texture = hoverTexture;
        this.GetComponent<GUITexture>().texture = normalTexture;
        startButton.enabled = true;
        aboutButton.enabled = true;
        this.GetComponent<GUITexture>().enabled = false;
        leaderboardsButton.enabled = true;
        titleText.enabled = true;
        copyrightText.enabled = true;
        howToPlayButton.enabled = true;
        
        // Check which screen user is backing out of
        if (howToPlayScreen.enabled == true)
        {
            howToPlayScreen.enabled = false;
        }
        else if (aboutScreen.enabled == true)
        {
            aboutScreen.enabled = false;
        }
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
