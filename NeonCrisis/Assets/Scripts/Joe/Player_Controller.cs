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
    public Shield shield;

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
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(hor * move_speed, ver * move_speed, 0);
        rigidbody.velocity = move;

        if(Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
        if(Input.GetKey(KeyCode.Z))
        {
            if(shield != null)
            {
                print("ACTIVATE");
                shield.Activate();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Z))
        {
            if(shield != null)
            {
                shield.Deactivate();
            }
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
        if (collision.gameObject.GetComponent<Basic_Bullet>() != null && shield != null && shield.active == false)
        {
            //Destroy(this.gameObject);
            Score_Updater.score_updater.score = 0;
        }
    }
    
}
