using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] 
    private GameObject collectedAnimation;
    [SerializeField] 
    private IntEvent coinCollected;
    [SerializeField]
    private AudioClip coinSound;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            coins++;
            coinCollected.Invoke(coins);

            AudioController.Instance.Play(coinSound); 
            Instantiate(collectedAnimation, col.gameObject.transform.position, col.gameObject.transform.rotation);

            Destroy(col.gameObject);


        }
    }
}
