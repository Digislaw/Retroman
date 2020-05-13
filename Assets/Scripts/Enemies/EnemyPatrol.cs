using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // komponenty
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    [Header("Configuration")]
    [SerializeField]
    private Enemy enemyType;       // typ przeciwnika
    [SerializeField] 
    private Transform leftPoint;   // punkt po lewej stronie przeciwnika
    [SerializeField] 
    private Transform rightPoint;  // punkt po prawej stronie przeciwnika

    // przelaczanie miedzy ruchem, a czekaniem
    private bool moving = true; // przeciwnik jest w ruchu
    private float counter;  // odliczanie do nastepnej zmiany trybu

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        counter = enemyType.MoveTime;
    }

    private void FixedUpdate()
    {
        counter -= Time.fixedDeltaTime;

        if (moving)
        {
            Move();
            
            if(counter <= 0)
            {
                counter = enemyType.WaitTime;
                moving = false;
            }
                
        } 
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);

            if (counter <= 0)
            {
                counter = enemyType.MoveTime;
                moving = true;
            }
                
        }

        anim.SetBool("Moving", moving);
    }

    private void Move()
    {
        // przeciwnik zwrocony w lewo (domyslny stan)
        if (!sr.flipX)
        {
            rb.velocity = new Vector2(-enemyType.Speed, rb.velocity.y);

            if (transform.position.x < leftPoint.position.x)
                Flip();
        }
        // przeciwnik zwrocony w prawo (jego sprite jest odwrocony -> sr.flipX == true)
        else
        {
            rb.velocity = new Vector2(enemyType.Speed, rb.velocity.y);

            if (transform.position.x > rightPoint.position.x)
                Flip();
        }
    }

    private void Flip()
    {
        sr.flipX = !sr.flipX;
    }
}
