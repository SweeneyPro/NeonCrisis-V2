using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public float drain_speed;
    SpriteRenderer shield_renderer;
    CircleCollider2D shield_collider;
    public bool active;

	// Use this for initialization
	void Start () {
        shield_renderer = GetComponent<SpriteRenderer>();
        shield_collider = GetComponent<CircleCollider2D>();
        shield_collider.enabled = false;
        shield_renderer.enabled = false;
	}

    private void Update()
    {
        this.transform.position = this.transform.parent.transform.position;
    }

    public void Activate()
    {
        if(Score_Updater.score_updater != null && Score_Updater.score_updater.score > 10)
        {
            Score_Updater.score_updater.Take_Score((int)(drain_speed * Time.deltaTime));
            shield_collider.enabled = true;
            shield_renderer.enabled = true;
            active = true;
        }
        else
        {
            Deactivate();
        }
    }

    public void Deactivate()
    {
        shield_collider.enabled = false;
        shield_renderer.enabled = false;
        active = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Score_Updater.score_updater != null)
        {
            Score_Updater.score_updater.Take_Score(10);
        }
    }

}
