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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer.Compare(col.gameObject.layer))
        {
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
        int bestCoins = PlayerPrefs.GetInt(levelData.Name + "_Coins", 0);
        if(levelData.Coins > bestCoins)
            PlayerPrefs.SetInt(levelData.Name + "_Coins", levelData.Coins);
    }

    private void CompleteLevel()
    {
        AudioController.Instance.PlayMusicWithDelay(AudioController.Instance.currentMusic, victorySound.length);
        AudioController.Instance.PlayMusic(victorySound);
        SceneController.Instance.ChangeLevel("Level Selection");
    }
}
