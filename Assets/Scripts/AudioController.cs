using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource musicSource; // zrodlo muzyki
    [SerializeField]
    private AudioSource soundSource; // zrodlo efektow dzwiekowych

    [Header("Pitch")]   // wysokosc dzwieku jest losowana dla wiekszej roznorodnosci
    [SerializeField] [Range(-3f, 3f)]
    private float minPitch = 0.9f;
    [SerializeField] [Range(-3f, 3f)]
    private float maxPitch = 1.1f;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);  // musi istniec przez cala gre, niezaleznie od sceny
    }

    private void Reset()
    {
        // ten kontroler do prawidlowego dzialania wymaga 2 komponentow klasy AudioSource
        // biezaca funkcja dodaje automatycznie brakuje komponenty w edytorze Unity (nie wplywa na runtime)

        int missing = 2 - GetComponents<AudioSource>().Length;  // liczba brakujacych komponentow

        while (missing-- > 0)
            gameObject.AddComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        soundSource.clip = clip;
        soundSource.pitch = Random.Range(minPitch, maxPitch);
        soundSource.Play();
    }
}
