using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWaypoint : MonoBehaviour
{
    [Header("Waypoint Settings")]

    [SerializeField]
    private bool unlocked;    // punkt reprezentuje poziom

    [SerializeField]
    private string levelName;   // nazwa poziomu, jesli jest punktem poziomu

    [SerializeField]
    private MapWaypoint up, left, right, down;  // sasiadujace punkty

    private SpriteRenderer sprite;

    public MapWaypoint Up { get { return up; } }
    public MapWaypoint Left { get { return left; } }
    public MapWaypoint Right { get { return right; } }
    public MapWaypoint Down { get { return down; } }

    public bool Unlocked { get { return unlocked; } }
    public string LevelName { get { return levelName; } }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void LockLevel()
    {
        unlocked = false;
        GetComponent<SpriteRenderer>().color = new Color(0.49f, 0.49f, 0.49f);
    }

    public void UnlockLevel()
    {
        unlocked = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
