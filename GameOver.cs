using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	private float ScreenWidth = (float)Screen.width;
	private float ScreenHeight = (float)Screen.height;

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(ScreenWidth*0.1f,ScreenHeight*0.1f,ScreenWidth*0.8f,ScreenHeight*0.65f), "I told you not to run");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(ScreenWidth*0.2f,ScreenHeight*0.25f,ScreenWidth*0.6f,ScreenHeight*0.1f), "Retry")) {
			Application.LoadLevel("Main");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(ScreenWidth*0.2f,ScreenHeight*0.4f,ScreenWidth*0.6f,ScreenHeight*0.1f), "Back to Main Menu")) {
			Application.LoadLevel("Startup");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(ScreenWidth*0.2f,ScreenHeight*0.55f,ScreenWidth*0.6f,ScreenHeight*0.1f), "Submit High Score")) {
			
		}

	}
}
