using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    public List<RuneBase> Runes { get; protected set; } = new();
    public int MaxRuneCapacity { get; protected set; }
    public int CurrentRuneCapacity => Runes.Count;

    #region PUBLIC METHODS (RUNES)

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

    #region HELPERS

    protected float GetModifiers(RuneAttribute attribute)
    {
        return GetMinorRunes()
            .Where((rune) => rune.Attribute == attribute)
            .Aggregate(0f, (total, rune) => total + rune.Value);

    }

    protected IEnumerable<MinorRune> GetMinorRunes()
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