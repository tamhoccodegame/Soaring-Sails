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



    public void ShowIngredients(Item ingredients, Item result)
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

       

        RectTransform ingredientRectTransform = Instantiate(ingredientSlotTemplate, ingredientSlotContainer).GetComponent<RectTransform>();
        ingredientRectTransform.anchoredPosition = Vector2.zero;
		ingredientRectTransform.gameObject.SetActive(true);

		

		Image image = ingredientRectTransform.Find("Image").GetComponent<Image>();
        image.sprite = ingredients.GetSprite();

        TextMeshProUGUI amountText = ingredientRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();    
        if(ingredients.amount > 1)
        {
            amountText.SetText(ingredients.amount.ToString());
        }
        else
        {
            amountText.SetText("");
        }

		foreach (Item item in inventory.GetItemList())
        {
            transform.Find("CraftBtn").GetComponent<Button_UI>().ClickFunc = () =>
			{
                if (ingredients.itemType == item.itemType)
                {
                    if (item.amount - ingredients.amount <= 0)
                    {
                        amountText.color = Color.red;
                    }
                    if(item.amount >= ingredients.amount)
                    {
                        inventory.AddItem(result);
                        inventory.RemoveItem(ingredients);
                    }
                }
                else
                {
                    amountText.color = Color.red;
                }
						
			};
		}
            
           
        }
    

	
}
