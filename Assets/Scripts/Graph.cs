using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [SerializeField, Range(10, 100)]
    public int resolution = 10;

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
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
    }
}
