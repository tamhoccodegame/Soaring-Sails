using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    Transform slotTemplate;
    
    private Inventory inventory;

    void Start()
    {
        slotTemplate = transform.Find("SlotTemplate"); 
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
		inventory.OnWeaponEquipped += Inventory_OnWeaponEquipped;
    }

	private void Inventory_OnWeaponEquipped(object sender, Inventory.OnWeaponEquippedEventArgs e)
	{
        RefreshEquipWeapon(e.item);
	}

	public void RefreshEquipWeapon(Item item)
    {
        foreach(Transform child in transform)
        {
            if(child == slotTemplate || !child.name.Contains("Slot"))
            {
                continue;
            }
            else
            {
                Destroy(child.gameObject);
            }
        }

        RectTransform rectTransform = Instantiate(slotTemplate, transform).GetComponent<RectTransform>();
        rectTransform.gameObject.SetActive(true);

        Image image = rectTransform.Find("Image").GetComponent<Image>();
        image.sprite = item.GetSprite();
    }
}
