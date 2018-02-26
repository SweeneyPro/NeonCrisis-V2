using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Shot : Shot_Pattern {

    public float radius;
    public int angle_skip;

    public override void Shoot()
    {
        base.Shoot();
        for (int i = 0; i < 360 / angle_skip; i += angle_skip)
        {
            Vector2 xy = new Vector2(shot_point.transform.position.x + radius * Mathf.Cos(i), shot_point.transform.position.y + radius * Mathf.Sin(i));
            Vector2 direction = xy - (Vector2)this.transform.position;
            GameObject bullet_inst = Instantiate(bullet, xy, Quaternion.identity) as GameObject;
            bullet_inst.transform.up = direction;
        }

    }
}
