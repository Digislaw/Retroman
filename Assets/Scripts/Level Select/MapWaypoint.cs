using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWaypoint : MonoBehaviour
{
    [SerializeField]
    private bool levelPoint;    // punkt reprezentuje poziom

    [SerializeField]
    private MapWaypoint up, left, right, down;  // sasiadujace punkty

    public MapWaypoint Up { get { return up; } }
    public MapWaypoint Left { get { return left; } }
    public MapWaypoint Right { get { return right; } }
    public MapWaypoint Down { get { return down; } }
}
