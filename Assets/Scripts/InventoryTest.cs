using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public Player player;
    public List<RuneItem> itemsToAdd = new List<RuneItem>();

    public void Awake()
    {
        if (player != null)
        {
            foreach (var item in itemsToAdd)
            {
                player.AddItem(item.GetCopy());
            }
        }
    }

}
