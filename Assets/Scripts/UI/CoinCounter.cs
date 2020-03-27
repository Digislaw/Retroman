using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private Text counter;

    private void Awake()
    {
        counter = GetComponent<Text>();
    }

    private void Start()
    {
        LevelController.Instance.OnCoindAdded += UpdateCounter;
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        counter.text = LevelController.Instance.Coins.ToString();
    }

    private void OnDisable()
    {
        LevelController.Instance.OnCoindAdded -= UpdateCounter;
    }
}
