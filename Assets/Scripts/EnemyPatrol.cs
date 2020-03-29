using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;   // predkosc ruchu przeciwnika
    [SerializeField] private Transform leftPoint;   // punkt po lewej stronie przeciwnika
    [SerializeField] private Transform rightPoint;  // punkt po prawej stronie przeciwnika

    // komponenty
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    // przelaczanie miedzy ruchem a czekaniem
    private bool moving = true; // przeciwnik jest w ruchu
    private float counter;  // odliczanie do nastepnej zmiany trybu
    [SerializeField] private float avgMoveTime; // bazowy czas ruchu
    [SerializeField] private float avgWaitTime; // bazowy czas czekania

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        counter = Random.Range(avgMoveTime * 0.5f, avgMoveTime * 1.5f);
    }

    private void FixedUpdate()
    {
        counter -= Time.fixedDeltaTime;

        if (moving)
        {
            Move();
            
            if(counter <= 0)
            {
                counter = Random.Range(avgWaitTime * 0.5f, avgWaitTime * 1.5f);
                moving = false;
            }
                
        } 
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);

            if (counter <= 0)
            {
                counter = Random.Range(avgMoveTime * 0.5f, avgMoveTime * 1.5f);
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
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            if (transform.position.x < leftPoint.position.x)
                Flip();
        }
        // przeciwnik zwrocony w prawo (jego sprite jest odwrocony -> sr.flipX == true)
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (transform.position.x > rightPoint.position.x)
                Flip();
        }
    }

    private void Flip()
    {
        sr.flipX = !sr.flipX;
    }
}
