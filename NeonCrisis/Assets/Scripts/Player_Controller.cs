using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public float move_speed;
	Rigidbody2D rigidbody;
	public Transform shoot_position;
	public GameObject bullet_object;
	public float next_shot_delay;

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
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	}

	void Fire()
	{
		Instantiate(bullet_object, shoot_position.position, Quaternion.identity);
	}
}