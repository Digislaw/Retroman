using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement _instance;
    public static PlayerMovement Instance
    {
        get { return _instance; }
    }

    // komponenty
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator animator;
   
    [Header("Horizontal movement")]
    [SerializeField] private float speed = 5f; // predkosc ruchu
    private int direction = 1; // 1 - w prawo, -1 - w lewo

    [Header("Jumping")]
    [SerializeField] private float jumpForce = 20f; // sila skoku
    [SerializeField] private Transform groundChecker = null;
    [SerializeField] private LayerMask platformFilter = 0; // warstwy, po ktorych mozna skakac
    private bool onGround;
    private bool doubleJumpReady;

    [Header("Knockback")]
    [SerializeField] private float knockbackForce = 8f; // sila odrzutu
    [SerializeField] private float controlsLockPeriod = 0.2f; // czas blokady sterowania podczasu odrzutu
    private float controlsLockCounter; // licznik blokady

    private void Awake()
    {
        _instance = this;

        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (controlsLockCounter > 0f)
        {
            // zaktualizuj licznik blokady
            controlsLockCounter -= Time.deltaTime;
            return;
        }

        // sprawdz czy gracz jest na podlozu
        GroundCheck();

        // ruch po osi X
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        // kontrola prawidlowego ukierunkowania postaci
        Flip();

        // skok
        if (Input.GetButtonDown("Jump"))
            Jump();

        // wyznacz parametry dla animacji
        Animate();

    }

    private void GroundCheck()
    {
        onGround = Physics2D.OverlapCircle(groundChecker.position, 0.3f, platformFilter);

        if (onGround) doubleJumpReady = true;
    }

    private void Flip()
    {
        if (rb.velocity.x * direction < 0f)
        {
            sprite.flipX = !sprite.flipX;
            direction *= -1;
        }
            
    }

    private void Jump()
    {
        // pojedynczy skok
        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        // podwojny skok
        else if (doubleJumpReady)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.1f);
            doubleJumpReady = false;
            animator.SetTrigger("Double Jump");
        }
    }

    private void Animate()
    {
        // wartosc bezwzgledna horyzontalnej predkosci
        animator.SetFloat("Horizontal Speed", Mathf.Abs(rb.velocity.x));

        // wartosc wertykalnej predkosci
        animator.SetFloat("Vertical Speed", rb.velocity.y);

        // czy gracz jest na podlozu
        animator.SetBool("On Ground", onGround);
    }

    public void Knockback()
    {
        // uruchom blokade
        controlsLockCounter = controlsLockPeriod;

        // odrzuc gracza
        rb.velocity = new Vector2(-knockbackForce * direction, knockbackForce);

        // uruchom odpowiednia animacje
        animator.SetTrigger("Hit");
    }
}
