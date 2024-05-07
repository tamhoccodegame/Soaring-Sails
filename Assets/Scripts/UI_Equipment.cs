using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Equipment : MonoBehaviour
{
    private Transform equipmentSlotTemplate;
	private Equipment equipment;

	private void Start()
	{
		equipmentSlotTemplate = transform.Find("SlotTemplate"); 
	}

	public void SetEquipment(Equipment equipment)
	{
		this.equipment = equipment;
		equipment.OnEquipmentChange += Equipment_OnEquipmentChange;
		RefreshEquipmentSlot();
	}

	private void Equipment_OnEquipmentChange(object sender, System.EventArgs e)
	{
		RefreshEquipmentSlot();
	}

	private void RefreshEquipmentSlot()
	{
		foreach(Transform child in transform)
		{
			if(child == equipmentSlotTemplate || child.name == "SlotBackground")
			{
				continue;
			}
			else
			{
				Destroy(child.gameObject);
			}
		}

		if(equipment.GetEquippedItem() != null)
		{
			RectTransform rectTransform = Instantiate(equipmentSlotTemplate, transform).GetComponent<RectTransform>();

			rectTransform.gameObject.SetActive(true);
			Image image = rectTransform.Find("Image").GetComponent<Image>();
			image.sprite = equipment.GetEquippedItem().GetSprite();
		}
		
	}
}
