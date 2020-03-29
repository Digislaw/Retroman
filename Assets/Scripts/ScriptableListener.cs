using UnityEngine;
using UnityEngine.Events;

public class ScriptableListener : MonoBehaviour
{
    [SerializeField] private ScriptableEvent scriptableEvent;   // event do nasluchiwania
    [SerializeField] private UnityEvent InvokeEvent;    // funkcje do wykonania

    public void Invoke()
    {
        // wywolanie funkcji jako odpowiedz na zdarzenie
        InvokeEvent.Invoke();
    }

    private void OnEnable()
    {
        // dodaj do listy "sluchaczy"
        scriptableEvent.AddListener(this);
    }

    private void OnDisable()
    {
        // usun z listy "sluchaczy"
        scriptableEvent.RemoveListener(this);
    }
}
