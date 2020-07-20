using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField]
    private MapWaypoint[] levels; // punkty, ktore reprezentuja poziomy

    private void Awake()
    {
        for(int i = 0; i<levels.Length; i++)
        {
            // niestety PlayerPrefs nie ma wsparcia dla boola
            if (PlayerPrefs.GetInt(levels[i].LevelName + "_Unlocked", 0) == 0)
                levels[i].LockLevel();
            else
                levels[i].UnlockLevel();

            levels[i].Coins = PlayerPrefs.GetInt(levels[i].LevelName + "_Coins", 0);
        }
    }
}
