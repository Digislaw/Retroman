
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerMovement : Singleton<PlayerMovement>
{
    // komponenty
    private SpriteRenderer sprite;
    public Rigidbody2D rb { get; private set; }
    private Animator animator;
    [SerializeField]
    private PauseController pause;
   
    [Header("Horizontal movement")]
    [SerializeField] private float speed = 5f; // predkosc ruchu
    private int direction = 1; // 1 - w prawo, -1 - w lewo
    private bool freezed = false;

    [Header("Jumping")]
    [SerializeField] private float jumpForce = 20f; // sila skoku
    [SerializeField] private float bounceForce = 30f;   // sila odbicia od przeciwnika przy jego eliminacji
    [SerializeField] private Transform groundChecker = null;
    [SerializeField] private LayerMask platformFilter = 0; // warstwy, po ktorych mozna skakac
    private bool onGround;
    private bool doubleJumpReady;

    [Header("Knockback")]
    //[SerializeField] private float knockbackForce = 8f; // sila odrzutu
    [SerializeField] private float controlsLockPeriod = 0.2f; // czas blokady sterowania podczasu odrzutu
    private float controlsLockCounter; // licznik blokady

    [Header("Sound Effects")]
    [SerializeField] private AudioClip knockbackSound;
    [SerializeField] private AudioClip jumpSound;

    protected override void Awake()
    {
        //_instance = this;
        base.Awake();

        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pause.paused || freezed) return;

        if (controlsLockCounter > 0f)
        {
            // zaktualizuj licznik blokady
            controlsLockCounter -= Time.deltaTime;
            return;
        }

        // sprawdz czy gracz jest na podlozu
        GroundCheck();

        // ruch po osi X
        rb.velocity = new Vector2(speed * Controls.Horizontal, rb.velocity.y);

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
            // odtworz dzwiek
            AudioController.Instance.Play(jumpSound);

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        // podwojny skok
        else if (doubleJumpReady)
        {
            // odtworz dzwiek
            AudioController.Instance.Play(jumpSound);

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

    public void Knockback(float knockbackForce)
    {
        // odtworz dzwiek
        AudioController.Instance.Play(knockbackSound);

        // uruchom blokade
        controlsLockCounter = controlsLockPeriod;

        // odrzuc gracza
        //rb.velocity = new Vector2(-knockbackForce * knockbackDirection, knockbackForce);
        rb.velocity = new Vector2(-knockbackForce, knockbackForce * 0.57735026919f);
        
        // uruchom odpowiednia animacje
        animator.SetTrigger("Hit");
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(0.5f * bounceForce * direction, bounceForce);
    }

    public void Freeze()
    {
        if (freezed)
        {
            freezed = false;
        }
        else
        {
            freezed = true;
            rb.velocity = Vector2.zero;
        }

        animator.SetFloat("Horizontal Speed", 0);
        animator.SetFloat("Vertical Speed", 0);
        animator.SetBool("On Ground", true);
    }
}
