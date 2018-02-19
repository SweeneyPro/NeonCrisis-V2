using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
public class Enemy_base : MonoBehaviour {

    

    public enum Fire_Pattern_Type { forward, circle, loop, homing };

    public struct Enemy_Information_Instance
    {
        public float move_speed, fire_rate, fire_speed, start_time;
        public int health;
        public AnimatorController animation_controller;

        public Fire_Pattern_Type fire_pattern_type;
    
    }

    public string enemy_name;
    public Sprite enemy_sprite;
    float collider_size;

    public float move_speed, fire_rate, fire_speed, start_time;
    public int health;
    public AnimatorController animation_controller;

    public Fire_Pattern_Type fire_pattern_type;
    List<float> times = new List<float>();
    int curent_time_index = 0; // dont need to record index if we removing elements anyway right?

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

        if(timer > times[0])
        {
            timer = 0;
            
            move_speed = BehaviourSets[0].move_speed;
            fire_rate = BehaviourSets[0].fire_rate;
            fire_speed = BehaviourSets[0].fire_speed;
            start_time = BehaviourSets[0].start_time;
            health = BehaviourSets[0].health;
            animation_controller = BehaviourSets[0].animation_controller;
            fire_pattern_type = BehaviourSets[0].fire_pattern_type;

            times.RemoveAt(0);
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

    public virtual void EnemyBehaviourConstructor(float movespeed, float firerate, float firespeed, float starttime, int health, AnimatorController animationcontroller, Fire_Pattern_Type firepatterntype)
    {
        Enemy_Information_Instance behaviour_set_instance;
        behaviour_set_instance.move_speed = movespeed;
        behaviour_set_instance.fire_rate = firerate;
        behaviour_set_instance.fire_speed = firespeed;
        behaviour_set_instance.start_time = starttime;
        behaviour_set_instance.health = health;
        behaviour_set_instance.animation_controller = animationcontroller;
        behaviour_set_instance.fire_pattern_type = firepatterntype;

        BehaviourSets.Add(behaviour_set_instance);
    }
}
