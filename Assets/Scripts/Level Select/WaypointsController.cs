using UnityEngine;

public class WaypointsController : MonoBehaviour
{
    [SerializeField]
    private MapWaypoint[] waypoints; // punkty, ktore reprezentuja poziomy

    private void Awake()
    {
        for(int i = 0; i<waypoints.Length; i++)
        {
            // niestety PlayerPrefs nie ma wsparcia dla boola
            if (PlayerPrefs.GetInt(waypoints[i].LevelName + "_Unlocked", 0) == 0)
                waypoints[i].LockLevel();
            else
                waypoints[i].UnlockLevel();
        }
    }
}
