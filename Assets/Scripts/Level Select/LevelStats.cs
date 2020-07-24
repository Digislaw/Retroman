using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelStats : MonoBehaviour
{
    [SerializeField]
    private Text levelName;

    [SerializeField]
    private Text coins;

    [SerializeField]
    private Text diamonds;

    [SerializeField]
    private Text time;

    private void Start()
    {
    }

    public void ShowStats(MapWaypoint waypoint)
    {
        gameObject.SetActive(true);

        // Nazwa poziomu (naglowek karty)
        levelName.text = waypoint.Label;

        // Rekord monet
        coins.text = waypoint.Coins.ToString().PadLeft(3, '0'); ;

        // Rekord diamentow
        diamonds.text = waypoint.Diamonds.ToString() + " / 3";

        // Rekord czasu
        if (waypoint.Completed)
        {
            float t = waypoint.Time;
            TimeSpan span = TimeSpan.FromSeconds(t);
            time.text = string.Format("{0:d2}:{1:d2}", span.Minutes, span.Seconds);
        }
        else
        {
            time.text = "--:--";
        }
       
    }

    public void HideStats()
    {
        gameObject.SetActive(false);
    }
}
