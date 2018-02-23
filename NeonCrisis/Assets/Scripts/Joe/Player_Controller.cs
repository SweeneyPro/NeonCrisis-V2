using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float move_speed;
    public Transform shot_position;
    Rigidbody2D rigidbody;
    public GameObject bullet;
    public float shot_delay;
    float next_shot_time;

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
        if(Input.GetKey(KeyCode.Space))
        {
            Fire();
        }

    }

    void Fire()
    {
        if(bullet != null && shot_position != null && (Time.fixedTime > next_shot_time))
        {
            //do firing
            Instantiate(bullet, shot_position.position, this.transform.rotation);
            next_shot_time = Time.fixedTime + shot_delay;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon_Pickup pickup = collision.GetComponent<Weapon_Pickup>();
        if(pickup != null)
        {
            shot_delay *= pickup.weapon_speed_multiplier;
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
