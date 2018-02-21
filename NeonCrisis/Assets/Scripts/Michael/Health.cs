using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    Enemy_base EnemyBase;


    public void DealDamage(int damage)
    {
        EnemyBase.health -= damage;
    }

    private void CheckHealth()
    {
        if(EnemyBase.health <= 0)
        {
            Destroy(gameObject);

        }
    }
}
