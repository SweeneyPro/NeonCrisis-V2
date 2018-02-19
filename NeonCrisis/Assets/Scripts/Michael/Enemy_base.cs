using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Animations;
public class Enemy_base : MonoBehaviour {

    [System.Serializable]
    public struct Enemy_Information_Instance
    {
        public float move_speed, fire_rate, fire_speed, start_time;
        public int health;
        public AnimatorController animation_controller;
        public string fire_pattern_type;
        public GameObject bullet_type;
        public Base_Fire_Pattern fire_pattern;

    }

    public string enemy_name;
    public Sprite enemy_sprite;
    float collider_size;

    public float move_speed, fire_rate, fire_speed, start_time;
    public int health;
    public AnimatorController animation_controller;

    public string fire_pattern_type;
    List<float> times = new List<float>();
    int curent_time_index = 0; // dont need to record index if we removing elements anyway right?
    Base_Fire_Pattern fire_pattern;
    float timer = 0;

    
    public List<Enemy_Information_Instance> BehaviourSets = new List<Enemy_Information_Instance>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Assign_Local_Variables();
		//check time against start times
            //if time > start time
                //switch values with struct variables
        
        //go through variables doing shit
	}

    void Assign_Local_Variables()
    {
        timer += Time.deltaTime;
        
        if(timer > 5)
        {
            timer = 0;
            
            move_speed = BehaviourSets[0].move_speed;
            fire_rate = BehaviourSets[0].fire_rate;
            fire_speed = BehaviourSets[0].fire_speed;
            start_time = BehaviourSets[0].start_time;
            health = BehaviourSets[0].health;
            animation_controller = BehaviourSets[0].animation_controller;
            GetComponent<Animator>().runtimeAnimatorController = animation_controller;
            fire_pattern_type = BehaviourSets[0].fire_pattern_type;

            //times.RemoveAt(0);
            BehaviourSets.RemoveAt(0);
        }
        //assign from current_time_index
    }

    

    public void Enemy_Constructor(string enemyname, Sprite enemySprite, float collidersize)
    {
        enemy_name = enemyname;
        enemy_sprite = enemySprite;
        collider_size = collidersize;
    }

    public virtual void EnemyBehaviourConstructor(float movespeed, float firerate, float firespeed, float starttime, int health, AnimatorController animationcontroller, string _fire_pattern_type, GameObject bullettype, Base_Fire_Pattern firepattern)
    {
        Enemy_Information_Instance behaviour_set_instance;
        behaviour_set_instance.move_speed = movespeed;
        behaviour_set_instance.fire_rate = firerate;
        behaviour_set_instance.fire_speed = firespeed;
        behaviour_set_instance.start_time = starttime;
        behaviour_set_instance.health = health;
        behaviour_set_instance.animation_controller = animationcontroller;
        behaviour_set_instance.fire_pattern_type = _fire_pattern_type;
        behaviour_set_instance.bullet_type = bullettype;
        behaviour_set_instance.fire_pattern = firepattern;
        BehaviourSets.Add(behaviour_set_instance);
    }
}
