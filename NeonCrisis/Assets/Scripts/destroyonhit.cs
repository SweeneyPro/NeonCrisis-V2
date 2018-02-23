using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonhit : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {

            if (explosion != null)
            {
                GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(explosion_inst, 4);

            }
            Destroy(gameObject);
        }

	}
}
