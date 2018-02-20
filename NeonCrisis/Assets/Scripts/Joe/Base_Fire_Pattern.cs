using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Fire_Pattern : MonoBehaviour
{

    public enum fire_patterns { forward, circle, loop, homing };
    public fire_patterns fire_pattern;
    public GameObject bullet;
    float next_fire_time, fire_delay;

    // Use this for initialization
    void Start()
    {
        fire_delay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > next_fire_time)
        {
            Fire();
            next_fire_time = Time.fixedTime + fire_delay;
        }
    }

    public void Fire()
    {
        if (fire_pattern == fire_patterns.forward)
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }
        else if (fire_pattern == fire_patterns.circle)
        {
            Fire_Circle();
        }
        else if (fire_pattern == fire_patterns.homing)
        {

        }
        else if (fire_pattern == fire_patterns.loop)
        {

        }
    }

    void Fire_Circle()
    {

    }

    IEnumerator Fire_Loop()
    {
        yield return new WaitForSeconds(0);
    }

    IEnumerator Fire_Homing()
    {
        yield return new WaitForSeconds(0);
    }
}
