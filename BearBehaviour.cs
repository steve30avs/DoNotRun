using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BearBehaviour : MonoBehaviour {

    // TransitionDuration makes it take longer with a smaller number (being divided by)
	public float transitionDuration = 10.0f;
	public int bearInstance;
	private Vector3 bearStartPos = new Vector3(31.4f,2.36f,50.32f);
	public GameObject player;
	public GameObject safeZone;
	public GameObject throwNetPrompt;
	private Animator animator;
	//public AudioClip bearAlertSound;
    public AudioClip bearAlertGrowlSound;
    public AudioClip[] footSound = new AudioClip[4];
    public int currentBearCount = 0;
    public GameObject bearCountTextObject;
    private int footSoundInt;
    private float timeSinceLastFootstep;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		animator.Play("BearIdle");
        footSoundInt = 0;
        timeSinceLastFootstep = 0.0f;
		//gameObject.transform.localPosition = new Vector3(8.38f,1.3418f,50.2f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Application.loadedLevelName == "Main" && player.GetComponent<mobileMovement>().bearAwake == true)
        {
            if (timeSinceLastFootstep > 0.5f)
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

                timeSinceLastFootstep = 0.0f;
            }

            timeSinceLastFootstep = timeSinceLastFootstep + Time.deltaTime;
        }
        if (Application.loadedLevelName == "Main")
        {
            bearCountTextObject.GetComponent<UnityEngine.UI.Text>().text = "Bears: " + currentBearCount.ToString() + "/10";
        }
	}

	public void BearAwake()
	{
		//GetComponent<AudioSource>().PlayOneShot(bearAlertSound);
        GetComponent<AudioSource>().PlayOneShot(bearAlertGrowlSound);
		animator.Play("BearTurnLook");
		//StartCoroutine(WaitAndCallback(animator.GetCurrentAnimationClipState(0).Length));
		StartCoroutine(TurnAndLookWaitAndCallback(0.5f));



		//animator.SetInteger ("BearState", 21);
		//yield return new WaitForSeconds (0.5f);
		//animator.Play("BearFollow");
		//StartCoroutine (BearSmoothMove ());
	}

	IEnumerator TurnAndLookWaitAndCallback(float waitTime){
		yield return new WaitForSeconds(waitTime);
		animator.Play("BearFollow");
		StartCoroutine (BearSmoothMove ());
	}

	IEnumerator TurnBackWaitAndCallback(float waitTime){
		yield return new WaitForSeconds(waitTime);
		//animator.Play("BearIdle");
		StartCoroutine (BearSmoothReverseMove ());
        
	}

	IEnumerator BearSmoothMove()
	{
		// Make the bear follow the player slowly


		//yield return new WaitForSeconds(animator.GetCurrentAnimationClipState(0).Length);
		yield return new WaitForSeconds(1.0f);
		Vector3 startingPos = transform.position;
		float timeCounter = 0.0f;
		Vector3 fencePosition = new Vector3(9,1.3f,50);
		while (timeCounter < 0.95f && safeZone.GetComponent<SafeZone>().inSafeZone == false)
		{
			timeCounter += Time.deltaTime * (Time.timeScale/transitionDuration);
			transform.position = Vector3.Lerp(startingPos, fencePosition, timeCounter);

			//Debug.Log(transform.position);
			yield return 0;
		}
	}

	public void BearSleep()
	{
		animator.Play("BearTurnBack");
		StartCoroutine(TurnBackWaitAndCallback(0.55f));
        //animator.Play("BearIdle");
		}

	public IEnumerator BearSmoothReverseMove()
	{
		// Take current Bear position and send him back to his bed
		animator.Play ("BearWalkBack");
		Vector3 startingPos = transform.position;
		float timeCounter = 0.0f;
		while (timeCounter < 0.9f)
		{
			timeCounter += Time.deltaTime * (Time.timeScale/transitionDuration) * 4;
			
			transform.position = Vector3.Lerp(startingPos, bearStartPos, timeCounter);
			yield return 0;
		}
        animator.Play("BearIdle");
	}
	


	public void BearRun()
	{

	}
}
