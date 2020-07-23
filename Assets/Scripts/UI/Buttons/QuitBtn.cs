using UnityEngine;
using UnityEngine.UI;

public class QuitBtn : MonoBehaviour
{
    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
