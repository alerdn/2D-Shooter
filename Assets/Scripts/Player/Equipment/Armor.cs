using UnityEngine;

public class Armor : Equipment
{
    public float MaxHitPointsBase { get; private set; } = 100f;
    public float ManaRecoveryBase { get; private set; } = 10f;

    #region ATTRIBUTES

    public float GetMaxHitPoints()
    {
        return MaxHitPointsBase + (GetModifiers(RuneAttribute.HEALTH) / 100f * MaxHitPointsBase);
    }

    public float GetManaRecovery()
    {
        return ManaRecoveryBase + (GetModifiers(RuneAttribute.MANA_RECOVERY) / 100f * ManaRecoveryBase);
    }

    #endregion
}