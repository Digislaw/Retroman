using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private LevelsController levelsController;

    private int totalPoints = 0;
    private int maxPoints = 0;   

    private void Start()
    {
        CalculatePoints();
        CalculateGameCompletion();
    }

    private void CalculatePoints()
    {
        /*
         * Punktacja:
         * 2 - ukonczenie poziomu
         * 2 - zebranie wiekszosci monet (75% wszystkich, zaokraglone w gore)
         * 3 - zebranie wszystkich diamentow (po 1 za kazdy)
         * 3 - ukonczenie poziomu ponizej minuty (speedrun)
         * Lacznie: 10 pkt na kazdy poziom
         */

        maxPoints = levelsController.Levels.Length * 10;

        foreach(MapWaypoint level in levelsController.Levels)
        {
            // Ukonczenie poziomu
            if (level.Completed)
                totalPoints += 2;

            // Zebranie wiekszosci monet
            if (level.Coins >= level.RequiredCoins)
                totalPoints += 2;

            // Zebranie diamentow
            totalPoints += level.Diamonds;

            // Speedrun
            if (level.Completed && level.Time < 60f)
                totalPoints += 3;
        }
    }

    private void CalculateGameCompletion()
    {
        double progress = (double)totalPoints / maxPoints * 100;
        text.text = progress.ToString("0.00") + "%";
    }
}
