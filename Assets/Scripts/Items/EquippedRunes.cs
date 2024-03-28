using System;
using System.Collections.Generic;

[Serializable]
public class EquippedRunes
{
    public Dictionary<EquipLocation, RuneItem> equippedRunes = new Dictionary<EquipLocation, RuneItem>();

    // Define events for equipping and unequipping items
    public event Action<RuneItem> OnRuneEquipped;
    public event Action<RuneItem> OnRuneUnequipped;

    public bool EquipItem(EquipLocation targetLocation, RuneItem rune)
    {
        if (equippedRunes.ContainsKey(targetLocation))
            OnRuneUnequipped?.Invoke(equippedRunes[targetLocation]);

        equippedRunes[targetLocation] = rune;
        OnRuneEquipped?.Invoke(rune);
        return true;
    }

    public void UnequipItem(EquipLocation targetLocation)
    {
        if (equippedRunes.ContainsKey(targetLocation))
        {
            OnRuneUnequipped?.Invoke(equippedRunes[targetLocation]);
            equippedRunes.Remove(targetLocation);
        }
    }
}
