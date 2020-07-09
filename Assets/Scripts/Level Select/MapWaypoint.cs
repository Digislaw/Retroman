using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWaypoint : MonoBehaviour
{
    [Header("Waypoint Settings")]

    [SerializeField]
    private bool isLevelPoint;    // punkt reprezentuje poziom

    [SerializeField]
    private string levelName;   // nazwa poziomu, jesli jest punktem poziomu

    [SerializeField]
    private MapWaypoint up, left, right, down;  // sasiadujace punkty

    public MapWaypoint Up { get { return up; } }
    public MapWaypoint Left { get { return left; } }
    public MapWaypoint Right { get { return right; } }
    public MapWaypoint Down { get { return down; } }

    public bool IsLevelPoint { get { return isLevelPoint; } }
    public string LevelName { get { return levelName; } }

}
