using UnityEngine;
using UnityEngine.Events;

public class EventEmiterOnTrigger : MonoBehaviour
{
    [SerializeField]
    private Layer targetLayers; // warstwy obiektow, ktore maja wchodzic w interakcje

    [SerializeField]
    private UnityEvent onTriggerStay;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (targetLayers.Compare(col.gameObject.layer))
            onTriggerStay.Invoke();
    }
}
