using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float StartingHealth = 500f;
    public float StartingEnergy = 500f;
    public float StartingDuration = 100f;
    public float StartingEfficiency = 100f;
    public float StartingPower = 100f;
    public float StartingRange = 100f;
    public float StartingRegeneration = 100f;
    public float StartingRecovery = 100f;
    public float StartingArmor = 100f;
    public float StartingResistance = 100f;
    public float StartingFortitude = 100f;
    public float StartingAttackSpeed = 100f;
    public float StartingCriticalChance = 1f;
    public float StartingCriticalDamage = 100f;
    public float StartingMovementSpeed = 100f;

    public Stat Health;
    public Stat Energy;
    public Stat Duration;
    public Stat Efficiency;
    public Stat Power;
    public Stat Range;
    public Stat Regeneration;
    public Stat Recovery;
    public Stat Armor;
    public Stat Resistance;
    public Stat Fortitude;
    public Stat AttackSpeed;
    public Stat CriticalChance;
    public Stat CriticalDamage;
    public Stat MovementSpeed;

    public void OnEnable()
    {
        Health = new Stat(StartingHealth);
        Energy = new Stat(StartingEnergy);
        Duration = new Stat(StartingDuration);
        Efficiency = new Stat(StartingEfficiency);
        Power = new Stat(StartingPower);
        Range = new Stat(StartingRange);
        Regeneration = new Stat(StartingRegeneration);
        Recovery = new Stat(StartingRecovery);
        Armor = new Stat(StartingArmor);
        Resistance = new Stat(StartingResistance);
        Fortitude = new Stat(StartingFortitude);
        AttackSpeed = new Stat(StartingAttackSpeed);
        CriticalChance = new Stat(StartingCriticalChance);
        CriticalDamage = new Stat(StartingCriticalDamage);
        MovementSpeed = new Stat(StartingMovementSpeed);
    }
    public void OnDisable()
    {
        Health = null;
        Energy = null;
        Duration = null;
        Efficiency = null;
        Power = null;
        Range = null;
        Regeneration = null;
        Recovery = null;
        Armor = null;
        Resistance = null;
        Fortitude = null;
        AttackSpeed = null;
        CriticalChance = null;
        CriticalDamage = null;
        MovementSpeed = null;
    }
}
