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
    bool running = false;

    /*
     * NEED TO INSTANTIATE CURVES SOMEWHERE AT SOME POINT!!!!!
     */

    public void Add_Curve(GameObject _curve_object)
    {
        BezierCurve bezier_curve = _curve_object.GetComponent<BezierCurve>();
        curves.Add(bezier_curve);
    }

    public void Begin()
    {
        end_point = current_curve.GetPointAt(1);
        //instantiate curve
        running = true;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (running == true)
        {
            time += Time.deltaTime;
            if (current_curve != null)
            {
                Vector3 target = current_curve.GetPointAt((time - time_offset) * (speed * Time.deltaTime));
                this.transform.position = target;
                if (this.transform.position == end_point)
                {
                    curve_index++;
                    current_curve = curves[curve_index];
                    time = 0;
                }
            }
        }
	}

    void Switch_Curve()
    {
        //instantiate new curve and set as current
    }
}
