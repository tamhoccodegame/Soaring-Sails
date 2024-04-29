using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
	Transform inventory;
	Transform playerStat;
	Transform crafting;
	private void Start()
	{
		inventory = transform.Find("InventoryUI");
		playerStat = transform.Find("PlayerStatUpgradeUI");
		crafting = transform.Find("CraftingUI");

		inventory.gameObject.SetActive(false);
		playerStat.gameObject.SetActive(false);
		crafting.gameObject.SetActive(false);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
			crafting.gameObject.SetActive(false);
			playerStat.gameObject.SetActive(false); 
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			crafting.gameObject.SetActive(!crafting.gameObject.activeSelf);
			inventory.gameObject.SetActive(false);
			playerStat.gameObject.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			playerStat.gameObject.SetActive(!playerStat.gameObject.activeSelf);
			crafting.gameObject.SetActive(false);
			inventory.gameObject.SetActive(false);
		}
	}
}
