using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {

	GameObject Explosion;

	// Use this for initialization
	void Start () {


	}
	
	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Pew") {

			Instantiate (Resources.Load ("Explosion_1"), transform.position, Quaternion.identity);
			GameObject Explosion = Instantiate (Resources.Load ("Explosion_1"), this.transform.position, Quaternion.identity)  as GameObject;

			Destroy(gameObject);
		}


	}
}