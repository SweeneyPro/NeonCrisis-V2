using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class Enemy_Generation : MonoBehaviour{

    public static void Generate_Enemy(string _name, Sprite _sprite, AnimatorController _controller, Level_Generation_Utility.Fire_Pattern_Type _fire_pattern_type, float _fire_speed, float _collider_radius, float _move_speed)
    {
        GameObject enemy_object = new GameObject(_name);
        enemy_object.AddComponent<Rigidbody2D>();
        SpriteRenderer sprite_renderer = enemy_object.AddComponent<SpriteRenderer>();
        sprite_renderer.sprite = _sprite;
        Animator animator = enemy_object.AddComponent<Animator>();
        animator.runtimeAnimatorController = _controller;
        CircleCollider2D collider = enemy_object.AddComponent<CircleCollider2D>();
        collider.radius = _collider_radius;
        enemy_object.layer = LayerMask.NameToLayer("Enemy");
        //set speed
        //add fire pattern control //currenly doesn't do anything
        switch(_fire_pattern_type)
        {
            case Level_Generation_Utility.Fire_Pattern_Type.forward:
                //add forward shot script
                break;
            case Level_Generation_Utility.Fire_Pattern_Type.circle:
                //add circle shot script
                break;
            case Level_Generation_Utility.Fire_Pattern_Type.loop:
                //add loop shot script
                break;
            case Level_Generation_Utility.Fire_Pattern_Type.homing:
                //add homing shot script
                break;
        }
        PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/Enemies/Individual/" + _name + ".prefab", enemy_object); //add checking to make sure it doesn't already exist
        DestroyImmediate(enemy_object);
    }
}
