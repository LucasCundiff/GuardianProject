using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentTest : MonoBehaviour
{
    [SerializeField] Player player;

    public RuneItem headItem;
    public RuneItem chestItem;
    public RuneItem leftShoulderItem;

    public void Start()
    {
        player.EquipItem(EquipLocation.Head, headItem);
        player.EquipItem(EquipLocation.Chest, chestItem);
        player.EquipItem(EquipLocation.LeftShoulder, leftShoulderItem);
    }
}
