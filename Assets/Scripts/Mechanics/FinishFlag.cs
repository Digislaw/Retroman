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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer.Compare(col.gameObject.layer))
        {
            PlayerMovement.Instance.Freeze();

            UnlockLevels();
            CompleteLevel();            
        }
    }

    private void UnlockLevels()
    {
        for(int i = 0; i<levelsToUnlock.Length; i++)
            PlayerPrefs.SetInt(levelsToUnlock[i] + "_Unlocked", 1);

        PlayerPrefs.Save();
    }

    private void CompleteLevel()
    {
        AudioController.Instance.PlayMusicWithDelay(AudioController.Instance.currentMusic, victorySound.length);
        AudioController.Instance.PlayMusic(victorySound);
        SceneController.Instance.ChangeLevel("Level Selection");
    }
}
