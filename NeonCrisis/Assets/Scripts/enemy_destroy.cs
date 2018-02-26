using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {

	public GameObject explosion, pickup;

	// Use this for initialization
	void Start () {


	}
	
	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Pew") {

            if (explosion != null)
            {
                GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(explosion_inst, 4);
            }
            if(Random.Range(0, 3) == 1 && pickup != null)
            {
                Instantiate(pickup, this.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
		}


	}
}