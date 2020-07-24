using UnityEngine;

public class MapWaypoint : MonoBehaviour
{
    [SerializeField]
    private MapWaypoint up, left, right, down;  // sasiadujace punkty

    [Header("Level Settings")]
    [SerializeField]
    private string levelName;   // identyfikator poziomu, jesli jest punktem poziomu

    [SerializeField]
    private string label;       // nazwa poziomu ("fabularna"), widoczna dla gracza

    [SerializeField] [Range(1, 999)]
    private int requiredCoins = 1;  // liczba monet potrzebna do progressu

    public MapWaypoint Up { get { return up; } }
    public MapWaypoint Left { get { return left; } }
    public MapWaypoint Right { get { return right; } }
    public MapWaypoint Down { get { return down; } }

    public bool Unlocked { get; private set; }
    public string LevelName { get { return levelName; } }

    public string Label { get { return label; } }
    public bool Completed { get; private set; }
    public int Coins { get; set; }
    public int RequiredCoins { get { return requiredCoins; } }
    public int Diamonds { get; set; }
    public float Time { get; set; }

    public void LockLevel()
    {
        Unlocked = false;
        GetComponent<SpriteRenderer>().color = new Color(0.49f, 0.49f, 0.49f);
    }

    public void UnlockLevel()
    {
        Unlocked = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    public void MarkAsComplete()
    {
        Completed = true;
    }

    public void MarkAsIncomplete()
    {
        Completed = false;
    }
}
