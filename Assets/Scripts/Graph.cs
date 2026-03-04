using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [SerializeField, Range(10, 100)]
    public int resolution = 10;

    private void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        var position = Vector3.zero;
        for (int i = 0; i <= resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i  * step - 1f);
            position.y = position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }
}
