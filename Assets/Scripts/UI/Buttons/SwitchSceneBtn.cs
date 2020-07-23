using UnityEngine;
using UnityEngine.UI;

public class SwitchSceneBtn : MonoBehaviour
{
    private Button btn;

    [SerializeField]
    private string sceneName;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SwitchScene);
    }

    private void SwitchScene()
    {
        SceneController.Instance.ChangeLevel(sceneName);
    }    
}
