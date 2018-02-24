using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {
    public int health;
	public GameObject explosion;
    public GameObject damage_feedback;

	// Use this for initialization
	void Start () {


	}
	//Hello Joe

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Pew") {
            health--;
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
                if(damage_feedback != null)
                {
                    print("NOT NULL");
                }
                Vector3 position = this.transform.position;
                position.z = 5;
                GameObject feedback_inst = Instantiate(damage_feedback, position, Quaternion.identity) as GameObject;
                Destroy(feedback_inst, 1);
            }
		}


	}
}