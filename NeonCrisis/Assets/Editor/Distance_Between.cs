using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Distance_Between : MonoBehaviour {

    [MenuItem("Tools/Measure Distance")]
	public static void Measure_Distance()
    {
        GameObject[] objects = Selection.gameObjects;
        List<Vector3> positions = new List<Vector3>();
        List<float> widths = new List<float>();
        float sum = 0;
        for(int i = 0; i < objects.Length; i++)
        {
            positions.Add(objects[i].transform.position);
            SpriteRenderer renderer = objects[i].GetComponent<SpriteRenderer>();
            widths.Add(renderer.size.x);
            sum += widths[i];
        }
        sum /= 2;
        float dist = Vector3.Distance(positions[0], positions[1]);
        print(dist - sum);

    }
}
