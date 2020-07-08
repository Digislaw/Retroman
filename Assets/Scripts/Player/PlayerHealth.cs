using System.Collections;
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
    private LayerMask damageLayer;  // warstwy zawierajaca pulapki i przeciwnikow

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
        if (invicibilityCounter > 0f) 
            UpdateCounter();
    }

    private void UpdateCounter()
    {
        invicibilityCounter -= Time.deltaTime;
            
    }

    public void DamagePlayer()
    {
        if (invicibilityCounter > 0f) return;   // gracz jest niesmiertelny, przerwij zadawanie obrazen

        ChangeHP(healthPoints - 1);

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
        StartCoroutine(Blink());
    }

    // efekt zmiany przezroczystosci po otrzymaniu obrazen
    private IEnumerator Blink()
    {
        bool alphaChanged = false;

        while(invicibilityCounter > 0f)
        {
            sprite.color = new Color(sprite.color.r,
                                    sprite.color.g,
                                    sprite.color.b,
                                    alphaChanged ? 1f : 0.2f );
            alphaChanged = !alphaChanged;
            yield return null;
        }

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);   // przywrocenie stanu sprite'a
    }
}
