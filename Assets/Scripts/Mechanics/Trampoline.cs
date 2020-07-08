using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Layer playerLayer;
    [SerializeField]
    private float pushForce = 5f;
    [SerializeField]
    private AudioClip bounceSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(playerLayer.Compare(col.gameObject.layer))
        {
            animator.SetTrigger("Push");
            PlayerMovement.Instance.rb.velocity = new Vector2(PlayerMovement.Instance.rb.velocity.x, pushForce);
            AudioController.Instance.Play(bounceSound);
        }
    }
}
