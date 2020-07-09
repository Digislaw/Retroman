using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    [SerializeField]
    private Layer playerLayer;
    [SerializeField]
    private AudioClip victorySound;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer.Compare(col.gameObject.layer))
        {
            PlayerMovement.Instance.Freeze();
            AudioController.Instance.PlayMusicWithDelay(AudioController.Instance.currentMusic, victorySound.length);
            AudioController.Instance.PlayMusic(victorySound);
            SceneController.Instance.ChangeLevel("Level Selection");
        }
    }
}
