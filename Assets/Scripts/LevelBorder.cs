using UnityEngine;

public class LevelBorder : MonoBehaviour
{
    private LayerMask playerLayer;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer.Equals(playerLayer))
        {
            PlayerHealth.Instance.ChangeHP(0);
        }
    }
}
