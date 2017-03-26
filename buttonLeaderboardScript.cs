using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;

public class buttonLeaderboardScript : MonoBehaviour {

	public Texture2D normalTexture;
	public Texture2D hoverTexture;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		//this.GetComponent<GUITexture>().texture = hoverTexture;
        //Social.LoadScores("DoNotRunMainLeaderboard",);

        #if UNITY_IPHONE
            Social.ShowLeaderboardUI();
        #endif

        #if UNITY_ANDROID
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIxuLeproPEAIQAA");
        #endif

        Social.ShowLeaderboardUI();
        this.GetComponent<GUITexture>().texture = normalTexture;
		//Application.LoadLevel("Main");
	}

    // Posting scores
    //private long scorePost = (long)throwNetScript.scoreCount; // Gamecenter requires a long variable
    //Social.ReportScore(scorePost,"DoNotRunMainLeaderboard",HighScoreCheck);
 
    private static void HighScoreCheck()
    {
        //if(result)
            //Debug.Log("score submission successful");
        //else
        //Debug.Log("score submission failed");
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
