using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class buttonSubmitScore : MonoBehaviour {

    public Texture2D normalTexture;
    public Texture2D hoverTexture;

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

        // Posting scores
        long scorePost = (long)throwNetScript.scoreCount;
        
        // Gamecenter requires a long variable
        // Show leaderboard once score is submitted
        #if UNITY_IPHONE
            Social.ReportScore(scorePost, "DoNotRunMainLeaderboard", success =>
            {
                Debug.Log(success ? "Reported successfully" : "FAILED TO REPORT SCORE");
                Debug.Log("New Score: " + scorePost);
                Social.ShowLeaderboardUI();
            });
         #endif

         #if UNITY_ANDROID
        Social.ReportScore(scorePost, "CgkIxuLeproPEAIQAA", success =>
            {
                Debug.Log(success ? "Reported successfully" : "FAILED TO REPORT SCORE");
                Debug.Log("New Score: " + scorePost);
                Social.ShowLeaderboardUI();
            });
         #endif

        


    }

    static void HighScoreCheck(bool result)
    {
        if (result)
        {
            Debug.Log("score submission successful");
        }
        else
        {
            Debug.Log("score submission failed");
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
