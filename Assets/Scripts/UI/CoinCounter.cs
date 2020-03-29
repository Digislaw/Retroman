using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text counter;
    private int num = 0;

    private void Start()
    {
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        num++;
        counter.text = num.ToString();
    }
}
