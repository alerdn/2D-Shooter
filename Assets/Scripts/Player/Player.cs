using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    public float CurrentHitPoints { get; private set; }
    public float CurrentMana { get; private set; }

    [field: SerializeField] public Gun Gun { get; private set; }
    [field: SerializeField] public Armor Armor { get; private set; }

    #region HEALTH COMPONENT

    public void RestoreHealth(float hp)
    {
        float newHP = CurrentHitPoints + hp;
        CurrentHitPoints = Mathf.Min(newHP, Armor.GetMaxHitPoints());
    }

    public void Damage(float damage)
    {
        float newHP = CurrentHitPoints - damage;
        CurrentHitPoints = Mathf.Max(newHP, 0f);
    }

    public void Kill()
    {
    }

    #endregion
}
