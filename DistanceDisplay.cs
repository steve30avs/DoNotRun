using UnityEngine;
using System.Collections;

public class DistanceDisplay : MonoBehaviour {

	public float safeDistance;
	public float bearDistance;
	public GameObject bear;
	public GameObject player;
	public GameObject safeZone;
	public float timeSinceStep;
//	public Texture walkIcon;
	private GUIStyle quickStyle = new GUIStyle();
//	private RaycastHit2D spriteRay;
	public Camera mainCamera;

	void Start()
	{
		mainCamera = this.GetComponent<Camera>();
		quickStyle.normal.textColor = Color.black;
	}
	void Update()
	{
		safeDistance = player.GetComponent<PlayerBehaviour>().GetSafeZoneDistance();
		bearDistance = player.GetComponent<PlayerBehaviour>().GetBearDistance();
//		timeSinceStep = player.GetComponent<mobileMovement>().timeSinceStep;
		//safeDistance = Vector3.Distance(player.transform.position, safeZone.transform.position);
		//bearDistance = Vector3.Distance(player.transform.position, bear.transform.position);

	}

	void OnGUI()
	{
		//GUI.DrawTexture(new Rect(10, 10, 60, 60), walkIcon, ScaleMode.ScaleToFit, true, 10.0f);
//		GUI.Label(new Rect(10,10,200,100),"Safe Zone Distance: " + safeDistance.ToString(),quickStyle);
//		GUI.Label(new Rect(10,30,200,100),"Bear Distance: " + bearDistance.ToString(),quickStyle);
//		GUI.Label(new Rect (10, 50, 200, 100), "Step Time: " + timeSinceStep.ToString (), quickStyle);

	}

}
