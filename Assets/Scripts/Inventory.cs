using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory
{
    public event EventHandler OnInventoryChange;
	public event EventHandler<OnItemUsedEventArgs> OnItemUsed;
	public event EventHandler<OnWeaponEquippedEventArgs> OnWeaponEquipped;

	public class OnWeaponEquippedEventArgs : EventArgs
	{
		public Item item;
	}

	public class OnItemUsedEventArgs : EventArgs
	{
		public int plusHealth;
		public OnItemUsedEventArgs(int plusHealth)
		{
			this.plusHealth = plusHealth;
		}

		public OnItemUsedEventArgs(int amount, Item.ItemType itemType)
		{

		}
	}

    private List<Item> itemList;
	private int maxAmount = 56;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Weapon, amount = 1 });
		AddItem(new Item { itemType = Item.ItemType.Medkit, amount = 1 });
		AddItem(new Item { itemType = Item.ItemType.Stick, amount = 10 });
	}

	public void AddItem(Item item)
	{
		if (itemList.Count > maxAmount)
		{
			Debug.LogWarning("List is full!!");
			return;
		}
        if(item.IsStackable())
        {
            bool isItemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (item.itemType == inventoryItem.itemType)
                {
                    isItemAlreadyInInventory = true;
                    inventoryItem.amount += item.amount;
                }
            }

			if (!isItemAlreadyInInventory)
			{
				itemList.Add(item);
			}
		}
        else
        {
			itemList.Add(item);
		}

        OnInventoryChange?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
		if (item.IsStackable())
		{
			Item itemInInventory = null;
			foreach (Item inventoryItem in itemList)
			{
				if (inventoryItem.itemType == item.itemType)
				{
					inventoryItem.amount -= item.amount;
					itemInInventory = inventoryItem;
				}
			}

			if (itemInInventory != null && itemInInventory.amount <= 0)
			{
				Debug.Log(item.itemType.ToString());
				itemList.Remove(itemInInventory);
			}
		}
		else
		{
			itemList.Remove(item);
		}
		OnInventoryChange?.Invoke(this, EventArgs.Empty);
	}

	public void UseItem(Item item)
	{
		Item duplicateItem = new Item { itemType = item.itemType, amount = 1 };
		RemoveItem(duplicateItem);

		switch(item.itemType)
		{
			case Item.ItemType.Medkit: 
				OnItemUsed?.Invoke(this, new OnItemUsedEventArgs(50));
				break;

			case Item.ItemType.Weapon:  
				OnWeaponEquipped?.Invoke(this, new OnWeaponEquippedEventArgs {item = duplicateItem});
				break;
		}

	}

	public List<Item> GetItemList()
    {
        return itemList;
    }
}
