using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils; 

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
	private Player player;
	private void Awake()
	{
		itemSlotTemplate = transform.Find("Slots").Find("SlotTemplate");
		itemSlotContainer = transform.Find("Slots");
	}

	public void SetPlayer(Player player)
	{
		this.player = player;
	}

	public void SetInventory(Inventory inventory)
    {
		this.inventory = inventory;
		RefreshInventoryItems();


		inventory.OnInventoryChange += Inventory_OnInventoryChange;
	}

	private void Inventory_OnInventoryChange(object sender, EventArgs e)
	{
		RefreshInventoryItems();
	}

	private void RefreshInventoryItems()
    {
		foreach (Transform child in itemSlotContainer)
		{
			if (child == itemSlotTemplate) continue;
			Destroy(child.gameObject);
		}

		int x = 0;
		int y = 0;
		float itemSlotCellSize = 67f;
		foreach(Item item in inventory.GetItemList())
		{ 
		

			RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);

			itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
			{
				//Use item
			};
			itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
			{
				//Drop item
				Item duplicateItem = new Item{ itemType = item.itemType, amount = item.amount };
				inventory.RemoveItem(item);
				ItemWorld.DropItem(player.GetPosition(),duplicateItem);
			};


			itemSlotRectTransform.anchoredPosition += new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
			Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
			image.sprite = item.GetSprite(); 

			TextMeshProUGUI amountText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
			if(item.amount > 1)
			{
				amountText.SetText(item.amount.ToString());
			}
			else
			{
				amountText.SetText("");
			}

			x++;
			if (x > 3)
			{
				x = 0;
				y++;
				
			}
		}
	}


}
