using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

	public GameObject bear;
	public GameObject player;
	public bool inSafeZone = false;

	void Start()
	{
		//bear = GameObject.Find("SpriteBear");
		//player = GameObject.Find ("First Person Controller");
	}
	void OnTriggerEnter(Collider player)
	{
        // Only trigger if it's the player colliding with the box and the bear is already angry
        if (player.name == "First Person Controller" && player.GetComponent<mobileMovement>().bearAwake == true)
        {
            inSafeZone = true;
            bear.GetComponent<BearBehaviour>().BearSleep();
            player.GetComponent<mobileMovement>().bearAwake = false;
        }

	}
	void OnTriggerExit(Collider player)
	{
		inSafeZone = false;
	}
}
