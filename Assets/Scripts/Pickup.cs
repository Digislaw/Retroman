using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private PlayerLayer playerLayer;
    [SerializeField] private ScriptableEvent collectedEvent;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(playerLayer == 1 << col.gameObject.layer)
        {
            collectedEvent.Invoke();
            Destroy(gameObject);
        }

    }
}
