using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    
    [SerializeField, Range(10, 100)]
    public int resolution = 10;

    [SerializeField] 
    public FunctionLib.FunctionName function;
    
    private Transform[] _points;

    private void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        var position = Vector3.zero;
        _points = new Transform[resolution * resolution];
        for (int i = 0, x = 0, z = 0; i < _points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
            }
            Transform point = _points[i] = Instantiate(pointPrefab);
            position.x = (x + 0.5f) * step - 1f;
            position.z = (z + 0.5f) * step - 1f;
            
            point.localPosition = position;
            point.localScale = scale;
            
            point.SetParent(transform, false);
        }
    }

    private void Update()
    {
        FunctionLib.Function fn = FunctionLib.GetFunction(function);
        float time = Time.time;
        for (int i = 0; i < _points.Length; i++)
        {
            Transform point = _points[i];
            Vector3 position = point.localPosition;
            position.y = fn(position.x, position.z, time);
            point.localPosition = position;
        }
    }
}
