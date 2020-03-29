using UnityEngine;

[CreateAssetMenu]
public class FloatVar : ScriptableObject
{
    public float Value { get; private set; }

    public void Set(float value)
    {
        Value = value;
    }

    public void Modify(float change)
    {
        Value += change;
    }

    public static implicit operator float(FloatVar variable)
    {
        return variable.Value;
    }
}
