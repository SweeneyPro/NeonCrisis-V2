using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimation : MonoBehaviour {

    [SerializeField]
    private Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("p"))
        {
            anim.SetBool("Active", true);
            anim.speed = 1;
            Debug.Log("Active");
        }
        else if(Input.GetKeyUp("p"))
        {
            anim.SetBool("Active", false);
            anim.speed = 1;
            Debug.Log("Deactive");
        }
		
	}
}
