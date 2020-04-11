using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    // komponenty
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    [Header("Configuration")]
    [SerializeField] [Range(1f, 10f)]
    private float speed;   // predkosc ruchu
    [SerializeField] 
    private Transform leftPoint;   // punkt po lewej stronie
    [SerializeField] 
    private Transform rightPoint;  // punkt po prawej stronie

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        UpdateVelocity();
    }

    private void FixedUpdate()
    {
        // zwrot w lewo (domyslny stan) lub zwrot w prawo (sprite jest odwrocony -> sr.flipX == true)
        if (transform.position.x < leftPoint.position.x || transform.position.x > rightPoint.position.x)
        {
            Flip();
            UpdateVelocity();
        }
            
    }

    private void Flip()
    {
        sr.flipX = !sr.flipX;
    }

    private void UpdateVelocity()
    {
        if (sr.flipX)
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
