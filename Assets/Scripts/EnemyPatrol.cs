using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool facingLeft = true;

    private float moveCounter;
    [SerializeField] private float baseMoveTime;

    private float waitCounter;
    [SerializeField] private float baseWaitTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        moveCounter = Random.Range(baseMoveTime * 0.5f, baseMoveTime * 1.5f);
    }

    private void FixedUpdate()
    {
        Debug.Log(moveCounter);
        if (moveCounter > 0f)
        {
            anim.SetBool("Moving", true);
            Move();
            moveCounter -= Time.fixedDeltaTime;

            if (moveCounter <= 0)
                waitCounter = Random.Range(baseWaitTime * 0.5f, baseWaitTime * 1.5f);
        }
        else
        {
            anim.SetBool("Moving", false);
            rb.velocity = new Vector2(0f, rb.velocity.y);
            waitCounter -= Time.fixedDeltaTime;

            if (waitCounter <= 0)
                moveCounter = Random.Range(baseMoveTime * 0.5f, baseMoveTime * 1.5f);
        }

        //anim.SetBool("Moving", true);
    }

    private void Move()
    {
        if (facingLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            if (transform.position.x < leftPoint.position.x)
                Flip();
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (transform.position.x > rightPoint.position.x)
                Flip();
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        sr.flipX = !facingLeft;
    }
}


/*
public class EnemyPatrol : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool facingLeft = true;
    private bool moving = true;

    private float counter;
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
        if (facingLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            if (transform.position.x < leftPoint.position.x)
                Flip();
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (transform.position.x > rightPoint.position.x)
                Flip();
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        sr.flipX = !facingLeft;
    }
}
*/
