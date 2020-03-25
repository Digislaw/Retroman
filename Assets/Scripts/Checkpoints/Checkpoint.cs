using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    [Header("Components")]
    [SerializeField] private Sprite activatedSprite; // sprite, na jaki zmieni sie checkpoint po aktywacji
    private LayerMask playerLayer;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerLayer = LayerMask.NameToLayer("Player");
    }


    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.gameObject.layer.Equals(playerLayer) && !activated)
        {
            // aktywuj checkpoint
            activated = true;
            spriteRenderer.sprite = activatedSprite;

            // zmien spawn
            SpawnController.Instance.CurrentSpawn = new Vector3(  transform.position.x, 
                                                                    transform.position.y, 
                                                                    transform.position.z );
        }
    }
}
