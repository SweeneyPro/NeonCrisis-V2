using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonhit : MonoBehaviour {

    public GameObject explosion;
    int health = 24;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Pew") {

            if (explosion != null)
            {
                GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(explosion_inst, 4);
            }

            health -= 3;
            print(health);

            if(health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

	}
}
