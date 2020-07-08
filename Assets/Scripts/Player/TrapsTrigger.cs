using UnityEngine;

public class TrapsTrigger : MonoBehaviour
{
    [SerializeField]
    private Layer trapsLayer;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (trapsLayer.Compare(col.gameObject.layer))
        {
            Vector2 delta = new Vector2(col.gameObject.transform.position.x - transform.position.x, 0f);
            PlayerHealth.Instance.DamagePlayer();
            PlayerMovement.Instance.Knockback(8f * delta.normalized.x);
        }
    }
}
