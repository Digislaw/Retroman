using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [SerializeField]
    private LayerMask enemyLayer;
    [SerializeField]
    private GameObject deathPrefab;
    [SerializeField]
    private PlayerMovement pm;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (enemyLayer != (enemyLayer | 1 << col.gameObject.layer)) return;

        Instantiate(deathPrefab, col.gameObject.transform.position, col.gameObject.transform.rotation);
        Destroy(col.gameObject);

        pm.Bounce();
    }
}
