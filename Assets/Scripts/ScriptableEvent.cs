using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class ScriptableEvent : ScriptableObject
{
    private List<ScriptableListener> listeners = new List<ScriptableListener>();

    public void AddListener(ScriptableListener sl)
    {
        if (listeners.Contains(sl)) return;
        listeners.Add(sl);
    }

    public void RemoveListener(ScriptableListener sl)
    {
        if (!listeners.Contains(sl)) return;
        listeners.Remove(sl);
    }

    public void Invoke()
    {
        for(int i = (listeners.Count - 1); i >= 0; i--)
        {
            listeners[i].Invoke();
        }
    }
}
