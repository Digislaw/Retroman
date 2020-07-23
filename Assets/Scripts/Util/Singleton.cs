using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance    // globalnie dostepna instancja
    { get; private set; }

    protected virtual void Awake()  // istotne jest wywolanie base.Awake() w przypadku przeslaniania
    {
        if (Instance == null)
            // instancja jeszcze nie istnieje - przypisz aktualna
            Instance = this as T;
        else
            // instancja juz istnieje - usun duplikat (zabezpieczenie)
            Destroy(gameObject);
    }
}
