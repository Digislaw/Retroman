using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource musicSource; // zrodlo muzyki
    [SerializeField]
    private AudioSource soundSource; // zrodlo efektow dzwiekowych

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);  // musi istniec przez cala gre, niezaleznie od sceny
    }

    private void Reset()
    {
        // kontroler ten do prawidlowego dzialania wymaga 2 komponentow klasy AudioSource
        // biezaca funkcja dodaje automatycznie brakuje komponenty w edytorze Unity (nie wplywa na runtime)

        int missing = 2 - GetComponents<AudioSource>().Length;  // liczba brakujacych komponentow

        while (missing-- > 0)
            gameObject.AddComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        soundSource.clip = clip;
        soundSource.Play();
    }
}
