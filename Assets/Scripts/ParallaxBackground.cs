using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    // komponenty
    [SerializeField] private Transform playerCamera = null; // kamera podazajaca za graczem
    private SpriteRenderer sprite; // sprite tla

    [Range(0f, 1f)]
    [SerializeField] private float speed = 0.5f; // predkosc przesuwania tla
    private float origin; // wartosc osi X punktu odniesienia

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        origin = transform.position.x; 
    }

    private void Update()
    {
        // podazanie tla za graczem
        transform.position = new Vector3(origin + speed * playerCamera.position.x, transform.position.y, 0f);

        float step = 2f * sprite.bounds.size.x; // krok do przesuniecia, jesli gracz zbliza sie;
        float margin = playerCamera.position.x - speed * playerCamera.position.x;

        // sprawdzenie prawej strony
        if (origin + sprite.bounds.size.x < margin)
            origin += step;
        // sprawdzenie lewej strony
        else if (origin - sprite.bounds.size.x > margin)
            origin -= step;
    }

}