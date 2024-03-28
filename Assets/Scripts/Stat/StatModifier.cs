using System;

public enum ModifierType { Flat, Additive, Multiplicative }

public class StatModifier
{
    public float Value;
    public ModifierType Type;
    public object Source;

    public StatModifier(float value, ModifierType type, object source)
    {
        Value = value;
        Type = type;
        Source = source;
    }
}
