using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField]
    private MapWaypoint[] levels; // punkty, ktore reprezentuja poziomy

    public MapWaypoint[] Levels { get { return levels; } }

    private void Awake()
    {
        for(int i = 0; i<levels.Length; i++)
        {
            // niestety PlayerPrefs nie ma wsparcia dla boola
            if (PlayerPrefs.GetInt(levels[i].LevelName + "_Unlocked", 0) == 0)
                levels[i].LockLevel();
            else
                levels[i].UnlockLevel();

            if (PlayerPrefs.GetInt(levels[i].LevelName + "_Completed", 0) == 1)
                levels[i].MarkAsComplete();
            else
                levels[i].MarkAsIncomplete();

            // Monety
            levels[i].Coins = PlayerPrefs.GetInt(levels[i].LevelName + "_Coins", 0);

            // Diamenty
            levels[i].Diamonds = PlayerPrefs.GetInt(levels[i].LevelName + "_Diamonds", 0);

            // Czas
            levels[i].Time = PlayerPrefs.GetFloat(levels[i].LevelName + "_Time", 0f);       
        }
    }
}
