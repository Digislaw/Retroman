﻿using UnityEngine;

[CreateAssetMenu(fileName = "Layer", menuName = "Layer")]
public class Layer : ScriptableObject
{
    [SerializeField]
    private LayerMask mask;
    public int Value { get { return mask; } }

    public bool Compare(int otherLayer)
    {
        return mask == (mask | 1 << otherLayer);
    }

    public static bool Compare(LayerMask mask, int layer)
    {
        return mask == (mask | 1 << layer);
    }
}
