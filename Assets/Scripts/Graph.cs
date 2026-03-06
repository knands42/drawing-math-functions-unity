using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    
    [SerializeField, Range(10, 100)]
    public int resolution = 10;

    [SerializeField, Range(0, 2)] 
    public int function;
    
    private Transform[] points;

    private void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        var position = Vector3.zero;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            
            position.x = (i  * step - 1f);
            point.localPosition = position;
            point.localScale = scale;
            
            point.SetParent(transform, false);
        }
    }

    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            if (function == 0)
            {
                position.y = FunctionLib.Wave(position.x, time);
            }
            else if (function == 1)
            {
                position.y = FunctionLib.MultiWave(position.x, time);
            }
            else
            {
                position.y = FunctionLib.Ripple(position.x, time);
            }
            point.localPosition = position;
        }
    }
}
