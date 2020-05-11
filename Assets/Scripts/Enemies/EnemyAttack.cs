using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private Layer playerLayer;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (playerLayer.Value != (playerLayer.Value | 1 << col.gameObject.layer)) return;

        Vector2 vec = new Vector2(transform.position.x - col.gameObject.transform.position.x, 0f);
        PlayerHealth.Instance.DamagePlayer((int) vec.normalized.x);
    }
}
