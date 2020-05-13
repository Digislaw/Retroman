using UnityEngine;

public class Crusher : MonoBehaviour
{
    [Header("Landing Waypoint")]
    [SerializeField] 
    private Transform landingPosition;

    [Header("Movement Speed")]
    [SerializeField] [Range(1f, 10f)]
    private float upSpeed = 2.5f;
    [SerializeField] [Range(1f, 10f)]
    private float downSpeed = 5f;

    // zmienne pozyskiwane automatycznie
    private Rigidbody2D rb;
    private Vector3 idlePosition;

    // flagi
    private bool movingUp = false;
    private bool movingDown = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        idlePosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (movingDown || movingUp)
            Move();
    }

    public void Land()
    {
        if (!movingDown && !movingUp)
        {
            movingDown = true;
            rb.velocity = new Vector2(rb.velocity.x, -downSpeed);
        }
            
    }

    private void Move()
    {
        // sprawdzenie osiagniecia celu podczas ruchu w dol
        if(movingDown && Vector3.Distance(transform.position, landingPosition.position) < 1.25f)
        {
            movingDown = false;
            movingUp = true;
            rb.velocity = new Vector2(rb.velocity.x, upSpeed);
        }
        // analogicznie dla ruchu w gore
        else if(movingUp && Vector3.Distance(transform.position, idlePosition) < 0.1f)
        {
            movingDown = false;
            movingUp = false;
            rb.velocity = Vector2.zero;
        }
    }

}
