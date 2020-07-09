using System.Collections;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [SerializeField]
    private AudioClip musicClip;    // zapetlona muzyka w tle

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

    public AudioClip currentMusic { get { return musicSource.clip; } }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);  // musi istniec przez cala gre, niezaleznie od sceny

        PlayMusic(musicClip);
    }

    private void Reset()
    {
        // ten kontroler do prawidlowego dzialania wymaga 2 komponentow klasy AudioSource
        // biezaca funkcja dodaje automatycznie brakuje komponenty w edytorze Unity (nie wplywa na runtime)

        int missing = 2 - GetComponents<AudioSource>().Length;  // liczba brakujacych komponentow

        while (missing-- > 0)
            gameObject.AddComponent<AudioSource>();
    }

    public void Play(AudioClip clip, bool strict = false)
    {
        soundSource.clip = clip;
        soundSource.pitch = strict ? 1f : Random.Range(minPitch, maxPitch);
        soundSource.Play();
    }

    public void PlayStrict(AudioClip clip)
    {
        Play(clip, true);
    }

    public void SwitchMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
        else
            musicSource.UnPause();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayMusicWithDelay(AudioClip clip, float time)
    {
        StartCoroutine(MusicWithDelayCo(clip, time));
    }

    private IEnumerator MusicWithDelayCo(AudioClip clip, float time)
    {
        yield return new WaitForSeconds(time);
        PlayMusic(clip);
    }
}
