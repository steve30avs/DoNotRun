using UnityEngine;
using System.Collections;

public class DoorClose : MonoBehaviour {

    public AudioClip footSound = new AudioClip();
    public bool soundPlayed;
    private float timeSinceLoad;

	// Use this for initialization
	void Start () {
        timeSinceLoad = 0.0f;
        soundPlayed = false;
        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 0, 0), "easetype", iTween.EaseType.easeInOutSine, "time", 3.0f));
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("DoorClose"), "time", 2.5f, "easetype", iTween.EaseType.easeOutSine));
	}
	
	// Update is called once per frame
	void Update () {

        // Play sound after 3 seconds, then stop updating timer
        if (timeSinceLoad < 3.2f)
        {
            timeSinceLoad = timeSinceLoad + Time.deltaTime;
        }
        if (timeSinceLoad > 2.9f && soundPlayed == false)
        {
            this.GetComponent<AudioSource>().PlayOneShot(footSound);
            soundPlayed = true;
        }
	}
}
