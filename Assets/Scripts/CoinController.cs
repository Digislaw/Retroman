using UnityEngine;

public class CoinController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.layer.Equals(LevelController.Instance.PlayerLayer))
        {
            LevelController.Instance.AddCoins();
            Destroy(gameObject);
        }
        
    }
}
