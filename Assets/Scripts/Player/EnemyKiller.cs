using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [SerializeField]
    private LayerMask enemyLayer;
    [SerializeField]
    private GameObject deathPrefab;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!Layer.Compare(enemyLayer, col.gameObject.layer)) return;

        Instantiate(deathPrefab, col.gameObject.transform.position, col.gameObject.transform.rotation);
        Destroy(col.gameObject);

        PlayerMovement.Instance.Bounce();
    }
}
