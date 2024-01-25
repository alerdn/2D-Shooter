using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region PROPERTIES/FIELDS
    public float DamageBase { get; private set; } = 100f;
    public float CriticalDamageBase { get; private set; } = 1.25f;
    public float CriticalChanceBase { get; private set; } = 25f;
    public float MagicalDamageBase { get; private set; } = 100f;
    public float ManaRecoveryBase { get; private set; } = 10f;

    public List<RuneBase> Runes { get; private set; } = new();
    public int MaxRuneCapacity { get; private set; } = 3;
    public int CurrentRuneCapacity => Runes.Count;

    #endregion

    #region PUBLIC METHODS

    [Button]
    public void Shoot()
    {
        Debug.Log($"Hunter shot and caused {GetDamage()} damage");
    }

    public void AddRune(RuneBase rune)
    {
        if (CurrentRuneCapacity >= MaxRuneCapacity) return;

        Runes.Add(rune);
    }

    public void RemoveRune(RuneBase rune)
    {
        Runes.Remove(rune);
    }

    #endregion

    #region ATTRIBUTES

    public float GetDamage()
    {
        return DamageBase + (GetModifiers(RuneAttribute.DAMAGE) / 100f * DamageBase);
    }

    public float GetCriticalDamage()
    {
        return CriticalDamageBase + (GetModifiers(RuneAttribute.CRITICAL_DAMAGE) / 100f * CriticalDamageBase);
    }

    public float GetCriticalChance()
    {
        return CriticalChanceBase + (GetModifiers(RuneAttribute.CRITICAL_CHANCE) / 100f * CriticalChanceBase);
    }

    public float GetMagicalDamage()
    {
        return MagicalDamageBase + (GetModifiers(RuneAttribute.MAGICAL_DAMAGE) / 100f * MagicalDamageBase);
    }

    public float GetManaRecovery()
    {
        return ManaRecoveryBase + (GetModifiers(RuneAttribute.MANA_RECOVERY) / 100f * ManaRecoveryBase);
    }

    #endregion

    #region HELPERS

    private float GetModifiers(RuneAttribute attribute)
    {
        return GetMinorRunes()
            .Where((rune) => rune.Attribute == attribute)
            .Aggregate(0f, (total, rune) => total + rune.Value);

    }

    private IEnumerable<MinorRune> GetMinorRunes()
    {
        foreach (RuneBase runeBase in Runes)
        {
            if (runeBase is MinorRune)
            {
                yield return runeBase as MinorRune;
            }
        }
    }

    #endregion
}