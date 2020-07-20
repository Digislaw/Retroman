using UnityEngine;

public class PickupCollector : MonoBehaviour
{
    private int counter = 0;
    [SerializeField]
    private GameObject collectedAnimation;
    [SerializeField]
    private IntEvent collected;
    [SerializeField]
    private AudioClip collectedSound;
    [SerializeField]
    private string pickupTag;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(pickupTag))
        {
            counter++;
            collected.Invoke(counter);

            AudioController.Instance.Play(collectedSound);
            Instantiate(collectedAnimation, col.gameObject.transform.position, col.gameObject.transform.rotation);

            Destroy(col.gameObject);
        }
    }
}
