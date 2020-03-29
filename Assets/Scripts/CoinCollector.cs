using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private GameObject collectedAnimation;
    [SerializeField] private IntEvent coinCollected;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            coins++;
            coinCollected.Invoke(coins);
            Destroy(col.gameObject);

            Instantiate(collectedAnimation, transform.position, transform.rotation);
        }
    }
}
