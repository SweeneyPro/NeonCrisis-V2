using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {

	public GameObject explosion, pickup;
    public int health;

	// Use this for initialization
	void Start () {
        health = 2;

	}
	
	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Pew") {            
            if(Random.Range(0, 5) == 1 && pickup != null)
            {
                Instantiate(pickup, this.transform.position, Quaternion.identity);
            }
            if (health <= 0)
            {
                if (explosion != null)
                {
                    GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                    Destroy(explosion_inst, 4);
                }
                Destroy(this.gameObject);
            }
            else
            {
                health--;
            }
		}
	}
}