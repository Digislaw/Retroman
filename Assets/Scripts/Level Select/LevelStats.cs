using UnityEngine;
using UnityEngine.UI;

public class LevelStats : MonoBehaviour
{
    [SerializeField]
    private Text levelName;

    [SerializeField]
    private Text coins;

    [SerializeField]
    private Text time;

    public void ShowStats(MapWaypoint waypoint)
    {
        gameObject.SetActive(true);

        // Nazwa poziomu (naglowek karty)
        levelName.text = waypoint.Label;

        // Rekord monet
        coins.text = waypoint.Coins.ToString();

        // Rekord czasu
        time.text = waypoint.Time;
    }

    public void HideStats()
    {
        gameObject.SetActive(false);
    }
}
