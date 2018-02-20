using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class Enemy_Generation : MonoBehaviour{

    public static void Generate_Enemy(string _name, Sprite _sprite, float _collider_radius, Enemy_Information_Section[] _enemy_information)
    {
        
        GameObject enemy_object = new GameObject(_name);
        enemy_object.AddComponent<Rigidbody2D>();
        SpriteRenderer sprite_renderer = enemy_object.AddComponent<SpriteRenderer>();
        sprite_renderer.sprite = _sprite;
        Animator animator = enemy_object.AddComponent<Animator>();
        CircleCollider2D collider = enemy_object.AddComponent<CircleCollider2D>();
        collider.radius = _collider_radius;
        enemy_object.layer = LayerMask.NameToLayer("Enemy");

        Enemy_base enemy_base = enemy_object.AddComponent<Enemy_base>();
        enemy_base.Enemy_Constructor(_name, _sprite, _collider_radius);
        for(int i = 0; i < _enemy_information.Length; i++)
        {
            enemy_base.EnemyBehaviourConstructor(_enemy_information[i].move_speed, _enemy_information[i].fire_rate, _enemy_information[i].fire_speed, _enemy_information[i].start_time, _enemy_information[i].health, _enemy_information[i].animation_controller, _enemy_information[i].fire_pattern_type, null /*fix when ready*/, null /*fix when ready*/);
        }




        PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/Enemies/Individual/" + _name + ".prefab", enemy_object); //add checking to make sure it doesn't already exist
        DestroyImmediate(enemy_object);
    }
}
