using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] [Range(0.02f, 0.1f)]
    private float speed;        // predkosc ruchu przeciwnika
    [SerializeField] [Range(1f, 10f)]
    private float avgMoveTime;  // bazowy czas ruchu
    [SerializeField] [Range(1f, 10f)]
    private float avgWaitTime;  // bazowy czas czekania
    [SerializeField] [Range(1f, 10f)]
    private float knockbackForce; // sila odrzutu

    /// <summary>
    /// Prędkość ruchu przeciwnika.
    /// </summary>
    public float Speed { get { return speed; } }

    /// <summary>
    /// Przeciętny czas ruchu.
    /// </summary>
    public float MoveTime { get { return Random.Range(avgMoveTime * 0.5f, avgMoveTime * 1.5f); } }

    /// <summary>
    /// Przeciętny czas pauzy ruchu.
    /// </summary>
    public float WaitTime { get { return Random.Range(avgWaitTime * 0.5f, avgWaitTime * 1.5f); } }

    /// <summary>
    /// Siła odrzutu przy kontakcie.
    /// </summary>
    public float KnockbackForce { get { return knockbackForce; } }

}
