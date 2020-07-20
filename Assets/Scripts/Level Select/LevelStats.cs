using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelStats : MonoBehaviour
{
    [SerializeField]
    private Text levelName;

    [SerializeField]
    private Text coins;

    public void ShowStats(MapWaypoint waypoint)
    {
        gameObject.SetActive(true);
        levelName.text = waypoint.Label;
        coins.text = waypoint.Coins.ToString();
    }

    public void HideStats()
    {
        gameObject.SetActive(false);
    }
}
