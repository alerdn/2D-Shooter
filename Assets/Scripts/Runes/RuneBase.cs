using UnityEngine;

public enum RuneType
{
    PHYSICAL,
    MAGICAL,
    ARMOR
}

public abstract class RuneBase : MonoBehaviour
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public RuneType Type { get; protected set; }
}