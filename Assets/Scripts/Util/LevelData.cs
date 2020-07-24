using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    public string Name { get; private set; }
    public int Coins { get; private set; }
    public int Diamonds { get; private set; }

    [SerializeField]
    private IntEvent coinsUpdate;

    [SerializeField]
    private IntEvent diamondsUpdate;

    [SerializeField]
    private FloatEvent timerUpdate;

    private void Awake()
    {
        Name = SceneManager.GetActiveScene().name;
        StartCoroutine(TimerUpdate());
    }

    public void SetCoins(int coins)
    {
        Coins = coins;
        coinsUpdate.Invoke(coins);
    }

    public void SetDiamonds(int diamonds)
    {
        Diamonds = diamonds;
        diamondsUpdate.Invoke(diamonds);
    }

    private IEnumerator TimerUpdate()
    {
        while(true)
        {
            timerUpdate.Invoke(Time.timeSinceLevelLoad);
            yield return new WaitForEndOfFrame();
        }
    }
}
