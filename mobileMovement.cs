using UnityEngine;
using System.Collections;

public class mobileMovement : MonoBehaviour {
	
	public float transitionDuration = 0.5f;
	public string currentButton = string.Empty;

	// Must be opposite of the starting butting to "jump start" the movement
	public static string lastButtonPressed = "left";
	public Vector3 newPosition = new Vector3(3.0f,0,0);
	public float bearAlertLevel;
	public bool bearAwake = false;
	public GameObject bear;
    public GameObject safeZone;
	public GUITexture rightButton;
	public GUITexture leftButton;
	public Texture2D rightButtonActive;
	public Texture2D leftButtonActive;
	public Texture2D rightButtonInactive;
	public Texture2D leftButtonInactive;
//	private int SCREEN_HEIGHT = Screen.height;
//	private int SCREEN_WIDTH = Screen.width;
	//private float rightFootPos;
	//private float leftFootPos;
	//private int clickedFoot = 0;
	//public Rect alertBarRect;
	//public Rect alertBarLabelRect;
	//public Rect alertBarBackgroundRect;
	public GUITexture alertBarFull;
	public GUITexture alertBarNormal;
	public GUITexture alertBarFilling;
	public GUITexture pauseButtonObject;
	public Camera mainCamera;
	private bool isPaused = false;
    public GameObject throwNetPrompt;
    public AudioClip[] footSound = new AudioClip[4];
    public AudioClip bearAlarm;
    public GameObject suddenSound;
    public bool isBearLooking;
    private int footSoundInt;


	
	// Use this for initialization
	void Start () {
//		rightFootPos = (SCREEN_WIDTH / 4) * 3;
//		leftFootPos = SCREEN_WIDTH / 4;
        footSoundInt = 3;
        isBearLooking = false;
        suddenSound.GetComponent<Animator>().Play("HearSoundIdle");
	}
	
	// Update is called once per frame
	void Update () {

		isPaused = pauseButtonObject.GetComponent<pauseButton>().isPaused;

		// Grow the alert bar (do not show when the game is paused)
		if (bearAlertLevel > 0 && bearAwake == false && isPaused == false) 
		{
			// Decrease the alert level over time
			bearAlertLevel = bearAlertLevel - (Time.deltaTime*50);
			alertBarFilling.GetComponent<GUITexture>().enabled = true;
			alertBarFull.GetComponent<GUITexture>().enabled = false;
			alertBarFilling.GetComponent<GUITexture>().transform.localScale = new Vector3(bearAlertLevel * 0.005f,0.04f,1);
		}

		// The bear is not aware at all
		else if (bearAwake == false && isPaused == false)
		{
			alertBarFilling.GetComponent<GUITexture>().transform.localScale = new Vector3(0,0.04f,1);
			alertBarFilling.GetComponent<GUITexture>().enabled = false;
			alertBarFull.GetComponent<GUITexture>().enabled = false;
		}

		// The bear is coming
		else if (bearAwake == true && isPaused == false)
		{
			alertBarFull.GetComponent<GUITexture>().enabled = true;
		}

        if (throwNetPrompt.GetComponent<Renderer>().enabled == true && throwNetPrompt.transform.position != new Vector3(0,0,0))
        {
            rightButton.GetComponent<GUITexture>().texture = rightButtonInactive;
            leftButton.GetComponent<GUITexture>().texture = leftButtonInactive;
        }

        // Used to indicate to the user that no buttons can be pressed until the bear respawns after a net was thrown
        if (throwNetPrompt.GetComponent<throwNetScript>().bearReadyAndUp == true)
        {
            if (currentButton == "right" && leftButton.GetComponent<GUITexture>().texture == leftButtonInactive && throwNetPrompt.GetComponent<Renderer>().enabled == false && throwNetPrompt.GetComponent<throwNetScript>().bearReadyAndUp == true)
            {
                leftButton.GetComponent<GUITexture>().texture = leftButtonActive;
            }
            else if (currentButton == "left" && rightButton.GetComponent<GUITexture>().texture == rightButtonInactive && throwNetPrompt.GetComponent<Renderer>().enabled == false && throwNetPrompt.GetComponent<throwNetScript>().bearReadyAndUp == true)
            {
                rightButton.GetComponent<GUITexture>().texture = rightButtonActive;
            }
        }

		//bearAlertDisplay.text = "Level: " + bearAlertLevel.ToString ();
	}
	

	void OnGUI()
	{

	}

	public void inputHandler(string buttonPressed)
	{
		currentButton = buttonPressed;

        if ((currentButton == "left" && lastButtonPressed == "right" && throwNetPrompt.GetComponent<Renderer>().enabled == false && throwNetPrompt.GetComponent<throwNetScript>().bearReadyAndUp == true) || (currentButton == "right" && lastButtonPressed == "left" && throwNetPrompt.GetComponent<Renderer>().enabled == false && throwNetPrompt.GetComponent<throwNetScript>().bearReadyAndUp == true))
		{
            if (footSoundInt == 0)
            {
                footSoundInt = 1;
            }
            else if (footSoundInt == 1)
            {
                footSoundInt = 2;
            }
            else if (footSoundInt == 2)
            {
                footSoundInt = 3;
            }
            else if (footSoundInt == 3)
            {
                footSoundInt = 0;
            }

            GetComponent<AudioSource>().PlayOneShot(footSound[footSoundInt]);
			if (currentButton == "left")
			{
				// Switch other button to active
//				leftButton.guiTexture.enabled = false;
//				leftButtonInactive.guiTexture.enabled = true;
				rightButton.GetComponent<GUITexture>().texture = rightButtonActive;
				leftButton.GetComponent<GUITexture>().texture = leftButtonInactive;

			}
			else if (currentButton == "right")
			{
				leftButton.GetComponent<GUITexture>().texture = leftButtonActive;
				rightButton.GetComponent<GUITexture>().texture = rightButtonInactive;
//				rightButtonInactive.guiTexture.enabled = true;
//				rightButton.guiTexture.enabled = false;
			}

			// Slightly increase the bear's alert level for each step taken
			if (bearAlertLevel < 70.1f)
			{
				bearAlertLevel = bearAlertLevel + 30;
			}
			else if (bearAlertLevel > 70 && bearAlertLevel < 100.1f)
			{
				bearAlertLevel = 100;
			}

            if (isBearLooking == true)
            {
                bearAlertLevel = 120;
            }

            // Have player move backwards or forwards
			if (bearAwake == false)
			{
				StartCoroutine(SmoothMove());
			}
			else if (bearAwake == true)
			{
				StartCoroutine(ReverseSmoothMove());
			}
			BearHandler();
		}

        //if (Vector3.Distance(transform.position, bear.transform.position) < 3.0f) 
        //{
        //    rightButton.GetComponent<GUITexture>().texture = rightButtonInactive;
        //    leftButton.GetComponent<GUITexture>().texture = leftButtonInactive;
        //}

        //if (throwNetPrompt.GetComponent<Renderer>().enabled == true)
        //{
        //    rightButton.GetComponent<GUITexture>().texture = rightButtonInactive;
        //    leftButton.GetComponent<GUITexture>().texture = leftButtonInactive;
        //}

		if (currentButton == string.Empty) 
		{
			// Used for error prevention
			lastButtonPressed = "left";
		}
		else if (currentButton != string.Empty)
		{
			lastButtonPressed = currentButton;
		}

		//timeSinceStep = timeSinceStep + Time.deltaTime;
	}

	// Switch to iTween?
	IEnumerator SmoothMove()
	{
		Vector3 startingPos = transform.position;
		float timeCounter = 0.0f;
		while (timeCounter < 0.3f)
		{
			timeCounter += Time.deltaTime * (Time.timeScale/transitionDuration);
			
			transform.position = Vector3.Lerp(startingPos, startingPos + newPosition, timeCounter);
			yield return 0;
		}
	}

	IEnumerator ReverseSmoothMove()
	{
		Vector3 startingPos = transform.position;
		float timeCounter = 0.0f;
		while (timeCounter < 0.3f)
		{
			timeCounter += Time.deltaTime * (Time.timeScale/transitionDuration);
			
            // Prevent player from falling behind building
            if (transform.position.x > 3)
            { 
			    transform.position = Vector3.Lerp(startingPos, startingPos - newPosition, timeCounter);
            }
			yield return 0;
		}
	}

	void BearHandler()
	{
        if (bearAlertLevel >= 100 && bearAwake == false && safeZone.GetComponent<SafeZone>().inSafeZone == false)
        {
			bear.GetComponent<BearBehaviour>().BearAwake();
            GetComponent<AudioSource>().PlayOneShot(bearAlarm);
			bearAwake = true;
		}



        int bearLook = Random.Range(0, 14);

        // Number picked to make bear look at player
        if (bearLook == 1 && bearAlertLevel < 100)
        {
            suddenSound.GetComponent<Animator>().Play("HearSound");
            bear.GetComponent<Animator>().Play("BearTurnLook");
            isBearLooking = true;
            StartCoroutine(TurnAndLookWaitAndCallback(3.0f));
        }
		//timeSinceStep = 0;
	}

    IEnumerator TurnAndLookWaitAndCallback(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isBearLooking = false;

        // Make sure bear wasn't awoken
        if (bearAwake == false)
        {
            //StartCoroutine(TurnToIdleWaitAndCallback(0.55f));
            bear.GetComponent<Animator>().Play("BearIdle");
        }

        suddenSound.GetComponent<Animator>().Play("HearSoundIdle");
        //StartCoroutine(BearLookingForMovement());
    }
	
}
