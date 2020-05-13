using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] [Range(1f, 10f)]
    private float speed;        // predkosc ruchu przeciwnika
    [SerializeField] [Range(1f, 10f)]
    private float avgMoveTime;  // bazowy czas ruchu
    [SerializeField] [Range(1f, 10f)]
    private float avgWaitTime;  // bazowy czas czekania

    /// <summary>
    /// Enemy movement speed.
    /// </summary>
    public float Speed { get { return speed; } }

    /// <summary>
    /// Random movement time.
    /// </summary>
    public float MoveTime { get { return Random.Range(avgMoveTime * 0.5f, avgMoveTime * 1.5f); } }

    /// <summary>
    /// Random wait time.
    /// </summary>
    public float WaitTime { get { return Random.Range(avgWaitTime * 0.5f, avgWaitTime * 1.5f); } }

}
