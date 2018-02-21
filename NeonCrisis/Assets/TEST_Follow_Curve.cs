using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Follow_Curve : MonoBehaviour {
    public List<GameObject> curve_objects = new List<GameObject>();
    List<BezierCurve> curves = new List<BezierCurve>();
    public float speed;
    int curve_index = 0;
    BezierCurve current_curve;
    Vector3 end_point;
    float time_offset;
    float time;

    public void Add_Curve(GameObject _curve_object)
    {
        BezierCurve bezier_curve = _curve_object.GetComponent<BezierCurve>();
        curves.Add(bezier_curve);
    }

	// Use this for initialization
	void Start () {
        current_curve = curves[curve_index];
        end_point = current_curve.GetPointAt(1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time += Time.deltaTime;
		if(current_curve != null)
        {
            Vector3 target = current_curve.GetPointAt((time - time_offset) * (speed * Time.deltaTime));
            this.transform.position = target;
            if(this.transform.position == end_point)
            {
                curve_index++;
                current_curve = curves[curve_index];
                time = 0;
            }
        }
	}
}
