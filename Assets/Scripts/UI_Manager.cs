using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
	Transform inventory;
	Transform playerStat;
	Transform crafting;
	Transform setting;
	Transform deathCanvas;
	List<Transform> listUI;


	[SerializeField] private PlayerController1 playerController1;
	private void Start()
	{
		playerController1.OnPlayerDie += PlayerController1_OnPlayerDie;
		inventory = transform.Find("InventoryUI");
		playerStat = transform.Find("PlayerStatUpgradeUI");
		crafting = transform.Find("CraftingUI");
		setting = transform.Find("Setting");

		deathCanvas = transform.Find("GameOver"); 

		inventory.gameObject.SetActive(false);
		playerStat.gameObject.SetActive(false);
		crafting.gameObject.SetActive(false);
		setting.gameObject.SetActive(false);

		deathCanvas.gameObject.SetActive(false);

		listUI = new List<Transform>();
		listUI.Add(inventory);
		listUI.Add(playerStat);
		listUI.Add(crafting);
		listUI.Add(setting);

		
	}

	private void PlayerController1_OnPlayerDie(object sender, System.EventArgs e)
	{
		ShowGameOver();
	}

	public void ShowGameOver()
	{
		deathCanvas.gameObject.SetActive(true);
	}

	private void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			TurnOnOffUI("Setting");
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			TurnOnOffUI("InventoryUI");
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			TurnOnOffUI("CraftingUI");
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			TurnOnOffUI("PlayerStatUpgradeUI");
		}
	}

	private void TurnOnOffUI(string nameUI)
	{
		foreach(Transform transform in listUI)
		{
			if (transform.name == nameUI)
			{
				transform.gameObject.SetActive(!transform.gameObject.activeSelf);
			}
			else
			{
				transform.gameObject.SetActive(false);
			}
		}
		if(nameUI == "Setting")
		{
			if (setting.gameObject.activeSelf)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}

	
}
