using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(sceneName: "druga");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
