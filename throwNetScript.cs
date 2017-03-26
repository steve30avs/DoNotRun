using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class throwNetScript : MonoBehaviour {

	public static bool isPressed = false;
	private Animator animator;
	public GameObject bear;
	public bool netThrown = false;
    public bool bearReadyAndUp = true;
    public GameObject scoreTextObject;
    public GameObject timeTextObject;
    public float bearTimer;
    public static float scoreCount;
    public static float timeSinceLoad;
    public AudioClip netSound;
    public AudioClip bearCaughtSound;
    public AudioClip bearFallSound;

	// Use this for initialization
	void Start () {
		animator = bear.GetComponent<Animator> ();
        timeSinceLoad = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        scoreTextObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreCount.ToString("F0");
        timeTextObject.GetComponent<UnityEngine.UI.Text>().text = "Time: " + bearTimer.ToString("F1");
       
        if (timeSinceLoad < 4.2f)
        {
            timeSinceLoad = timeSinceLoad + Time.deltaTime;
        }
        if (timeSinceLoad > 4.0f)
        {
            bearTimer = bearTimer + Time.deltaTime;
            timeSinceLoad = timeSinceLoad + Time.deltaTime;

        }
	}

	IEnumerator FinishAnimation()
	{
		yield return new WaitForSeconds(2);
		//Destroy (bear);
        animator.Play("BearIdle");

        // Prevent user from moving until new bear is spawned
        bearReadyAndUp = true;

        bear.transform.rotation = Quaternion.Euler(0, 90, 0);
        bear.transform.position = bear.transform.position + new Vector3(8.0f, 1.0f, 0);
        bear.GetComponent<BearBehaviour>().currentBearCount = bear.GetComponent<BearBehaviour>().currentBearCount + 1;

        // Math time
        if (bearTimer < 40)
        {
            scoreCount = scoreCount + 1000 - (bearTimer * 10);
        }
        // Took forever to catch bear
        else
        {
            scoreCount = scoreCount + 100;
        }
        bearTimer = 0.0f;
        
        netThrown = false;

        if (bear.GetComponent<BearBehaviour>().currentBearCount > 9)
        {
            // End the game here
            Application.LoadLevel("GameWin");
        }
	}

	void OnMouseDown()
	{
        // Prevent user from rethrowing the net during the BearNet animation
        bearReadyAndUp = false;
		netThrown = true;
        this.GetComponent<AudioSource>().PlayOneShot(netSound);
        this.GetComponent<AudioSource>().PlayOneShot(bearCaughtSound);
        this.GetComponent<AudioSource>().PlayOneShot(bearFallSound);
		//Debug.Log ("Bear gone boom2");
		//this.transform.position = new Vector3(0,0,0);
	}
	void OnMouseUp()
	{
		//Debug.Log ("Bear gone boom1");
		this.gameObject.transform.position = new Vector3(0,0,0);
        this.GetComponent<Renderer>().enabled = false;
		//this.gameObject.transform.position = new Vector3(0,0,0);
		animator.Play ("BearNet");
		StartCoroutine(FinishAnimation ());

		//this.guiTexture.enabled = true;
		//this.gameObject.transform.position = new Vector3(0,0,0);

	}
}
