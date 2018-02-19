using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

struct Enemy_Information_Section
{   
    public float move_speed, fire_rate, fire_speed, start_time;
    public int health;
    public AnimatorController animation_controller;
    public Enemy_Generation_Utility.Fire_Pattern_Type fire_pattern_type;
}

public class Enemy_Generation_Utility : EditorWindow {

    Enemy_Information_Section[] enemy_sections;
    public enum Fire_Pattern_Type { forward, circle, loop, homing };

    public string enemy_name;
    public Sprite enemy_sprite;
    float collider_size;

    int amount_of_sections;
    Vector2 scroll_position;


    private void OnGUI()
    {
        GUILayout.BeginVertical();
        scroll_position = GUILayout.BeginScrollView(scroll_position);
        Display_Options();
        if(GUILayout.Button("Generate Enemy"))
        {
            for (int i = 0; i < enemy_sections.Length; i++)
            {
                Enemy_Generation.Generate_Enemy(enemy_name, enemy_sprite, enemy_sections[i].animation_controller, enemy_sections[i].fire_pattern_type, enemy_sections[i].fire_speed, collider_size, enemy_sections[i].move_speed);
            }
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }

    void Display_Options()
    {
        amount_of_sections = EditorGUILayout.IntField("Amount Of Sections", amount_of_sections);

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        enemy_name = EditorGUILayout.TextField("Enemy Name", enemy_name);
        enemy_sprite = (Sprite)EditorGUILayout.ObjectField("Enemy Sprite", enemy_sprite, typeof(Sprite), allowSceneObjects: false);
        collider_size = EditorGUILayout.FloatField("Collider Size", collider_size);

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        if (enemy_sections == null)
        {
            if(amount_of_sections != 0)
            {
                enemy_sections = new Enemy_Information_Section[amount_of_sections];
            }
        }

        if (enemy_sections != null)
        {
            for (int i = 0; i < enemy_sections.Length; i++)
            {
                enemy_sections[i].start_time = EditorGUILayout.FloatField("Start Time", enemy_sections[i].start_time);
                enemy_sections[i].move_speed = EditorGUILayout.FloatField("Move Speed", enemy_sections[i].move_speed);
                enemy_sections[i].fire_rate = EditorGUILayout.FloatField("Fire Rate", enemy_sections[i].fire_rate);
                enemy_sections[i].fire_speed = EditorGUILayout.FloatField("Fire Speed", enemy_sections[i].fire_speed);
                enemy_sections[i].animation_controller = (AnimatorController)EditorGUILayout.ObjectField("Enemy Animation Controller", enemy_sections[i].animation_controller, typeof(AnimatorController), allowSceneObjects: false);
                enemy_sections[i].health = EditorGUILayout.IntField("Health", enemy_sections[i].health);
                enemy_sections[i].fire_pattern_type = (Fire_Pattern_Type)EditorGUILayout.EnumPopup("Fire Pattern Type", enemy_sections[i].fire_pattern_type);
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            }
        }
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

    }
}
