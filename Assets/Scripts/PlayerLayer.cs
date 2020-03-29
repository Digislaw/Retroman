using UnityEngine;

[CreateAssetMenu]
public class PlayerLayer : ScriptableObject
{
    // unikalna warstwa gracza w celu filtracji, np. przy pickupach
    public LayerMask Layer;

    public static implicit operator int(PlayerLayer pl)
    {
        // dla wygody i wiekszej czytelnosci
        return pl.Layer;
    }
}
