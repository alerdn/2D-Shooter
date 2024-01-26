using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class Gun : Equipment
{
    #region PROPERTIES/FIELDS
    public float DamageBase { get; private set; } = 100f;
    public float CriticalDamageMultiplierBase { get; private set; } = 1.25f;
    public float CriticalChanceBase { get; private set; } = 25f;
    public float MagicalDamageBase { get; private set; } = 100f;

    #endregion

    private void Awake()
    {
        MaxRuneCapacity = 3;
    }

    #region PUBLIC METHODS

    [Button]
    public void Shoot()
    {
        float damage = GetDamage();
        float damageMultiplier = 1;

        bool isCriticalHit = IsCriticalHit();
        if (isCriticalHit)
        {
            damageMultiplier = GetCriticalDamageMultiplier();
        }

        damage *= damageMultiplier;
        Debug.Log($"Hunter shot and caused {damage} {(isCriticalHit ? "critical" : "")} damage");
    }

    [Button]
    public void Cast()
    {
        float damage = GetMagicalDamage();

    }

    #endregion

    #region ATTRIBUTES

    public float GetDamage()
    {
        return DamageBase + (GetModifiers(RuneAttribute.DAMAGE) / 100f * DamageBase);
    }

    public float GetCriticalDamageMultiplier()
    {
        return CriticalDamageMultiplierBase + (GetModifiers(RuneAttribute.CRITICAL_DAMAGE) / 100f * CriticalDamageMultiplierBase);
    }

    public float GetCriticalChance()
    {
        return CriticalChanceBase + (GetModifiers(RuneAttribute.CRITICAL_CHANCE) / 100f * CriticalChanceBase);
    }

    public float GetMagicalDamage()
    {
        return MagicalDamageBase + (GetModifiers(RuneAttribute.MAGICAL_DAMAGE) / 100f * MagicalDamageBase);
    }

    #endregion

    #region HELPERS

    private bool IsCriticalHit()
    {
        return Random.Range(0, 100) < GetCriticalChance();
    }

    #endregion
}