using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    [SerializeField]
    private AudioClip levelSelectedSound;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeLevel(string levelName)
    {
        Time.timeScale = 1f;
        AudioController.Instance.PlayStrict(levelSelectedSound);
        SceneManager.LoadSceneAsync(levelName);
    }
}
