using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using TreeEditor;
using UnityEngine.UI;
using TMPro;

public class CraftingSystem : MonoBehaviour
{
    private Recipe recipe;
    private Transform ingredientSlotTemplate;
    private Transform ingredientSlotContainer;
    public Inventory inventory;
    void Start()
    {
        ingredientSlotTemplate = transform.Find("Ingredients").Find("ingredientSlotTemplate");
        ingredientSlotContainer = transform.Find("Ingredients");

		transform.Find("Recipes").Find("Broom").GetComponent<Button_UI>().ClickFunc = () =>
        {
            recipe = new Recipe();
            ShowIngredients(recipe.GetIngridients("Broom"), new Item { itemType = Item.ItemType.Weapon, amount = 1});
        };
       
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }



    public void ShowIngredients(List<Item> ingredients, Item result)
    {

        foreach(Transform child in ingredientSlotContainer)
        {
            if (child == ingredientSlotTemplate)
            {
                continue;
            }
            else
            {
                Destroy(child.gameObject);
            }
        }



        foreach (Item ingredient in ingredients)
        {



            RectTransform ingredientRectTransform = Instantiate(ingredientSlotTemplate, ingredientSlotContainer).GetComponent<RectTransform>();
            ingredientRectTransform.anchoredPosition = Vector2.zero;
            ingredientRectTransform.gameObject.SetActive(true);



            Image image = ingredientRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = ingredient.GetSprite();

            TextMeshProUGUI amountText = ingredientRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();


            if (ingredient.amount > 1)
            {
                amountText.SetText(ingredient.amount.ToString());
            }
            else
            {
                amountText.SetText("");
            }



            foreach (Item item in inventory.GetItemList())
            {
                
                    if (ingredient.itemType == item.itemType)
                    {
                        if (item.amount - ingredient.amount <= 0)
                        {
                            amountText.color = Color.red;
                        }
                        
                    }
                    else
                    {
                        amountText.color = Color.red;
                    }

				transform.Find("CraftBtn").GetComponent<Button_UI>().ClickFunc = () =>
				{
					if (item.amount >= ingredient.amount)
					{
						inventory.AddItem(result);
						inventory.RemoveItem(ingredient);
					}
				};

			}
		}
            
           
        }
    

	
}
