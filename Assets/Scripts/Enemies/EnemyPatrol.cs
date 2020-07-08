using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // komponenty
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    [Header("Settings")]
    [SerializeField]
    private Enemy enemyType;       // typ przeciwnika
    [SerializeField] 
    private Transform leftPoint;   // punkt po lewej stronie przeciwnika
    [SerializeField] 
    private Transform rightPoint;  // punkt po prawej stronie przeciwnika
    [SerializeField]
    private Layer triggerLayers;   // generalnie dotyczy gracza, ale uogolnienie moze sie przydac


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
        float distance;

        // przeciwnik zwrocony w lewo (domyslny stan)
        if (!sr.flipX)
        {
            distance = transform.position.x - leftPoint.position.x;

            if (distance > 0.1f)
            {
                Vector2 nextStep = Vector2.MoveTowards(rb.position, leftPoint.position, enemyType.Speed);
                rb.MovePosition(nextStep);
            }
            else
            {
                Flip();
            }
                
        }
        // przeciwnik zwrocony w prawo (jego sprite jest odwrocony -> sr.flipX == true)
        else
        {
            distance = rightPoint.position.x - transform.position.x;

            if (distance > 0.1f)
            {
                Vector2 nextStep = Vector2.MoveTowards(rb.position, rightPoint.position, enemyType.Speed);
                rb.MovePosition(nextStep);
            }
            else
            {
                Flip();
            }
        }

    }

    private void Flip()
    {
        sr.flipX = !sr.flipX;
    }

    // odrzut
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!triggerLayers.Compare(col.gameObject.layer)) return;

        Vector2 vec = new Vector2(transform.position.x - col.gameObject.transform.position.x, 0f);
        PlayerHealth.Instance.DamagePlayer();
        PlayerMovement.Instance.Knockback(enemyType.KnockbackForce * vec.normalized.x); // odrzuc gracza
    }
}
