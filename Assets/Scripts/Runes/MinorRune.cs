using UnityEngine;

public enum RuneAttribute
{
    DAMAGE,
    CRITICAL_DAMAGE,
    CRITICAL_CHANCE,

    MAGICAL_DAMAGE,
    MANA_RECOVERY,

    HEALTH,
    DEFENCE,
    MANA,
}

public class MinorRune : RuneBase
{
    [field: SerializeField] public RuneAttribute Attribute { get; private set; }
    [field: SerializeField] public float Value { get; private set; }
}