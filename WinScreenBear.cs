using UnityEngine;
using System.Collections;

public class WinScreenBear : MonoBehaviour {

    public GameObject bear;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = bear.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(FinishAnimation ());
	}

        IEnumerator FinishAnimation()
        {
            //animator.
            yield return new WaitForSeconds(2);
            animator.Play("BearNet");
        }

}
