using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory
{
    public event EventHandler OnInventoryChange;
	public event EventHandler OnCoinDrop;
	
	public event EventHandler<OnItemUsedEventArgs> OnItemUsed;
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
		AddItem(new Item { itemType = Item.ItemType.sHealthPotionSprite, amount = 1 });
		AddItem(new Item { itemType = Item.ItemType.mHealthPotionSprite, amount = 1 });
		AddItem(new Item { itemType = Item.ItemType.lHealthPotionSprite, amount = 1 });
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
		if(item.itemType == Item.ItemType.Coin)
		{
			OnCoinDrop?.Invoke(this, EventArgs.Empty);
		}
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
			case Item.ItemType.sHealthPotionSprite: 
				OnItemUsed?.Invoke(this, new OnItemUsedEventArgs(20));
				break;
			case Item.ItemType.mHealthPotionSprite:
				OnItemUsed?.Invoke(this, new OnItemUsedEventArgs(40));
				break;
			case Item.ItemType.lHealthPotionSprite:
				OnItemUsed?.Invoke(this, new OnItemUsedEventArgs(70));
				break;
		}

	}

	public List<Item> GetItemList()
    {
        return itemList;
    }
}
