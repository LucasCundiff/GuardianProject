using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public float BaseValue;

    private List<StatModifier> modifiers = new List<StatModifier>();
    private bool isDirty = true;
    private float lastCalculatedValue;

    public Stat(float baseValue)
    {
        BaseValue = baseValue;
    }

    public float Value
    {
        get
        {
            if (isDirty)
            {
                lastCalculatedValue = CalculateFinalValue();
                isDirty = false;
            }
            return lastCalculatedValue;
        }
    }

    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        modifiers.Add(mod);
        modifiers.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (modifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;
        for (int i = modifiers.Count - 1; i >= 0; i--)
        {
            if (modifiers[i].Source == source)
            {
                isDirty = true;
                modifiers.RemoveAt(i);
                didRemove = true;
            }
        }
        return didRemove;
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Type < b.Type) return -1;
        else if (a.Type > b.Type) return 1;
        return 0; 
    }

    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < modifiers.Count; i++)
        {
            StatModifier mod = modifiers[i];

            if (mod.Type == ModifierType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == ModifierType.Additive)
            {
                sumPercentAdd += mod.Value;

                if (i + 1 >= modifiers.Count || modifiers[i + 1].Type != ModifierType.Additive)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == ModifierType.Multiplicative)
            {
                finalValue *= 1 + mod.Value;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }
}
