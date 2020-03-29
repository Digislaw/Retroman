using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text counter;

    private void Start()
    {
        counter.text = 0.ToString();
    }

    public void UpdateCounter(int newValue)
    {
        counter.text = newValue.ToString();
    }
}
