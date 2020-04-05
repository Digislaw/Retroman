using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;   // obiekt nadrzedny menu pauzy
    [SerializeField]
    private AudioClip pauseSound;   // dzwiek wlaczenia/wylaczenia pauzy
    public bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SwitchPause();
    }

    public void SwitchPause()
    {
        paused = !paused;

        AudioController.Instance.Play(pauseSound);
        pauseMenu.SetActive(paused);
        Time.timeScale = paused ? 0f : 1f;
    }
}
