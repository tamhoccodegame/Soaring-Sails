using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Equipment
{

	public event EventHandler OnEquipmentChange;

	private Item equipItem;
	private Inventory inventory;


	public Equipment()
	{
		equipItem = null;
	}

	public void SetInventory(Inventory inventory)
	{
		this.inventory = inventory;
	}

	public void EquipItem(Item item)
	{
		if(equipItem != null)
		{
			//Detach equippingItem and Add back to inventory
			inventory.AddItem(equipItem);
			//Equip item and Remove from inventory;
			inventory.RemoveItem(item);
		}
		else
		{
			equipItem = item;
			inventory.RemoveItem(equipItem);
		}
		OnEquipmentChange?.Invoke(this, EventArgs.Empty); 
	}

	public Item GetEquippedItem()
	{
		return equipItem;
	}
}
