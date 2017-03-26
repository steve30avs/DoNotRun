using UnityEngine;
using System.Collections;

public class titleScaler : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GUIText titleText = this.GetComponent<GUIText>();
        if (titleText.name == "scoreLoseText")
        {
            titleText.fontSize = (int)((Mathf.Min(Screen.height, Screen.width)) / 15.52f);
        }
        else if (titleText.name == "winText")
        {
            titleText.fontSize = (int)((Mathf.Min(Screen.height, Screen.width)) / 15.52f);
        }
        else
        {
            titleText.fontSize = (int)((Mathf.Min(Screen.height, Screen.width)) / 6.52f);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
