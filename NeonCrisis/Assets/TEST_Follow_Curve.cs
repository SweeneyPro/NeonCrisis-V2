using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Follow_Curve : MonoBehaviour {

    public List<GameObject> curve_objects;

    public List<GameObject> instantiated_curves;
    public List<BezierCurve> curves;

    public BezierCurve current_curve;
    int curve_index;
    public float speed;

    public void Set_Speed(float _speed)
    {
        speed = _speed;
    }

    void Setup()
    {
        Instantiate_Curves();
        Get_Curve_Components();
        Line_First();
    }

    public void Add_Curve(GameObject _curve_object, int _index)
    {
        curve_objects.Add(_curve_object);
    }

    void Instantiate_Curves()
    {
        for(int i = 0; i < curve_objects.Count; i++)
        {
            instantiated_curves.Add(Instantiate(curve_objects[i], this.transform.position, Quaternion.identity) as GameObject);
        }
    }

    void Get_Curve_Components()
    {
        for(int i=  0; i < instantiated_curves.Count; i++)
        {
            curves.Add(instantiated_curves[i].GetComponent<BezierCurve>());
        }
    }

    void Line_First()
    {
        Vector3 init_diff = curves[0].GetPointAt(0) - instantiated_curves[0].transform.position;
        instantiated_curves[0].transform.position = instantiated_curves[0].transform.position - init_diff;

        Vector3 last_end = curves[0].GetPointAt(1);

        Vector3 sec_diff = curves[1].GetPointAt(0) - instantiated_curves[0].transform.position;
        instantiated_curves[1].transform.position = last_end;
        instantiated_curves[1].transform.position = instantiated_curves[1].transform.position;
    }


    public void Begin()
    {
        Setup();
    }

    private void FixedUpdate()
    {
        Move_Along_Curve();
    }

    void Move_Along_Curve()
    {
        
    }

    void Switch_Curve()
    {

    }

}
