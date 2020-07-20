using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Layer playerLayer;
    [SerializeField]
    private AudioClip victorySound;
    [SerializeField]
    private string[] levelsToUnlock;    // nazwy poziomow do odblokowania
    [SerializeField]
    private LevelData levelData;
    private float finalTime;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer.Compare(col.gameObject.layer))
        {
            finalTime = Time.timeSinceLevelLoad;
            PlayerMovement.Instance.Freeze();

            UnlockLevels();
            UpdateRecords();
            PlayerPrefs.Save();
            CompleteLevel();            
        }
    }

    private void UnlockLevels()
    {
        for(int i = 0; i<levelsToUnlock.Length; i++)
            PlayerPrefs.SetInt(levelsToUnlock[i] + "_Unlocked", 1);
    }

    private void UpdateRecords()
    {
        // Monety
        string coinsKey = levelData.Name + "_Coins";
        int bestCoins = PlayerPrefs.GetInt(coinsKey, 0);
        if(levelData.Coins > bestCoins)
            PlayerPrefs.SetInt(coinsKey, levelData.Coins);

        // Czas
        string timeKey = levelData.Name + "_Time";
        if (PlayerPrefs.HasKey(timeKey))
        {
            float bestTime = PlayerPrefs.GetFloat(timeKey);
            if (finalTime < bestTime)
                PlayerPrefs.SetFloat(timeKey, finalTime);
        }
        else
        {
            PlayerPrefs.SetFloat(timeKey, finalTime);
        }
    }

    private void CompleteLevel()
    {
        AudioController.Instance.PlayMusicWithDelay(AudioController.Instance.currentMusic, victorySound.length);
        AudioController.Instance.PlayMusic(victorySound);
        SceneController.Instance.ChangeLevel("Level Selection");
    }
}
