using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    private Text version;

    private void Awake()
    {
        version = GetComponent<Text>();
        version.text = "v" + Application.version;
    }
}
