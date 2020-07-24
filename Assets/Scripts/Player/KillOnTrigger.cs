using UnityEngine;

public class KillOnTrigger : MonoBehaviour
{
    [SerializeField]
    private Layer playerLayer;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer.Compare(col.gameObject.layer))
        {
            PlayerHealth.Instance.ChangeHP(0);
        }
    }
}
