using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWaypoint : MonoBehaviour
{
    [SerializeField]
    private bool levelPoint;    // punkt reprezentuje poziom

    [SerializeField]
    private MapWaypoint north, west, east, south;
}
