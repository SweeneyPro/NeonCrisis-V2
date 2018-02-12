using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classy_class : MonoBehaviour {

	public GameObject pew;
	public float cooldown;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

		cooldown += Time.deltaTime;

		if (cooldown > 1) {
			Instantiate (pew, transform.position, Quaternion.identity);
			cooldown = 0;

		}

	}
}
