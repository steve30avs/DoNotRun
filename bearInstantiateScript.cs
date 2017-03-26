using UnityEngine;
using System.Collections;

public class bearInstantiateScript : MonoBehaviour {

	public GameObject bearPrefab;

	// Use this for initialization
	void Start () {
		Instantiate(bearPrefab, new Vector3(31.3982f,2.362908f,50.31652f), Quaternion.Euler(0,90,0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
