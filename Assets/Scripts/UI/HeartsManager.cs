using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerHealth playerHealth = null;
    [SerializeField] private Image[] hearts = null; // tablica serc

    [Header("Sprites")]
    [SerializeField] private Sprite fullHeart = null;  // sprite calego serca
    [SerializeField] private Sprite emptyHeart = null; // sprite pustego serca

    private void Start()
    {
        playerHealth.onHealthChange += UpdateHearts;
    }

    public void UpdateHearts(int healthPoints)
    {
        // aktualizacja stanu serc
        for(int i = 0; i < hearts.Length; i++)
            hearts[i].sprite = i < healthPoints ? fullHeart : emptyHeart;
    }
}
