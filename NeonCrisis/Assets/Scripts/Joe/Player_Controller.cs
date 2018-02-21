using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float move_speed;
    Rigidbody2D rigidbody;





	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        Handle_User_Input();
	}

    void Handle_User_Input()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(hor * move_speed, ver * move_speed, 0);
        rigidbody.velocity = move;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon_Pickup pickup = collision.GetComponent<Weapon_Pickup>();
        if(pickup != null)
        {
            //shot_delay *= pickup.weapon_speed_multiplier;
            Destroy(pickup.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Basic_Bullet>() != null)
        {
            Destroy(this.gameObject);
        }
    }
    
}
