using UnityEngine;
using System.Collections;

public class keyboardPCMovement : MonoBehaviour {
	
//	public float transitionDuration = 0.5f;
//	public float currentKey = 0.0f;
//	public float lastKeyPressed = 10.0f;
//	public Vector3 newPosition = new Vector3(3.0f,0,0);
//	public float timeSinceStep = 5.0f;
//	public bool bearAwake = false;
//	public Vector3 touchPosition;
//	GameObject bear;
//	private int SCREEN_HEIGHT = Screen.height;
//	private int SCREEN_WIDTH = Screen.width;
//	private float rightFootPos;
//	private float leftFootPos;
//	
//	// Use this for initialization
//	void Start () {
//		bear = GameObject.Find ("SpriteBear");
//		rightFootPos = (SCREEN_WIDTH / 4) * 3;
//		leftFootPos = SCREEN_WIDTH / 4;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
//		{
//		//touchPosition = Input.GetTouch(0).deltaPosition;
//		//Debug.Log(touchPosition.ToString());
//			touchPosition = Input.mousePosition;
//
//			if (touchPosition.x < leftFootPos)
//			{
//				Debug.Log("LEFT FOOT");
//			}
//			else if (touchPosition.x > rightFootPos)
//			{
//				Debug.Log("RIGHT FOOT");
//			}
//			//Debug.Log(touchPosition.ToString());
//		}
//		currentKey = Input.GetAxis("Horizontal");
//		
//		if ((currentKey > 0.0 && lastKeyPressed < 0.0) || (currentKey < 0.0 && lastKeyPressed > 0.0))
//		{
//			if (bearAwake == false)
//			{
//				StartCoroutine(SmoothMove());
//			}
//			else if (bearAwake == true)
//			{
//				StartCoroutine(ReverseSmoothMove());
//			}
//			BearHandler();
//		}
//		
//		if (currentKey != 0.0)
//		{
//			lastKeyPressed = currentKey;
//		}
//		timeSinceStep = timeSinceStep + Time.deltaTime;
//	}
//	
//	IEnumerator SmoothMove()
//	{
//		Vector3 startingPos = transform.position;
//		float timeCounter = 0.0f;
//		while (timeCounter < 0.3f)
//		{
//			timeCounter += Time.deltaTime * (Time.timeScale/transitionDuration);
//			
//			transform.position = Vector3.Lerp(startingPos, startingPos + newPosition, timeCounter);
//			yield return 0;
//		}
//	}
//
//	IEnumerator ReverseSmoothMove()
//	{
//		Vector3 startingPos = transform.position;
//		float timeCounter = 0.0f;
//		while (timeCounter < 0.3f)
//		{
//			timeCounter += Time.deltaTime * (Time.timeScale/transitionDuration);
//			
//			transform.position = Vector3.Lerp(startingPos, startingPos - newPosition, timeCounter);
//			yield return 0;
//		}
//	}
//
//	void BearHandler()
//	{
//		if (timeSinceStep < 0.5) {
//			Debug.Log("TOO FAST");
//			bear.GetComponent<BearBehaviour>().BearAwake();
//			bearAwake = true;
//		}
//		timeSinceStep = 0;
//	}
	
}
