using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemHandler : MonoBehaviour
{
    public int itemId;
    public ItemTypes itemType;
    public int amount;

    public void OnCollection()
    {
        if(itemType == ItemTypes.Money)
        {
            Inventory.Player.Inventory.money += amount;
        }
        else if (itemType == ItemTypes.Weapon || itemType == ItemTypes.Apparel || itemType == ItemTypes.Quest)
        {
            Inventory.Player.Inventory.playerInv.Add(ItemData.CreateItem(itemId));
        }
        else
        {
            int found = 0;
            int addIndex = 0;
            for (int i = 0; i < Inventory.Player.Inventory.playerInv.Count; i++)
            {
                if (itemId == Inventory.Player.Inventory.playerInv[i].ID)
                {
                    found = 1;
                    addIndex = i;
                    break;
                }
            }
            if(found == 1)
            {
                Inventory.Player.Inventory.playerInv[addIndex].Amount += amount;
            }
            else
            {
                Inventory.Player.Inventory.playerInv.Add(ItemData.CreateItem(itemId));
                Inventory.Player.Inventory.playerInv.Last<Item>().Amount = amount;
            }
        }
        Destroy(gameObject);
    }
}
