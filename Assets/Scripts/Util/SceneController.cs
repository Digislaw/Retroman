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
        //StartCoroutine(Test());
    }

    public void ChangeLevel(string levelName)
    {
        AudioController.Instance.PlayStrict(levelSelectedSound);
        SceneManager.LoadSceneAsync(levelName);
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(sceneName: "druga");
    }

}
