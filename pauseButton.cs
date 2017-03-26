using UnityEngine;
using System.Collections;

public class pauseButton : MonoBehaviour {

	public bool isPaused = false;
	public GUITexture resumeButton;
	public GUITexture quitButton;
	public GUITexture pauseImage;
	public GUITexture bearAlertIcon;
	public GUITexture leftFoot;
	public GUITexture rightFoot;
	public GUITexture alertBar;
	public GUITexture alertBarFilling;
	public GUITexture alertBarFull;
    public GameObject score;
    public GameObject bearsCaught;
    public GameObject timeTaken;
    private float timeSinceLoad;

	// Use this for initialization
	void Start () {

        timeSinceLoad = 0.0f;
		//pauseImage = GameObject.Find ("pauseScreen");
		pauseImage.enabled = false;
		resumeButton.enabled = false;
		quitButton.enabled = false;

        // Handle hidden start gui here
        bearAlertIcon.enabled = false;
        leftFoot.enabled = false;
        rightFoot.enabled = false;
        alertBar.enabled = false;
        alertBarFilling.enabled = false;
        alertBarFull.enabled = false;
        score.GetComponent<UnityEngine.UI.Text>().enabled = false;
        bearsCaught.GetComponent<UnityEngine.UI.Text>().enabled = false;
        timeTaken.GetComponent<UnityEngine.UI.Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        // Show gui after 4 seconds, then stop updating timer
        if (timeSinceLoad < 4.2f)
        {
            timeSinceLoad = timeSinceLoad + Time.deltaTime;
        }
        if (timeSinceLoad > 4.0f && isPaused == false)
        {
            bearAlertIcon.enabled = true;
            leftFoot.enabled = true;
            rightFoot.enabled = true;
            alertBar.enabled = true;
            alertBarFilling.enabled = true;
           // alertBarFull.enabled = true;
            score.GetComponent<UnityEngine.UI.Text>().enabled = true;
            bearsCaught.GetComponent<UnityEngine.UI.Text>().enabled = true;
            timeTaken.GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
	}

	void OnMouseDown()
	{
		// Check if already paused
		//if (isPaused == false)
		//{
			isPaused = true;
			pauseImage.enabled = true;
			resumeButton.enabled = true;
			quitButton.enabled = true;
			bearAlertIcon.enabled = false;
			leftFoot.enabled = false;
			rightFoot.enabled = false;
			alertBar.enabled = false;
			alertBarFilling.enabled = false;
			alertBarFull.enabled = false;
			this.GetComponent<GUITexture>().enabled = false;
			Time.timeScale = 0.0f;
		//}
//		else 
//		{
//			isPaused = false;
//			pauseImage.enabled = false;
//			resumeButton.enabled = false;
//			quitButton.enabled = false;
//			alertBar.enabled = true;
//			alertBarFilling.enabled = true;
//			alertBarFull.enabled = true;
//			this.guiTexture.enabled = true;
//			Time.timeScale = 1.0f;
//		}
	}

	void OnGUI()
	{
		//if (isPaused == true)
		//{

		//}
	}
}
