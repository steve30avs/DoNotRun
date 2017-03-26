using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class MainMenu : MonoBehaviour {

//	private float ScreenWidth = (float)Screen.width;
//	private float ScreenHeight = (float)Screen.height;
	private Vector3 alteredCamRot = new Vector3(5,-30,0);
	private GameObject bear;

//	private static float nativeWidth = 960.0f;
//	private static float nativeHeight = 640.0f;

	public Texture2D buttonAbout;
	public Texture2D buttonHighScore;
	public Texture2D buttonSettings;
	public Texture2D buttonStart;
    public BannerView bannerView;

	void Start()
	{
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath ("CameraPath"),"time",7, "easetype", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.pingPong));
		bear = GameObject.Find("PlainBear");
	}
	void Update()
	{
		//alteredCamRot = bear.transform.position + new Vector3 (0, -25, 0);
		transform.LookAt(bear.transform.position);
		transform.Rotate( alteredCamRot,Space.World);
	}

	void OnGUI () {
		// Make a background box

//		//set up scaling
//		float adjustedWidth = Screen.width / nativeWidth;
//		float adjustedHeight = Screen.height / nativeHeight;
//		GUI.matrix = Matrix4x4.TRS (new Vector3(0,0,0), Quaternion.identity, new Vector3(adjustedWidth, adjustedHeight, 1));
//		
//		//now create your GUI normally, as if you were in your native resolution
//		//The GUI.matrix will scale everything automatically.
//
//		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
//		if(GUI.Button(new Rect(150,175,400,75), buttonStart)) {
//			Application.LoadLevel("Main");
//		}
//		
//		// Make the second button.
//		if(GUI.Button(new Rect(150,275,400,75), buttonSettings)) {
//
//		}
//
//		// Make the second button.
//		if(GUI.Button(new Rect(150,375,400,75), buttonHighScore)) {
//
//		}
//
//		// Make the second button.
//		if(GUI.Button(new Rect(150,475,400,75), buttonAbout)) {
//			
//		}
	}
}
