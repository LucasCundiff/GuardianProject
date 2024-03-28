using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Rune")]
public class RuneItem : ScriptableObject
{
    public string ID;
    public string itemName = "";
    public Sprite itemSprite = null;

    #region Additive Modifires
    [Header("Additive Modifires")]
    public float FlatHealth;
    public float FlatEnergy;
    public float FlatDuration;
    public float FlatEfficiency;
    public float FlatPower;
    public float FlatRange;
    public float FlatRegeneration;
    public float FlatRecovery;
    public float FlatArmor;
    public float FlatResistance;
    public float FlatFortitude;
    public float FlatAttackSpeed;
    public float FlatCriticalChance;
    public float FlatCriticalDamage;
    public float FlatMovementSpeed;
    #endregion

    #region Multiplicative Modifiers
    [Header("Multiplicative Modifires")]
    public float MultiplicativeHealth;
    public float MultiplicativeEnergy;
    public float MultiplicativeDuration;
    public float MultiplicativeEfficiency;
    public float MultiplicativePower;
    public float MultiplicativeRange;
    public float MultiplicativeRegeneration;
    public float MultiplicativeRecovery;
    public float MultiplicativeArmor;
    public float MultiplicativeResistance;
    public float MultiplicativeFortitude;
    public float MultiplicativeAttackSpeed;
    public float MultiplicativeCriticalChance;
    public float MultiplicativeCriticalDamage;
    public float MultiplicativeMovementSpeed;
    #endregion

    protected StringBuilder StringBuilder = new StringBuilder();

    public RuneItem GetCopy()
    {
        RuneItem copy = Instantiate(this);
        copy.ID = Guid.NewGuid().ToString();
        return copy;
    }

    public string GetDescription()
    {
        StringBuilder = new StringBuilder();

        GetModifierDescription(FlatHealth, "Health");
        GetModifierDescription(FlatEnergy, "Energy");
        GetModifierDescription(FlatDuration, "Duration");
        GetModifierDescription(FlatEfficiency, "Efficiency");
        GetModifierDescription(FlatPower, "Power");
        GetModifierDescription(FlatRange, "Range");
        GetModifierDescription(FlatRegeneration, "Regeneration");
        GetModifierDescription(FlatRecovery, "Recovery");
        GetModifierDescription(FlatArmor, "Armor");
        GetModifierDescription(FlatResistance, "Resistance");
        GetModifierDescription(FlatFortitude, "Fortitude");
        GetModifierDescription(FlatAttackSpeed, "Attack Speed");
        GetModifierDescription(FlatCriticalChance, "Critical Chance");
        GetModifierDescription(FlatCriticalDamage, "Critical Damage");
        GetModifierDescription(FlatMovementSpeed, "Movement Speed");

        GetModifierDescription(MultiplicativeHealth, "Health", true);
        GetModifierDescription(MultiplicativeEnergy, "Energy", true);
        GetModifierDescription(MultiplicativeDuration, "Duration", true);
        GetModifierDescription(MultiplicativeEfficiency, "Efficiency", true);
        GetModifierDescription(MultiplicativePower, "Power", true);
        GetModifierDescription(MultiplicativeRange, "Range", true);
        GetModifierDescription(MultiplicativeRegeneration, "Regeneration", true);
        GetModifierDescription(MultiplicativeRecovery, "Recovery", true);
        GetModifierDescription(MultiplicativeArmor, "Armor", true);
        GetModifierDescription(MultiplicativeResistance, "Resistance", true);
        GetModifierDescription(MultiplicativeFortitude, "Fortitude", true);
        GetModifierDescription(MultiplicativeAttackSpeed, "Attack Speed", true);
        GetModifierDescription(MultiplicativeCriticalChance, "Critical Chance", true);
        GetModifierDescription(MultiplicativeCriticalDamage, "Critical Damage", true);
        GetModifierDescription(MultiplicativeMovementSpeed, "Movement Speed", true);

        return StringBuilder.ToString();
    }

    public void Equip(Player player)
    {
        //Flat modifires
        if (FlatHealth != 0)
            player.stats.Health.AddModifier(new StatModifier(FlatHealth, ModifierType.Flat, this));
        if (FlatEnergy != 0)
            player.stats.Energy.AddModifier(new StatModifier(FlatEnergy, ModifierType.Flat, this));
        if (FlatDuration != 0)
            player.stats.Duration.AddModifier(new StatModifier(FlatDuration, ModifierType.Flat, this));
        if (FlatEfficiency != 0)
            player.stats.Efficiency.AddModifier(new StatModifier(FlatEfficiency, ModifierType.Flat, this));
        if (FlatPower != 0)
            player.stats.Power.AddModifier(new StatModifier(FlatPower, ModifierType.Flat, this));
        if (FlatRange != 0)
            player.stats.Range.AddModifier(new StatModifier(FlatRange, ModifierType.Flat, this));
        if (FlatRegeneration != 0)
            player.stats.Regeneration.AddModifier(new StatModifier(FlatRegeneration, ModifierType.Flat, this));
        if (FlatRecovery != 0)
            player.stats.Recovery.AddModifier(new StatModifier(FlatRecovery, ModifierType.Flat, this));
        if (FlatArmor != 0)
            player.stats.Armor.AddModifier(new StatModifier(FlatArmor, ModifierType.Flat, this));
        if (FlatResistance != 0)
            player.stats.Resistance.AddModifier(new StatModifier(FlatResistance, ModifierType.Flat, this));
        if (FlatFortitude != 0)
            player.stats.Fortitude.AddModifier(new StatModifier(FlatFortitude, ModifierType.Flat, this));
        if (FlatAttackSpeed != 0)
            player.stats.AttackSpeed.AddModifier(new StatModifier(FlatAttackSpeed, ModifierType.Flat, this));
        if (FlatCriticalChance != 0)
            player.stats.CriticalChance.AddModifier(new StatModifier(FlatCriticalChance, ModifierType.Flat, this));
        if (FlatCriticalDamage != 0)
            player.stats.CriticalDamage.AddModifier(new StatModifier(FlatCriticalDamage, ModifierType.Flat, this));
        if (FlatMovementSpeed != 0)
            player.stats.MovementSpeed.AddModifier(new StatModifier(FlatMovementSpeed, ModifierType.Flat, this));

        //Multiplicative modifiers
        if (MultiplicativeHealth != 0)
            player.stats.Health.AddModifier(new StatModifier(MultiplicativeHealth, ModifierType.Multiplicative, this));
        if (MultiplicativeEnergy != 0)
            player.stats.Energy.AddModifier(new StatModifier(MultiplicativeEnergy, ModifierType.Multiplicative, this));
        if (MultiplicativeDuration != 0)
            player.stats.Duration.AddModifier(new StatModifier(MultiplicativeDuration, ModifierType.Multiplicative, this));
        if (MultiplicativeEfficiency != 0)
            player.stats.Efficiency.AddModifier(new StatModifier(MultiplicativeEfficiency, ModifierType.Multiplicative, this));
        if (MultiplicativePower != 0)
            player.stats.Power.AddModifier(new StatModifier(MultiplicativePower, ModifierType.Multiplicative, this));
        if (MultiplicativeRange != 0)
            player.stats.Range.AddModifier(new StatModifier(MultiplicativeRange, ModifierType.Multiplicative, this));
        if (MultiplicativeRegeneration != 0)
            player.stats.Regeneration.AddModifier(new StatModifier(MultiplicativeRegeneration, ModifierType.Multiplicative, this));
        if (MultiplicativeRecovery != 0)
            player.stats.Recovery.AddModifier(new StatModifier(MultiplicativeRecovery, ModifierType.Multiplicative, this));
        if (MultiplicativeArmor != 0)
            player.stats.Armor.AddModifier(new StatModifier(MultiplicativeArmor, ModifierType.Multiplicative, this));
        if (MultiplicativeResistance != 0)
            player.stats.Resistance.AddModifier(new StatModifier(MultiplicativeResistance, ModifierType.Multiplicative, this));
        if (MultiplicativeFortitude != 0)
            player.stats.Fortitude.AddModifier(new StatModifier(MultiplicativeFortitude, ModifierType.Multiplicative, this));
        if (MultiplicativeAttackSpeed != 0)
            player.stats.AttackSpeed.AddModifier(new StatModifier(MultiplicativeAttackSpeed, ModifierType.Multiplicative, this));
        if (MultiplicativeCriticalChance != 0)
            player.stats.CriticalChance.AddModifier(new StatModifier(MultiplicativeCriticalChance, ModifierType.Multiplicative, this));
        if (MultiplicativeCriticalDamage != 0)
            player.stats.CriticalDamage.AddModifier(new StatModifier(MultiplicativeCriticalDamage, ModifierType.Multiplicative, this));
        if (MultiplicativeMovementSpeed != 0)
            player.stats.MovementSpeed.AddModifier(new StatModifier(MultiplicativeMovementSpeed, ModifierType.Multiplicative, this));

    }

    public void Unequip(Player player) 
    {
        player.stats.Health.RemoveAllModifiersFromSource(this);
        player.stats.Energy.RemoveAllModifiersFromSource(this);
        player.stats.Duration.RemoveAllModifiersFromSource(this);
        player.stats.Efficiency.RemoveAllModifiersFromSource(this);
        player.stats.Power.RemoveAllModifiersFromSource(this);
        player.stats.Range.RemoveAllModifiersFromSource(this);
        player.stats.Regeneration.RemoveAllModifiersFromSource(this);
        player.stats.Recovery.RemoveAllModifiersFromSource(this);
        player.stats.Armor.RemoveAllModifiersFromSource(this);
        player.stats.Resistance.RemoveAllModifiersFromSource(this);
        player.stats.Fortitude.RemoveAllModifiersFromSource(this);
        player.stats.AttackSpeed.RemoveAllModifiersFromSource(this);
        player.stats.CriticalChance.RemoveAllModifiersFromSource(this);
        player.stats.CriticalDamage.RemoveAllModifiersFromSource(this);
        player.stats.MovementSpeed.RemoveAllModifiersFromSource(this);
    }

    protected void GetModifierDescription(float value, string statName, bool isPercent = false)
    {
        if (value != 0)
        {
            if (StringBuilder.Length > 0)
                StringBuilder.AppendLine();

            if (value > 0)
                StringBuilder.Append("+");

            if (isPercent)
            {
                StringBuilder.Append(value * 100);
                StringBuilder.Append("% ");
            }
            else
            {
                StringBuilder.Append(value);
                StringBuilder.Append(" ");
            }
            StringBuilder.Append(statName);
        }
    }
}

