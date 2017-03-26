using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;

public class GameCenterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        #if UNITY_IPHONE
            Social.localUser.Authenticate(ProcessAuthentication);
        #endif

        #if UNITY_ANDROID
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();

            Social.localUser.Authenticate(ProcessAuthentication);
        #endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // This function gets called when Authenticate completes
    // Note that if the operation is successful, Social.localUser will contain data from the server. 
    void ProcessAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            //Social.LoadAchievements(ProcessLoadedAchievements);
            Social.ShowLeaderboardUI();
        }
        else
            Debug.Log("Failed to authenticate");
    }

    // This function gets called when the LoadAchievement call completes
    void ProcessLoadedAchievements(IAchievement[] achievements)
    {
        if (achievements.Length == 0)
            Debug.Log("Error: no achievements found");
        else
            Debug.Log("Got " + achievements.Length + " achievements");

        //// You can also call into the functions like this
        //Social.ReportProgress("Achievement01", 100.0, result =>
        //{
        //    if (result)
        //        Debug.Log("Successfully reported achievement progress");
        //    else
        //        Debug.Log("Failed to report achievement");
        //});
    }
}
