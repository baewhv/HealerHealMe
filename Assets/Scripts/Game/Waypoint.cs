using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint : SingletonMonoBehaviour<Waypoint>
{
    public Transform[] points;

    protected override void OnAwake()
    {
        base.OnAwake();
        points = new Transform[transform.childCount];
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
