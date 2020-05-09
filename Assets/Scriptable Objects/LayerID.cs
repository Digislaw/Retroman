using UnityEngine;

[CreateAssetMenu(fileName = "Layer", menuName = "Layer ID")]
public class LayerID : ScriptableObject
{
    [SerializeField]
    private LayerMask mask;
    public int Value { get { return mask; } }
}
