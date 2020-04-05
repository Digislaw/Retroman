using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    private Image img; // w celu manipulacji przezroczystoscia

    [SerializeField] [Tooltip("The effect's duration in seconds.")] [Range(0.5f, 5f)]
    private float effectDuration = 1.5f;   // czas trwania efektu (w sekundach)

    public float Duration { get { return effectDuration; } }

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void Start()
    {
        FadeOut();
    }
    
    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }
    
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        for (float a = img.color.a; a <= 1f; a += Time.deltaTime / effectDuration)
        {
            Color color = img.color;  // biezacy stan
            color.a = a;
            img.color = color;

            yield return null; // krok wykonany - oczekuj na kolejna klatke
        }
    }

    private IEnumerator FadeOutCoroutine()
    {
        for(float a = img.color.a; a >= 0f; a -= Time.deltaTime / effectDuration)
        {
            Color color = img.color;  // biezacy stan
            color.a = a;
            img.color = color;

            yield return null; // krok wykonany - oczekuj na kolejna klatke
        }
    }
}
