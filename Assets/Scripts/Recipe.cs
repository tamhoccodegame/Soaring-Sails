using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
	private string nameRecipe;
	private List<Item> ingridientsList;

	public List<Item> GetIngridients(string nameRecipe)
	{
		switch(nameRecipe)
		{
			default:
			case "Broom" :
				{
					ingridientsList = new List<Item>();
					ingridientsList.Add(new Item{itemType = Item.ItemType.Stick, amount = 1 });
					ingridientsList.Add(new Item { itemType = Item.ItemType.Coin, amount = 20 });
					return ingridientsList;
				}

		}
	}
}
