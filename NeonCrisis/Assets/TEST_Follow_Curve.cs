using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Follow_Curve : MonoBehaviour {
    public BezierCurve[] curves;
    public float speed;
    int curve_index = 0;
    BezierCurve current_curve;
    Vector3 end_point;

	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(current_curve != null)
        {
            Vector3 target = current_curve.GetPointAt(Time.fixedTime * (speed * Time.deltaTime));
            this.transform.position = target;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
            //this.transform.position = bezier_curve.GetPointAt(Time.fixedTime / (speed * Time.deltaTime));
            if(this.transform.position == end_point)
            {
                curve_index++;
            }
        }
	}
}
