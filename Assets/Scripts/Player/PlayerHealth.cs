using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static PlayerHealth _instance;
    public static PlayerHealth Instance
    {
        get { return _instance; }
    }

    // komponenty
    private SpriteRenderer sprite;
    private PlayerMovement pm;

    private int healthPoints;   // aktualna liczba zyc
    public int maxHealth = 4;  // maksymalna liczba zyc
    private LayerMask damageLayer;  // warstwa zawierajaca pulapki i przeciwnikow

    public delegate void OnHealthChange(int healthPoints);  // delegat zmiany HP
    public OnHealthChange onHealthChange;

    [SerializeField] private float invincibilityPeriod = 1.5f;
    private float invicibilityCounter;

    public delegate void OnPlayerDeath();
    public OnPlayerDeath onPlayerDeath;

    [SerializeField] private GameObject deathAnimation;

    private void Awake()
    {
        _instance = this;

        sprite = GetComponent<SpriteRenderer>();
        pm = GetComponent<PlayerMovement>();

        damageLayer = LayerMask.NameToLayer("Danger");
        healthPoints = maxHealth;
    }

    private void Update()
    {
        // zaktualizuj licznik niesmiertelnosci
        if (invicibilityCounter > 0f) UpdateCounter();
    }

    private void UpdateCounter()
    {
        invicibilityCounter -= Time.deltaTime;

        if (invicibilityCounter < 0f)
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer.Equals(damageLayer))
        {
            Vector2 vec = new Vector2(col.gameObject.transform.position.x - transform.position.x, 0f);
            DamagePlayer((int)vec.normalized.x);
        }
    }

    public void DamagePlayer(int knockbackDirection)
    {
        if (invicibilityCounter > 0f) return;   // gracz jest niesmiertelny, przerwij zadawanie obrazen

        ChangeHP(healthPoints - 1);
        
        pm.Knockback(knockbackDirection); // odrzuc gracza

        if (healthPoints > 0)
            TriggerInvicibility();  // tymczasowa niesmiertelnosc zabezpiecza przed nadmiernymi obrazeniami

    }

    public void ChangeHP(int healthPoints)
    {
        this.healthPoints = healthPoints;
        onHealthChange?.Invoke(healthPoints);

        if (healthPoints <= 0)
            TriggerDeath();
    }

    private void TriggerDeath()
    {
        Instantiate(deathAnimation, transform.position, transform.rotation);
        onPlayerDeath?.Invoke();
    }

    private void TriggerInvicibility()
    {
        // uruchom odliczanie
        invicibilityCounter = invincibilityPeriod;

        // zmiana wygladu gracza
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.66f);
    }
}
