using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Spawner : MonoBehaviour {
    public enum spawn_types { enemy_left_short, enemy_right_short, enemy_right_mid, enemy_left_mid, enemy_right_long, enemy_left_long, enemy_left_shallow, enemy_right_shallow, enemy_left_zig_zag, enemy_right_zig_zag};
    public spawn_types spawn_type;
    public GameObject enemy_to_spawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(enemy_to_spawn, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (spawn_type == spawn_types.enemy_right_long)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Right_Long");
        }
        else if(spawn_type == spawn_types.enemy_left_long)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Left_Long");
        }
        else if(spawn_type == spawn_types.enemy_left_short)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Left_Short");
        }
        else if (spawn_type == spawn_types.enemy_right_short)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Right_Short");
        }
        else if (spawn_type == spawn_types.enemy_left_mid)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Left_Mid");
        }
        else if (spawn_type == spawn_types.enemy_right_mid)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Right_Mid");
        }
        else if(spawn_type == spawn_types.enemy_left_zig_zag)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Left_Zig_Zag");
        }
        else if(spawn_type == spawn_types.enemy_right_zig_zag)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Right_Zig_Zag");
        }
        else if (spawn_type == spawn_types.enemy_left_shallow)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Left_Shallow");
        }
        else if (spawn_type == spawn_types.enemy_right_shallow)
        {
            Gizmos.DrawIcon(this.transform.position, "Enemy_Right_Shallow");
        }

    }

    
}
