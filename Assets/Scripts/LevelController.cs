using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    public uint Coins { get; private set; }
    public LayerMask PlayerLayer { get; private set; }

    public event System.Action OnCoindAdded;

    protected override void Awake()
    {
        base.Awake();
        PlayerLayer = LayerMask.NameToLayer("Player");
    }

    public void AddCoins()
    {
        Coins++;
        OnCoindAdded?.Invoke();
    }
}
