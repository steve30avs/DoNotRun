using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;


public class ScoreDisplay : MonoBehaviour {

    public GUIText winOrLoseText;

	// Use this for initialization
	void Start () {
        if (winOrLoseText.name == "scoreLoseText")
        {
            winOrLoseText.text = "Score: " + (int)throwNetScript.scoreCount + "\nTotal Time Taken: "
    + throwNetScript.timeSinceLoad.ToString("F1") + " seconds";
        }
        else
        {
            winOrLoseText.text = "You caught all the bears!\nScore: " + (int)throwNetScript.scoreCount + "\nTotal Time Taken: "
    + throwNetScript.timeSinceLoad.ToString("F1") + " seconds";
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
