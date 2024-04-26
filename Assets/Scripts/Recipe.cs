using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
	private string nameRecipe;

	public Item GetIngridients(string nameRecipe)
	{
		switch(nameRecipe)
		{
			default:
			case "Broom" : return new Item { itemType = Item.ItemType.Stick, amount = 2 };

		}
	}
}
