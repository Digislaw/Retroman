using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance    // globalnie dostepna instancja
    {
        get { return _instance; }
    }

    protected virtual void Awake()  // istotne jest wywolanie base.Awake() w przypadku przeslaniania
    {
        if (_instance == null)
            // instancja jeszcze nie istnieje - przypisz aktualna
            _instance = this as T;
        else
            // instancja juz istnieje - usun duplikat (zabezpieczenie, sytuacja nie powinna sie zdarzyc)
            Destroy(gameObject);
    }
}
