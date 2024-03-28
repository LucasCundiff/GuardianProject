using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipLocation
{
    Head,
    LeftShoulder,
    RightShoulder,
    Chest,
    LeftHand,
    RightHand,
    LeftLeg,
    RightLeg,
    LeftFoot,
    RightFoot,
}

public class EquipmentSlotUI : ItemSlotUI
{
    public EquipLocation location;
}
