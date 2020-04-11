using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator animator;
    private LayerMask playerLayer;
    [SerializeField]
    private float pushForce = 5f;
    [SerializeField]
    private AudioClip bounceSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == playerLayer)
        {
            animator.SetTrigger("Push");
            PlayerMovement.Instance.rb.velocity = new Vector2(PlayerMovement.Instance.rb.velocity.x, pushForce);
            AudioController.Instance.Play(bounceSound);
        }
    }
}
