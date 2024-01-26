using UnityEngine;

public class Armor : Equipment
{
    public float HealthPointsBase { get; private set; } = 100f;
    public float ManaRecoveryBase { get; private set; } = 10f;

    #region ATTRIBUTES

    public float GetHealthPoints()
    {
        return HealthPointsBase + (GetModifiers(RuneAttribute.HEALTH) / 100f * HealthPointsBase);
    }

    public float GetManaRecovery()
    {
        return ManaRecoveryBase + (GetModifiers(RuneAttribute.MANA_RECOVERY) / 100f * ManaRecoveryBase);
    }

    #endregion
}